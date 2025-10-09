public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private string _orderId; // Added feature: unique order ID

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
        _orderId = Guid.NewGuid().ToString().Substring(0, 8); // Generate a short unique order ID
    }

    public void SetProduct(string name, int productId, double price, int quantity)
    {
        Product product = new Product(name, productId, price, quantity);
        _products.Add(product);
    }

    public double TotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        // Add shipping cost: $5 for USA, $35 for non-USA
        total += _customer.IsUSA() ? 5 : 35;
        return total;
    }

    public string ShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetAddress()}";
    }

    public string ProductLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += $"Product: {product.GetName()}, ID: {product.GetProductId()}\n";
        }
        return label;
    }

    public string GetOrderId()
    {
        return _orderId;
    }

    // Added feature: unique order ID to track orders, displayed in output
}