namespace AvoidUsingReflection.Benchmarks;
public class ProductsCreationBenchmark
{
    [Benchmark]
    public void CreateProductWithoutReflection()
    {
        var product = new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 1236.5M
        };
    }

    [Benchmark]
    public void CreateProductWithReflection()
    {
        var productObjType = typeof(Product);
        var obj = Activator.CreateInstance(productObjType);

        productObjType.GetProperty("Id").SetValue(obj, 1);
        productObjType.GetProperty("Name").SetValue(obj, "Laptop");
        productObjType.GetProperty("Price").SetValue(obj, 1236.5M);
    }

}
