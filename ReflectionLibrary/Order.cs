namespace ReflectionLibrary
{
    /// <summary>
    /// Represents an order containing an order ID and a list of ordered products.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the ID of the order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the list of ordered products associated with the order.
        /// </summary>
        public List<Product> OrderedProducts { get; set; }
    }
}
