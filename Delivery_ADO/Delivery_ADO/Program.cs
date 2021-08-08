using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Delivery_ADO.Datalayer;
using Delivery_ADO.Models;
using Delivery_ADO.Enums;

namespace Delivery_ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            _DL.Order.AllByStatus(OrderStatuses.Delivered);
            List<OrdersModel> ordersByStatus = _DL.Order.AllByStatusList(OrderStatuses.Received);

            OrdersModel newOrd = new OrdersModel(0,"Leonova,273", "Food", new DateTime(2020,8,20),74.00,6,4);

            if (_DL.Order.InsertOrder(newOrd) > 0)
            {
                Console.WriteLine("Order Added");
            }
            else
            {
                Console.WriteLine("Error Added");
            }

        }
    }
}
