// See https://aka.ms/new-console-template for more information
using RepositoryPattern.Data;
using RepositoryPattern.Domain;
using RepositoryPattern.Services;

ProductService productService = new ProductService();
List<Product> products = productService.GetProducts();
foreach (var item in products)
{
    Console.WriteLine(item);
}