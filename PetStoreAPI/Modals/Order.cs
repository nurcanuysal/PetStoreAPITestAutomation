using System;
using Newtonsoft.Json;

namespace PetStoreAPI.Modals
{
        public class Order
        {
            public long Id { get; set; }

            public int PetId { get; set; }

            public int Quantity { get; set; }

            public string? ShipDate { get; set; }

            public string? Status { get; set; }

            public bool Complete { get; set; }
        }

        public enum OrderStatus
        {
            placed,
            approved,
            delivered
        }
   
}

