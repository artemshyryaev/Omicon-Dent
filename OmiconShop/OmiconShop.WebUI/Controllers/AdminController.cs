﻿using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web;
using System;
using OmiconShop.Domain.Enumerations;
using WebMatrix.WebData;
using System.Web.Security;
using OmiconShop.Application.Admin;
using OmiconShop.Application.Admin.ViewModel;
using System.Threading.Tasks;
using OmiconShop.WebUI.HelperAttributes;

namespace OmiconShop.WebUI.Controllers
{
    [Authorization]
    public class AdminController : Controller
    {
        AdminApi adminApi;
        const int PageSize = 10;

        public AdminController(AdminApi adminApi)
        {
            this.adminApi = adminApi;
        }

        [HttpGet]
        public ActionResult PersonalInfo()
        {
            var userName = User.Identity.Name;
            var userModel = adminApi.GetCurrentUserData(userName);

            return View(userModel);
        }

        [HttpPost]
        public async Task<ActionResult> PersonalInfo(int id, string email)
        {
            var changedUser = await adminApi.ChangeUserDataAsync(id, email);

            WebSecurity.Logout();
            FormsAuthentication.SetAuthCookie(changedUser.Email, false);

            TempData["message"] = string.Format("The user email was successfully changed!");

            return View(changedUser);
        }

        [HttpGet]
        public ActionResult ProductList(string productName, int page = 1)
        {
            var productListViewModel = adminApi.GetProductsListViewModel(productName, page, PageSize);

            return View(productListViewModel);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductViewModel product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                    image.SaveAs(adminApi.CreateProductFullPath(ref product));

                var productModel = await adminApi.CreateProductAsync(product);
                TempData["message"] = string.Format($"{productModel.Name} was successfully added!");

                return RedirectToAction("ProductList", "Admin");
            }
            else
            {
                return View(product);
            }
        }

        [HttpGet]
        public ActionResult EditProduct(int? id)
        {
            if (id == null)
                return View("PageNotFound");

            var productViewModel = adminApi.CreateProductViewModelByProductId((int)id);

            if (productViewModel == null)
                return View("PageNotFound");

            ViewData["Id"] = id;

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditProduct(ProductViewModel product, int? productId, HttpPostedFileBase image = null)
        {
            if (product == null || productId == null)
                return View("PageNotFound");

            if (ModelState.IsValid)
            {
                if (image != null)
                    image.SaveAs(adminApi.CreateProductFullPath(ref product));

                var productModel = await adminApi.EditProductAsync((int)productId, product);
                TempData["message"] = string.Format($"Data in {productModel.ProductId}/{productModel.Name} was successfully changed!");

                return RedirectToAction("ProductList", "Admin");
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            if (ModelState.IsValid)
            {
                await adminApi.DeleteProductAsync(productId);
                TempData["message"] = string.Format($"{productId} was successfully deleted!");
            }
            else
            {
                TempData["message"] = string.Format($"Something went wrong, please try again later");
            }

            return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult OrderList(string orderId, OrderStatuses? selectedStatus = null, int page = 1)
        {
            var userEmail = User.Identity.Name;
            var model = adminApi.GetOrdersViewModel(orderId, selectedStatus, userEmail, page, PageSize);

            return View(model);
        }

        [HttpGet]
        public ActionResult OrderDetails(int? id)
        {
            if (id == null)
                return View("PageNotFound");

            var userEmail = User.Identity.GetUserName();
            var order = adminApi.GetCurrentUserOrder((int)id, userEmail);

            if (order == null)
                return View("PageNotFound");

            return View(order);
        }

        [HttpGet]
        public async Task<ActionResult> Approve(int orderId)
        {
            var order = await adminApi.ApproveOrderAsync(orderId);

            return View("OrderDetails", order);
        }

        [HttpGet]
        public async Task<ActionResult> Decline(int orderId)
        {
            var order = await adminApi.DeclineOrderAsync(orderId);

            return View("OrderDetails", order);
        }
    }
}