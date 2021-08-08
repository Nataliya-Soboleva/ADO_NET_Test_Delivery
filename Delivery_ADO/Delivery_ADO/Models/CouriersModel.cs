using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery_ADO.Models
{
    public class CouriersModel
    {
       
        public int CourierID { get; private set; }        
        public string FirstName { get; private set; }       
        public string LastName { get; private set; }       
        public DateTime DateOfBirth { get; private set; }        
        public bool AvailabilityRights { get; private set; }
        public string RightsСategory { get; private set; }
        public CouriersModel (int CourierID, string FirstName, string LastName, DateTime DateOfBirth, bool AvailabilityRights, string RightsСategory)
        {
            this.CourierID = CourierID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.AvailabilityRights = AvailabilityRights;
            this.RightsСategory = RightsСategory;
        }

    }
}
