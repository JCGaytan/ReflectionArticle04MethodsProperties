namespace ReflectionLibrary
{
    /// <summary>
    /// A class to process orders and calculate total prices.
    /// </summary>
    public class OrderProcessor
    {
        /// <summary>
        /// Calculates the total price of an order.
        /// </summary>
        public double CalculateTotalPrice(Order order)
        {
            double totalPrice = 0;
            foreach (var product in order.OrderedProducts)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }
    }
}
