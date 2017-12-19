using FontTesting.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontTesting {
	public partial class Form1 : Form {
		private static PrivateFontCollection fonts = new PrivateFontCollection();
		private static Font F;

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			fonts.AddFontFile("Fonts\\UnDotum.ttf");
			F = new Font(fonts.Families[0].Name, 16, FontStyle.Regular, GraphicsUnit.Pixel);
			Log.Font = F;
		}
	}
}
