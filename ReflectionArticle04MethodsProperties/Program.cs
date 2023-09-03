using System.Reflection;

namespace ReflectionArticle04MethodsProperties
{
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
            object product1 = Activator.CreateInstance(productType);
            productType.GetProperty("Name").SetValue(product1, "Sample Product 1");
            productType.GetProperty("Price").SetValue(product1, 9.99);

            object product2 = Activator.CreateInstance(productType);
            productType.GetProperty("Name").SetValue(product2, "Sample Product 2");
            productType.GetProperty("Price").SetValue(product2, 19.99);

            // Create a list of products
            List<object> orderedProducts = new List<object> { product1, product2 };

            // Create an instance of Order
            object orderInstance = Activator.CreateInstance(orderType);
            orderType.GetProperty("OrderId").SetValue(orderInstance, 123);

            // Create a List<Product> instance and add the Product objects
            Type listProductType = typeof(List<>).MakeGenericType(productType);
            object orderedProductsList = Activator.CreateInstance(listProductType);
            MethodInfo addMethod = listProductType.GetMethod("Add");
            addMethod.Invoke(orderedProductsList, new object[] { product1 });
            addMethod.Invoke(orderedProductsList, new object[] { product2 });

            orderType.GetProperty("OrderedProducts").SetValue(orderInstance, orderedProductsList);

            object orderProcessorInstance = Activator.CreateInstance(orderProcessorType);

            // List the ordered products
            Console.WriteLine("Ordered Products:");
            foreach (var product in orderedProductsList as IEnumerable<object>)
            {
                string productName = (string)productType.GetProperty("Name").GetValue(product);
                double productPrice = (double)productType.GetProperty("Price").GetValue(product);
                Console.WriteLine($"{productName} - ${productPrice}");
            }

            // Invoke method to calculate total price using reflection
            MethodInfo calculateTotalPriceMethod = orderProcessorType.GetMethod("CalculateTotalPrice");
            double totalPrice = (double)calculateTotalPriceMethod.Invoke(orderProcessorInstance, new object[] { orderInstance });
            Console.WriteLine("\nTotal Price: $" + totalPrice);

            Console.ReadLine();
        }
    }
}
