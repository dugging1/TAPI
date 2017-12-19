using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAPI_Library {
	/// <summary>
	/// Used for easy display of the entries(logging UI element).
	/// </summary>
	public class DebugEntryController:Panel {
		List<DebugEntry> Entries = new List<DebugEntry>();

		public DebugEntryController(Control P) {
			Parent=P;
			Dock = DockStyle.Fill;
			VScroll = true;
			AutoScroll = true;
		}

		public void AddEntry(DebugEntry e) {
			Entries.Add(e);

		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			int y = AutoScrollPosition.Y;
			for (int i = 0; i < Entries.Count; i++) {
				Entries[i].Location = new System.Drawing.Point(0, y);
				y+=Entries[i].Size.Height+5;
			}
		}
	}
}
