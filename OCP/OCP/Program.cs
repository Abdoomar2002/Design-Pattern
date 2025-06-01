using static System.Console;
namespace OCP 
{
    public enum Color
    {
        Red,
        Green,
        Blue
    }
    public enum Size
    {
        Small,
        Medium,
        Large
    }
    public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public Product(string name, Color color, Size size)
        {
            Name = name;
            Color = color;
            Size = size;
        }
    }
    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);
    }
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }
    public class ColorSpecification : ISpecification<Product>
    {
        private readonly Color _color;
        public ColorSpecification(Color color)
        {
            _color = color;
        }
        public bool IsSatisfied(Product item)
        {
            return item.Color == _color;
        }
    }
    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size _size;
        public SizeSpecification(Size size)
        {
            _size = size;
        }
        public bool IsSatisfied(Product item)
        {
            return item.Size == _size;
        }
    }
    public class ColorAndSizeSpecification : ISpecification<Product>
    {
        private readonly Color _color;
        private readonly Size _size;
        public ColorAndSizeSpecification(Color color, Size size)
        {
            _color = color;
            _size = size;
        }
        public bool IsSatisfied(Product item)
        {
            return item.Color == _color && item.Size == _size;
        }
    }
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
        {
            foreach (var item in items)
            {
                if (specification.IsSatisfied(item))
                {
                    yield return item;
                }
            }
        }
    }
    public class ProductFilter
    {
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var product in products)
            {
                if (product.Color == color)
                {
                    yield return product;
                }
            }
        }
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var product in products)
            {
                if (product.Size == size)
                {
                    yield return product;
                }
            }
        }
        public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products, Color color, Size size)
        {
            foreach (var product in products)
            {
                if (product.Color == color && product.Size == size)
                {
                    yield return product;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
          Product p1= new Product("Apple", Color.Red, Size.Small);
            Product p2= new Product("Banana", Color.Green, Size.Medium);
            Product p3= new Product("Cherry", Color.Red, Size.Large);
            Product[] products = { p1, p2, p3 };
            var filter = new BetterFilter();
            var filtersItem = new ColorAndSizeSpecification(Color.Green, Size.Medium);
            foreach (var product in filter.Filter(products,filtersItem))
            {
                WriteLine($"Product: {product.Name}, Color: {product.Color}, Size: {product.Size}");
            }
        }
    }
}
