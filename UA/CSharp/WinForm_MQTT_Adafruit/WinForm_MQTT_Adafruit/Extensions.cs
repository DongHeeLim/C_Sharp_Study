using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_MQTT_Adafruit
{
    public static class Extensions
    {
        public static void Error(this Form form, Exception ex) 
        {
            form.Invoke((Action)(() => MessageBox.Show(form, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
        }
    }
}
