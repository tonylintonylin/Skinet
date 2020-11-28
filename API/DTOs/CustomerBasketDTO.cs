using System.Collections.Generic;

namespace API.DTOs
{
    public class CustomerBasketDTO
    {
        public string Id { get; set; }
        public List<BasketItemDTO> Items { get; set; }
    }
}