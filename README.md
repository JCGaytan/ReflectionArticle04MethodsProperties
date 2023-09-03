# Reflection Article: Invoking Methods and Properties

This repository contains a C# console application that demonstrates how to use reflection to dynamically invoke methods and access properties. The application covers the following key points:

## Key Points

### Dynamic Method Invocation using Reflection
The program dynamically invokes methods from classes using reflection.

### Handling Method Overloads and Parameter Types
While the example does not include overloaded methods, similar concepts apply when dealing with multiple method signatures.

### Invoking Static and Instance Methods Dynamically
The example showcases invoking instance methods, and you can extend it to invoke static methods.

### Getting and Setting Property Values through Reflection
The code illustrates how to retrieve and modify property values using reflection.

### Error Handling and Performance Considerations
The application includes basic error handling using try-catch blocks, and it mentions the performance considerations related to reflection.

## Usage

1. **Load External Assembly:**
   The program loads an external assembly named "ReflectionLibrary," which contains the classes used in the reflection example.

2. **Create Instances:**
   Using reflection, instances of classes (Product, Order, OrderProcessor) are created dynamically.

3. **Invoke Methods:**
   The example demonstrates invoking methods dynamically, such as the `CalculateTotalPrice` method.

4. **Access Properties:**
   Properties (Name, Price) of products are accessed and displayed using reflection.

5. **Error Handling:**
   An error handling example is provided when invoking a non-existent method.

## Code Snippets

### Creating Product Instances

```csharp
object product1 = CreateProduct("Sample Product 1", 9.99);
object product2 = CreateProduct("Sample Product 2", 19.99);
```

### Dynamically Creating a List

```csharp
object orderedProductsList = CreateList(productType);
MethodInfo addMethod = orderedProductsList.GetType().GetMethod("Add");
addMethod.Invoke(orderedProductsList, new object[] { product1 });
addMethod.Invoke(orderedProductsList, new object[] { product2 });
```

### Dynamically Creating an Order

```csharp
object orderInstance = CreateOrder(123, orderedProductsList);
```

### Invoking Method using Reflection

```csharp
MethodInfo calculateTotalPriceMethod = orderProcessorType.GetMethod("CalculateTotalPrice");
double totalPrice = (double)calculateTotalPriceMethod.Invoke(orderProcessorInstance, new object[] { orderInstance });
```

### Accessing Property Values

```csharp
foreach (var product in (IEnumerable<object>)orderedProductsList)
{
    string productName = (string)productType.GetProperty("Name").GetValue(product);
    double productPrice = (double)productType.GetProperty("Price").GetValue(product);
    Console.WriteLine($"{productName} - ${productPrice}");
}
```

### Error Handling with Reflection

```csharp
try
{
    MethodInfo nonExistentMethod = orderType.GetMethod("NonExistentMethod");
    nonExistentMethod.Invoke(orderInstance, null);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
```

## Running the Application

1. Build and run the console application.
2. The application will demonstrate the concepts discussed above through reflection examples.

## License

This project is licensed under the [MIT License](LICENSE.txt).
# Reflection Article: Invoking Methods and Properties

Este repositorio contiene una aplicación de consola en C# que demuestra cómo usar la reflexión para invocar métodos y acceder a propiedades de manera dinámica. La aplicación abarca los siguientes puntos clave:

## Puntos Clave

### Invocación Dinámica de Métodos usando Reflexión
El programa invoca dinámicamente métodos de clases utilizando reflexión.

### Manejo de Sobrecargas de Métodos y Tipos de Parámetros
Aunque el ejemplo no incluye métodos sobrecargados, conceptos similares se aplican cuando se tratan con múltiples firmas de métodos.

### Invocación Dinámica de Métodos Estáticos e Instancia
El ejemplo muestra cómo invocar métodos de instancia, y puedes extenderlo para invocar métodos estáticos.

### Obtención y Configuración de Valores de Propiedad mediante Reflexión
El código ilustra cómo recuperar y modificar valores de propiedades utilizando reflexión.

### Manejo de Errores y Consideraciones de Rendimiento
La aplicación incluye manejo básico de errores mediante bloques try-catch y menciona las consideraciones de rendimiento relacionadas con la reflexión.

## Uso

1. **Cargar Ensamble Externo:**
   El programa carga un ensamble externo llamado "ReflectionLibrary", que contiene las clases utilizadas en el ejemplo de reflexión.

2. **Crear Instancias:**
   Usando reflexión, se crean dinámicamente instancias de clases (Product, Order, OrderProcessor).

3. **Invocar Métodos:**
   El ejemplo demuestra la invocación dinámica de métodos, como el método `CalculateTotalPrice`.

4. **Acceder a Propiedades:**
   Las propiedades (Nombre, Precio) de los productos se acceden y se muestran utilizando reflexión.

5. **Manejo de Errores:**
   Se proporciona un ejemplo de manejo de errores al invocar un método que no existe.

## Fragmentos de Código

### Crear Instancias de Producto

```csharp
object product1 = CreateProduct("Sample Product 1", 9.99);
object product2 = CreateProduct("Sample Product 2", 19.99);
```

### Crear una Lista Dinámicamente

