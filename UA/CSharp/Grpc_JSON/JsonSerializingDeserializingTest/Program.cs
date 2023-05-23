//using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class Product
{
    public string name { get; set; }
    public DateTime Expiry { get; set; }
}

class Program
{

    static async Task Main(string[] arge)
    {
        Product product= new Product();
        product.name = "Apple";
        product.Expiry = DateTime.Now;

        string json = JsonConvert.SerializeObject(product);

        Console.WriteLine(json);

        string deserialized_json = json;

        Product lastProduct = JsonConvert.DeserializeObject<Product>(deserialized_json);

        string lastProductName = lastProduct.name;
        DateTime dateTime = lastProduct.Expiry;

        Console.WriteLine(lastProductName + " || " + dateTime);



    }
}