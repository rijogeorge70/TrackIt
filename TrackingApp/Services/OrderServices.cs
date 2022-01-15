using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingApp.Models;

namespace TrackingApp.Services
{
    public class OrderServices:IOrders
    {
        private readonly TrackingDBContext _context;

        public OrderServices(TrackingDBContext context)
        {
            _context = context;
        }

        public Orders AddOrder(int? id)
        {
            Orders order = _context.Orders.FirstOrDefault(s => s.OrderId == id);
            return order;
        }

        public void AddOrder(Orders order, int? id)
        {
            if (id == null)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            else
            {
                Orders Order = _context.Orders.FirstOrDefault(s => s.OrderId == id);
                Order = order;
                _context.Orders.Update(Order);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Orders> AllOrders()
        {
            IEnumerable<Orders> AllOrders = _context.Orders.ToList();
            return AllOrders;
        }

        public void DeleteOrder(int? id)
        {
            Orders Order = _context.Orders.FirstOrDefault(s => s.OrderId == id);
            if (Order != null)
            {
                _context.Orders.Remove(Order);
                _context.SaveChanges();
            }
        }

        public void DeleteTheOrder(Orders order)
        {
            
                _context.Orders.Remove(order);
                _context.SaveChanges();
            
        }

        public Orders PickOrder(int id)
        {
           return (_context.Orders.FirstOrDefault(s => s.OrderId == id));
        }
    }
}
