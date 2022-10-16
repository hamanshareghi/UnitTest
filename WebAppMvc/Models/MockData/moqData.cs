namespace WebAppMvc.Models.MockData
{
    public class moqData
    {
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>()
            {
                new Product{Id=1,Description="description1",Name="Iphone14",Price=2500},
                new Product{Id=2,Description="desc2",Name="Iphonex",Price=69800}
            };
            return products;
        }

    }
}
