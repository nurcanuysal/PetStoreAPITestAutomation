using System;
using PetStoreAPI.Models;
using System.Net;
using PetStoreAPI.Functions;
using PetStoreTest.Helpers;
using PetStoreAPI.Modals;
using FluentAssertions;

namespace PetStoreTest.FunctionsTest.OrderFunctionsTest
{
	public class OrderFunctionsTests
	{
        [Test]
        public void VerifyPetInventoryOrderStatus()
        {
            var orderFunctions = new OrderFunctions();
            var pet = PetHelpers.PreparePetData("Cocoa", PetStatus.available);

            var order = OrderHelpers.PrepareOrder(pet.Id, DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff+00:00"), OrderStatus.delivered, 1, true);
            order.Complete.Should().BeTrue();

            var responseOrder = new Response<Order>();
            var response = orderFunctions.PetInventoryByStatus();
            var getResponse = responseOrder.GetResponseContent<PetInventoryStatus>(response);

            //Assert
            getResponse.Approved.Should().BeGreaterThan(0);
        }

        public void OrderCRUDTest()
        {
            
            var pet = PetHelpers.PreparePetData("Jelly", PetStatus.available);
            var orderCreated = OrderHelpers.PrepareOrder(pet.Id, DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff+00:00"), OrderStatus.placed, 1, true);
            orderCreated.Complete.Should().BeTrue();
            var orderFunctions = new OrderFunctions();
            var responseOrder = new Response<Order>();

            var addResponse = orderFunctions.PlaceAnOrderForAPet(orderCreated);
            var newAddedOrder = responseOrder.GetResponseContent<Pet>(addResponse);
            var getResponse = orderFunctions.FindPurchaseOrderById(newAddedOrder.Id);
            var newAddedOrderData = responseOrder.GetResponseContent<Pet>(getResponse);

            //Assert
            newAddedOrderData.Id.Should().Be(orderCreated.Id);

            orderFunctions.DeletePurchaseOrderById(orderCreated.Id, HttpStatusCode.OK);
        }
    }
}

