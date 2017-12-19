using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAPI_Library {
	public class DebugEntry {
		Panel master;

		PictureBox pictureBox;

		FlowLayoutPanel textPanel;
		Label name;
		Label message;

		public DebugEntry(Control P, Image img, string name, string mess) {
			master = new Panel() {
				Parent = P
			};

			pictureBox = new PictureBox() {
				Parent=master,
				Image=img
			};

			textPanel = new FlowLayoutPanel() {
				Parent=master,
				Location=new Point(img.Width, 0)
			};

			this.name = new Label() {
				Parent=textPanel,
				Text=name
			};
			message = new Label() {
				Parent=textPanel,
				Text=mess
			};
			master.Size = new Size(img.Width+textPanel.Width, Math.Max(img.Height, textPanel.Height));
		}
	}
}
