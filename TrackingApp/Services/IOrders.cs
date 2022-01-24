using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackingApp.Models;

namespace TrackingApp.Services
{
    public interface IOrders
    {
        public IEnumerable<Orders> AllOrders();
        public Orders AddOrder(int? id);
        public void AddOrder(Orders order, int? id);
        public void DeleteOrder(int? id);
        public Orders PickOrder(int id);
        public void DeleteTheOrder(Orders order);
        public Orders OrderDetails(int Id);
    }
}
