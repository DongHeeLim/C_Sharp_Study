using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace WinForm_MQTT_Client.Helpers
{
    public static class ObjectExtension
    {
        public static TObject DumpToConsole<TObject>( this TObject @object) 
        {
            //StringHandler stringHandler = StringHandler.Instance();

            var output = "NULL";
            if (@object != null)
            {
                output = JsonSerializer.Serialize(@object, new JsonSerializerOptions 
                {
                    WriteIndented = true
                }); 

            }
            Console.WriteLine($"[{@object?.GetType().Name}]:\r\n{output}");
            //stringHandler.AddText( output );
            return @object;

        }

    }
}
