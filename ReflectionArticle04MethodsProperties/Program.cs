using System.Reflection;

namespace ReflectionArticle04MethodsProperties
{
    /// <summary>
    /// Demonstrates reflection concepts for invoking methods and accessing properties.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Load the external assembly containing the classes
            Assembly externalAssembly = Assembly.Load("ReflectionLibrary");

            // Get the types from the loaded assembly
            Type productType = externalAssembly.GetType("ReflectionLibrary.Product");
            Type orderType = externalAssembly.GetType("ReflectionLibrary.Order");
            Type orderProcessorType = externalAssembly.GetType("ReflectionLibrary.OrderProcessor");

            // Create instances of Product, Order, and OrderProcessor using reflection
            object product1 = CreateProduct("Sample Product 1", 9.99);
            object product2 = CreateProduct("Sample Product 2", 19.99);

            object orderedProductsList = CreateList(productType);
            MethodInfo addMethod = orderedProductsList.GetType().GetMethod("Add");
            addMethod.Invoke(orderedProductsList, new object[] { product1 });
            addMethod.Invoke(orderedProductsList, new object[] { product2 });

            object orderInstance = CreateOrder(123, orderedProductsList);

            object orderProcessorInstance = Activator.CreateInstance(orderProcessorType);

            // List the ordered products
            Console.WriteLine("Ordered Products:");
            foreach (var product in (IEnumerable<object>)orderedProductsList)
            {
                string productName = (string)productType.GetProperty("Name").GetValue(product);
                double productPrice = (double)productType.GetProperty("Price").GetValue(product);
                Console.WriteLine($"{productName} - ${productPrice}");
            }

            // Invoke method to calculate total price using reflection
            MethodInfo calculateTotalPriceMethod = orderProcessorType.GetMethod("CalculateTotalPrice");
            double totalPrice = (double)calculateTotalPriceMethod.Invoke(orderProcessorInstance, new object[] { orderInstance });
            Console.WriteLine("\nTotal Price: $" + totalPrice);

            // Error handling
            try
            {
                // Invoke a method that doesn't exist (for example purposes)
                MethodInfo nonExistentMethod = orderType.GetMethod("NonExistentMethod");
                nonExistentMethod.Invoke(orderInstance, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Creates a product instance using reflection.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <param name="price">Price of the product.</param>
        /// <returns>The created product instance.</returns>
        static object CreateProduct(string name, double price)
        {
            Assembly externalAssembly = Assembly.Load("ReflectionLibrary");
            Type productType = externalAssembly.GetType("ReflectionLibrary.Product");
            object product = Activator.CreateInstance(productType);
            productType.GetProperty("Name").SetValue(product, name);
            productType.GetProperty("Price").SetValue(product, price);
            return product;
        }

        /// <summary>
        /// Creates a List instance of the specified element type using reflection.
        /// </summary>
        /// <param name="elementType">Type of the list elements.</param>
        /// <returns>The created List instance.</returns>
        static object CreateList(Type elementType)
        {
            Type listType = typeof(List<>).MakeGenericType(elementType);
            return Activator.CreateInstance(listType);
        }

        /// <summary>
        /// Creates an order instance using reflection.
        /// </summary>
        /// <param name="orderId">ID of the order.</param>
        /// <param name="orderedProductsList">List of ordered products.</param>
        /// <returns>The created order instance.</returns>
        static object CreateOrder(int orderId, object orderedProductsList)
        {
            Assembly externalAssembly = Assembly.Load("ReflectionLibrary");
            Type orderType = externalAssembly.GetType("ReflectionLibrary.Order");
            object orderInstance = Activator.CreateInstance(orderType);
            orderType.GetProperty("OrderId").SetValue(orderInstance, orderId);
            orderType.GetProperty("OrderedProducts").SetValue(orderInstance, orderedProductsList);
            return orderInstance;
        }
    }
}
