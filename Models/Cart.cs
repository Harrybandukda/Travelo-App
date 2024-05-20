using bookingPlatform.Models;
using System.ComponentModel.DataAnnotations;

namespace COMP2139_Assignment1.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public string UserId { get; set; }  // Reference to the User
        public ApplicationUser User { get; set; }  // Navigation property

        public List<FlightCart> FlightCarts { get; set; }
        public List<Hotels> Hotels { get; set; }
        public List<Cars> Cars { get; set; }
    }


    public class FlightCart
    {
        public int FlightID { get; set; }
        public Flights Flight { get; set; }

        public int CartID { get; set; }
        public Cart Cart { get; set; }
    }
}
