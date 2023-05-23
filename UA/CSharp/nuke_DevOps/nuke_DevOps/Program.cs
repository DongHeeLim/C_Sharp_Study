using System.Security.Cryptography.X509Certificates;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("nuke_DevOps");

        try
        {
            StreamWriter sw = new StreamWriter("a.txt", true, Encoding.UTF8);   // append

            string datePatt = @"M/d/yyyy hh:mm:ss tt";
            DateTime date = DateTime.Now;
            string dateString = date.ToString(datePatt, new System.Globalization.CultureInfo("en-US"));

            sw.WriteLine($"{DateTime.UtcNow}");
            sw.WriteLine($"{dateString}");
            sw.Close();

            Console.WriteLine("=========================================================");

            StreamReader sr = new StreamReader("a.txt");

            while (sr.Peek() >= 0)
            {
                Console.WriteLine($"{sr.ReadLine()}");
            }

            sr.Close();

            //FileStream fsa = File.Create("a.txt");

            FileInfo file = new FileInfo("b.txt");
            FileStream fsb = file.Create();

            fsb.Close();

            Console.WriteLine("=========================================================");

            string folderName = @"D:\TextFolder";
            string pathString = Path.Combine(folderName, "SubFolder");

            if (Directory.Exists(pathString) == false)
            {
                Directory.CreateDirectory(pathString);
                Console.WriteLine($"Create -> {folderName} {pathString}");
            }
            else 
            {
                Console.WriteLine($"{pathString} already exists");
            }
            
            Console.WriteLine("=========================================================");

            File.Copy("a.txt", "b.txt", true);  // overwrite

            if (File.Exists("a.txt"))
            {
                File.Move("a.txt", Path.Combine(pathString, "a.txt"), true);  // overwrite

            }
            else 
            {
                Console.WriteLine("a.txt does not exist");
            }
            //fsa.Close();
        }
        catch (Exception ex) 
        {
            Console.WriteLine ("Exception:" + ex.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }

    }
}