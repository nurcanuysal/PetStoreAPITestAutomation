using System;
using PetStoreAPI.Modals;
using PetStoreAPI.Helpers;

namespace PetStoreTest.Helpers
{
	public class OrderHelpers
	{
        public static Order PrepareOrder(int petId, string shipDate, OrderStatus orderStatus, int quantity, bool complete)
        {
            return new Order()
            {
                Id = int.Parse(Randomizer.GenerateRandomId()),
                PetId = petId,
                Quantity = quantity,
                ShipDate = shipDate,
                Status = orderStatus.ToString(),
                Complete = complete
            };
        }

        public Order CreateOrder(int petId, string shipDate, OrderStatus orderStatus, int quantity, bool complete, Order order = null)
        {
            var orderToCreate = order;
            if (orderToCreate == null) orderToCreate = PrepareOrder(petId, shipDate, orderStatus, quantity, complete);
            return orderToCreate;
        }
    }
}

