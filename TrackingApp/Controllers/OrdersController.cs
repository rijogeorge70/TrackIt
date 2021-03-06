using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingApp.Models;
using TrackingApp.Services;

namespace TrackingApp.Controllers
{
    public class OrdersController : Controller
    {
        readonly IOrders iss;

        public OrdersController(IOrders iss)
        {
            this.iss = iss;
        }

        [HttpGet]
        public IActionResult AddOrder(int? id)
        {
            if (id == null)
                return View();
            else
            {
                Orders orders = iss.AddOrder(id);
                return View(orders);
            }
        }

        [HttpPost]
        public IActionResult AddOrder(Orders NewOrder, int? id)
        {
            iss.AddOrder(NewOrder, id);

            if(id == null)
            {
                ViewBag.AddMessage = "New Order from  " + NewOrder.SourceLocation + " to " + NewOrder.Destination + " Added Successfully";
            }
            else
            {
                ViewBag.AddMessage = "Order from  " + NewOrder.SourceLocation + " to " + NewOrder.Destination + " Edited Successfully";
            }

            
            ModelState.Clear();
            return View();
        }

        public IActionResult AllOrders()
        {
            IEnumerable<Orders> AllOrder = iss.AllOrders();
            return View(AllOrder);
        }

        public IActionResult Delete(int id)
        {
            iss.DeleteOrder(id);
            ModelState.Clear();
            return RedirectToAction("AllOrders");

        }

        
        public IActionResult Details(int id)
        {
            return View(iss.OrderDetails(id));
        }

        [HttpGet]
        public IActionResult PickOrder(int id)
        {
            Orders DeleteOrder =  iss.PickOrder(id);
            return View();
        }

        [HttpPost]
        public IActionResult PickOrder(int? id)
        {
            if(id==null)
                return RedirectToAction("AllOrders");
            else
            {
                iss.DeleteOrder(id);
                ModelState.Clear();
                return RedirectToAction("AllOrders");
            }
        }
    }
}
