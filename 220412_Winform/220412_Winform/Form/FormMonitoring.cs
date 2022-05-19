using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _220412_Winform
{
    public partial class FormMonitoring : Form
    {
        public FormMonitoring()
        {
            InitializeComponent();
        }

        private void fileMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColors());
        }
    }

    class CustomProfessionalColors : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin
        {
            get
            {
                return Color.FromArgb(35, 35, 35);
            }
        }
        public override Color MenuStripGradientEnd
        {
            get
            {
                return Color.FromArgb(35, 35, 35);
            }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return Color.FromArgb(20, 20, 20);
            }
        }
        public override Color MenuItemPressedGradientMiddle
        {
            get
            {
                return Color.FromArgb(20, 20, 20);
            }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return Color.FromArgb(20, 20, 20);
            }
        }
        public override Color MenuBorder
        {
            get
            {
                return Color.FromArgb(20, 20, 20);
            }
        }
        public override Color MenuItemSelected
        {
            get
            {
                return Color.FromArgb(50, 50, 50);
            }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(50, 50, 50);
            }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(50, 50, 50);
            }
        }
        public override Color MenuItemBorder
        {
            get
            {
                return Color.FromArgb(35, 35, 35);
            }
        }

        public override Color ToolStripDropDownBackground   // 테두리 3면
        {
            get
            {
                return Color.Black;
            }
        }
        public override Color ImageMarginGradientBegin      // 테두리 좌측 1면
        {
            get
            {
                return Color.Black;
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Color.Black;
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.Black;
            }
        }


    }
}
