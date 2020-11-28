namespace Core.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int productItemId, int productName, 
        int pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        // snapshot of the product ordered
        public int ProductItemId { get; set; }
        public int ProductName { get; set; }
        public int PictureUrl { get; set; }
    }
}