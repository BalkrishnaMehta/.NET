
namespace practical15.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext context;

        public IEnumerable<Category> Categories;
        public IEnumerable<Supplier> Suppliers;

        public HomeController(DataContext ctx)
        {
            context = ctx;
            Categories = context.Categories.ToList();
            Suppliers = context.Suppliers.ToList();
        }

        public IActionResult Index()
        {
            var products = context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToList();

            return View(products);
        }
        public async Task<IActionResult> Details(int id)
        {
            Product? p = await context.Products.Include(p => p.Category).Include(p => p.Supplier).FirstOrDefaultAsync(p => p.ProductId == id) ?? new Product();
            ProductViewModel model = ViewModelFactory.Details(p);
            return View("ProductEditor", model);
        }

        public IActionResult Create()
        {
            return View("ProductEditor", ViewModelFactory.Create(new Product(), Categories, Suppliers));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = default;
                product.Category = default;
                product.Supplier = default;
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("ProductEditor", ViewModelFactory.Create(product, Categories, Suppliers));
        }

        public async Task<IActionResult> Edit(int id)
        {
            Product? p = await context.Products.FindAsync(id);
            if (p != null)
            {
                ProductViewModel model = ViewModelFactory.Edit(p, Categories, Suppliers);
                return View("ProductEditor", model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Category = default;
                product.Supplier = default;
                context.Products.Update(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View("ProductEditor", ViewModelFactory.Edit(product, Categories, Suppliers));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Product? p = await context.Products.FindAsync(id);
            if (p != null)
            {
                ProductViewModel model = ViewModelFactory.Delete(p, Categories, Suppliers);
                return View("ProductEditor", model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