```csharp
object orderedProductsList = CreateList(productType);
MethodInfo addMethod = orderedProductsList.GetType().GetMethod("Add");
addMethod.Invoke(orderedProductsList, new object[] { product1 });
addMethod.Invoke(orderedProductsList, new object[] { product2 });
```

### Crear una Orden Dinámicamente

```csharp
object orderInstance = CreateOrder(123, orderedProductsList);
```

### Invocar un Método usando Reflexión

```csharp
MethodInfo calculateTotalPriceMethod = orderProcessorType.GetMethod("CalculateTotalPrice");
double totalPrice = (double)calculateTotalPriceMethod.Invoke(orderProcessorInstance, new object[] { orderInstance });
```

### Acceder a Valores de Propiedad

```csharp
foreach (var product in (IEnumerable<object>)orderedProductsList)
{
    string productName = (string)productType.GetProperty("Name").GetValue(product);
    double productPrice = (double)productType.GetProperty("Price").GetValue(product);
    Console.WriteLine($"{productName} - ${productPrice}");
}
```

### Manejo de Errores con Reflexión

```csharp
try
{
    MethodInfo nonExistentMethod = orderType.GetMethod("NonExistentMethod");
    nonExistentMethod.Invoke(orderInstance, null);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
```

## Ejecutar la Aplicación

1. Compila y ejecuta la aplicación de consola.
2. La aplicación demostrará los conceptos discutidos anteriormente a través de ejemplos de reflexión.

## Licencia

Este proyecto está licenciado bajo la [Licencia MIT](LICENSE.txt).

# Reflection Article: Invoking Methods and Properties

Ce référentiel contient une application de console en C# qui démontre comment utiliser la réflexion pour dynamiquement invoquer des méthodes et accéder à des propriétés. L'application couvre les points clés suivants :

## Points Clés

### Invocation Dynamique de Méthodes en utilisant la Réflexion
Le programme invoque dynamiquement des méthodes à partir de classes en utilisant la réflexion.

### Gestion des Surcharges de Méthodes et des Types de Paramètres
Bien que l'exemple n'inclue pas de méthodes surchargées, des concepts similaires s'appliquent lors de la manipulation de signatures de méthodes multiples.

### Invocation Dynamique de Méthodes Statiques et d'Instance
L'exemple présente l'invocation de méthodes d'instance, et vous pouvez l'étendre pour invoquer des méthodes statiques.

### Obtention et Définition de Valeurs de Propriété à travers la Réflexion
Le code illustre comment récupérer et modifier des valeurs de propriété en utilisant la réflexion.

### Gestion des Erreurs et Considérations de Performance
L'application inclut une gestion basique des erreurs à l'aide de blocs try-catch, et elle mentionne les considérations de performance liées à la réflexion.

## Utilisation

1. **Charger l'Assemblage Externe :**
   Le programme charge un assemblage externe nommé "ReflectionLibrary," qui contient les classes utilisées dans l'exemple de réflexion.

2. **Créer des Instances :**
   En utilisant la réflexion, des instances de classes (Product, Order, OrderProcessor) sont créées dynamiquement.

3. **Invoquer des Méthodes :**
   L'exemple démontre l'invocation dynamique de méthodes, telles que la méthode `CalculateTotalPrice`.

4. **Accéder à des Propriétés :**
   Les propriétés (Nom, Prix) des produits sont accédées et affichées en utilisant la réflexion.

5. **Gestion des Erreurs :**
   Un exemple de gestion des erreurs est fourni lors de l'invocation d'une méthode qui n'existe pas.

## Extraits de Code

### Création d'Instances de Produit

```csharp
object product1 = CreateProduct("Sample Product 1", 9.99);
object product2 = CreateProduct("Sample Product 2", 19.99);
```

### Création Dynamique d'une Liste

```csharp
object orderedProductsList = CreateList(productType);
MethodInfo addMethod = orderedProductsList.GetType().GetMethod("Add");
addMethod.Invoke(orderedProductsList, new object[] { product1 });
addMethod.Invoke(orderedProductsList, new object[] { product2 });
```

### Création Dynamique d'une Commande

```csharp
object orderInstance = CreateOrder(123, orderedProductsList);
```

### Invoquer une Méthode en utilisant la Réflexion

```csharp
MethodInfo calculateTotalPriceMethod = orderProcessorType.GetMethod("CalculateTotalPrice");
double totalPrice = (double)calculateTotalPriceMethod.Invoke(orderProcessorInstance, new object[] { orderInstance });
```

### Accéder aux Valeurs de Propriété

```csharp
foreach (var product in (IEnumerable<object>)orderedProductsList)
{
    string productName = (string)productType.GetProperty("Name").GetValue(product);
    double productPrice = (double)productType.GetProperty("Price").GetValue(product);
    Console.WriteLine($"{productName} - ${productPrice}");
}
```

### Gestion des Erreurs avec la Réflexion

```csharp
try
{
    MethodInfo nonExistentMethod = orderType.GetMethod("NonExistentMethod");
    nonExistentMethod.Invoke(orderInstance, null);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
```

## Exécution de l'Application

1. Compilez et exécutez l'application de console.
2. L'application démontrera les concepts discutés ci-dessus à travers des exemples de réflexion.

## Licence

Ce projet est sous licence [Licence MIT](LICENSE.txt).
