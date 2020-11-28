using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        #region Dependency Injection

        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<DeliveryMethod> _dmRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IBasketRepository _basketRepo;

        public OrderService(IGenericRepository<Order> orderRepo, 
            IGenericRepository<DeliveryMethod> dmRepo, 
            IGenericRepository<Product> productRepo,
            IBasketRepository basketRepo
            )
        {
            _basketRepo = basketRepo;
            _productRepo = productRepo;
            _dmRepo = dmRepo;
            _orderRepo = orderRepo;
        }

        #endregion Dependency Injection

        public async Task<Order> CreateOrderAsync(string buyerEmail, 
        int delvieryMethodId, string basketId, Address shippingAddress)
        {
            // Get basket from the repo
            var basket = await _basketRepo.GetBasketAsync(basketId);
            // Get items from the product repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _productRepo.GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, 
                    productItem.Name, productItem.PictureUrl);

                var orderItem = new OrderItem(itemOrdered, productItem.Price,
                    item.Quantity);
                items.Add(orderItem);
            }
            // Get delivery method from repo
            var deliveryMethod = await _dmRepo.GetByIdAsync(delvieryMethodId);

            // calculate subtotal based on item price from product repo
            var subtotal = items.Sum(item => item.Price * item.Quantity);

            // create order
            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal);

            // TODO: save to db
            
            // return order
            return order; 
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {

        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {

        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {

        }
    }
}