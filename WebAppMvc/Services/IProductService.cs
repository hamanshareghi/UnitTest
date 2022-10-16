using WebAppMvc.Models;

namespace WebAppMvc.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(long id);
        Product Add(Product product);
        void Remove(long id);
    }
}
