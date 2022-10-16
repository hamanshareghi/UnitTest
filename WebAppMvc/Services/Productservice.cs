using WebAppMvc.Models;

namespace WebAppMvc.Services
{
    public class Productservice : IProductService
    {
        DataContext _context;
        public Productservice(DataContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();    

        }

        public IEnumerable<Product> GetAll()
        {
            var data = _context.Products.ToList();
            return data;
        }

        public Product GetById(long id)
        {
            var data = _context.Products.FirstOrDefault(s => s.Id == id);
            return data;
        }

        public void Remove(long id)
        {
            var data = _context.Products.FirstOrDefault(s => s.Id == id);
            _context.Products.Remove(data);
            _context.SaveChanges();

        }
    }
}
