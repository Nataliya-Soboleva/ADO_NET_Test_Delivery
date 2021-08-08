using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_ADO.Models
{
    public class OrdersStatusModel
    {
       
        public int OrderStatusID { get;private set; }        
        public string OrderStatusName { get; private set; }
        public OrdersStatusModel(int OrderStatusID, string OrderStatusName)
        {
            this.OrderStatusID = OrderStatusID;
            this.OrderStatusName = OrderStatusName;
           
        }
    }
}
