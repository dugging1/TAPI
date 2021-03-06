﻿using System;
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

		private DebugEntryController dec;
		private void Form1_Load(object sender, EventArgs e) {
			dec = new DebugEntryController(this, 4);
			dec.BackColor = Color.DarkGray;

			string m = "I am an apple.I am an apple.I am an apple.I am an apple.\n\n\n\nI am an apple.I am an apple.I am an apple.";
			dec.AddEntry(new DebugEntry(dec, Resources.Apple, "Apple", m, DebugEntryType.MESSAGE, "TIME HERE", "LOCATION HERE"));
		}

		private void button1_Click(object sender, EventArgs e) {
			string m = "I am an apple.I am an apple.I am an apple.I am an apple.\n\n\n\nI am an apple.I am an apple.I am an apple.";
			dec.AddEntry(new DebugEntry(dec, Resources.Apple, "Apple", Resources.Apple, DebugEntryType.MESSAGE, "TIME HERE", "LOCATION HERE"));
			dec.Invalidate();
			dec.Update();
		}
	}
}
