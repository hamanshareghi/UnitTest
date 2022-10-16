namespace WebAppMvc.Models.MockData
{
    public class moqData
    {
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>()
            {
                new Product{Id=1,Description="description1",Name="Iphone14",Price=2500}
            };
            return products;
        }

    }
}
