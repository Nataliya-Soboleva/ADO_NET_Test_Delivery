using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_ADO.Enums
{
   public enum OrderStatuses
    {
        Received=1,
        DeliveredOnTheRoad=2,
        Delivered=3,
        CancellationOrRefund= 4
    }
}
