using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAPI_Libary_Testing.Properties;
using TAPI_Library;

namespace TAPI_Libary_Testing {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private DebugEntry de;
		private void Form1_Load(object sender, EventArgs e) {
			string m = "I am an apple.I am an apple.I am an apple.I am an apple.\nI am an apple.I am an apple.I am an apple.";
			de = new DebugEntry(this, Resources.Apple, "Apple", m, DebugEntryType.MESSAGE, "TIME HERE");
		}
	}
}
