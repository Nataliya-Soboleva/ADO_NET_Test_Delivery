using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_ADO.Models
{
    public class OrdersModel
    {      
        public int OrderID { get; private set; }        
        public string AddressTo { get; private set; }       
        public string DescriptionOfCargo { get; private set; }       
        public DateTime OrderDate { get; private set; }       
        public double Price { get; private set; }       
        public int CourierID { get; private set; }       
        public int StatusID { get; private set; }
        public OrdersModel(int OrderID, string AddressTo, string DescriptionOfCargo, DateTime OrderDate, double Price, int CourierID, int StatusID)
        {
            this.OrderID = OrderID;
            this.AddressTo = AddressTo;
            this.DescriptionOfCargo = DescriptionOfCargo;
            this.OrderDate = OrderDate;
            this.Price = Price;
            this.CourierID = CourierID;
            this.StatusID = StatusID;
        }

    }

}
