﻿using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Startersite.Managers;
using Startersite.IManagers;
using Startersite.Models.ViewModel;
using Startersite.Models;

namespace Startersite.Controllers
{
    public class CheckoutController : Controller
    {
        ShopDBContext context;
        IOrderProcessor orderProcessor;
        IEmailSender emailSender;

        public CheckoutController(IOrderProcessor orderProcessor, IEmailSender emailSender)
        {
            context = new ShopDBContext();
            this.orderProcessor = orderProcessor;
            this.emailSender = emailSender;
        }

        public ActionResult OrderInformation()
        {
            return View(new OrderInformationViewModel());
        }

        public ActionResult OrderOverview(BasketViewModel basket, OrderInformationViewModel orderInformation)
        {
            Order order;
            if (basket.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Your basket is empty");
            }

            if (ModelState.IsValid)
            {
                order = orderProcessor.ProcessOrder(basket, orderInformation);
                ViewBag.OrderId = order.Id;
            }
            else
            {
                return View("OrderInformation");
            }

            return View(basket);
        }

        public ActionResult DeclineOrder(int orderId)
        {
            Order order = SqlQueries.GetOrderById(orderId);

            if (order != null)
            {
                context.Entry(order).State = EntityState.Deleted;
                context.SaveChanges();
            }

            return View();
        }

        public ActionResult SubmitOrder(BasketViewModel basket, int orderId)
        {
            if (basket != null)
            {
                basket.ClearBasket();
            }

            Order order = context.Orders.Include(e => e.OrderInformation).Include(e => e.BasketLine).First(x => x.Id == orderId);
            //emailSender.SendOrderConfirmationEmail(order);           

            return View("OrderSucessfullyCreated", order);
        }
    }
}