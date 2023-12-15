namespace practical12.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private DataContext context;
        public ProductsController(DataContext ctx)
        {
            context = ctx;
        }        

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return context.Products;
        }

        [HttpGet("{id}")]
        public Product? GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        [HttpPost]
        public void SaveProduct([FromBody] Product product) {
            context.Products.Add(product);
            context.SaveChanges();
        }

        [HttpPut]
        public void UpdateProduct([FromBody] Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        { 
            context.Products.Remove(new Product() { ProductId = id}); 
            context.SaveChanges();
        }
    }

    [Route("")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
