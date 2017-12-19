using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAPI_Library.Properties;

namespace TAPI_Library {
	public class DebugEntry {
		Panel master;

		PictureBox icon;

		FlowLayoutPanel textPanel;

		Label nameLabel;
		Label name;
		Label messageLabel;
		RichTextBox message;

		public DebugEntry(Control P, Image img, string name, string mess) {
			master = new Panel() {
				Parent = P,
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				MinimumSize = new Size(256, 128),
				Size = new Size(128, 64),
				BorderStyle = BorderStyle.Fixed3D
			};

			icon = new PictureBox() {
				Parent=master,
				Image=img,
				Size=img.Size,
				Location=new Point(10,10),
			};

			textPanel = new FlowLayoutPanel() {
				Parent=master,
				Location=new Point(img.Width+10, 0+10),
				BorderStyle= BorderStyle.Fixed3D
			};

			nameLabel = new Label() {
				Parent=textPanel,
				Text="Name: "
			};
			this.name = new Label() {
				Parent=textPanel,
				Text=name,
				BorderStyle= BorderStyle.FixedSingle,
				Enabled=false
			};
			messageLabel = new Label() {
				Parent = textPanel,
				Text="Message: "
			};
			message = new RichTextBox() {
				Parent=textPanel,
				Text=mess,
				Multiline=true,
				Enabled=false
			};
			//master.Size = new Size(img.Width+textPanel.Width+2*10, Math.Max(img.Height, textPanel.Height)+2*10);
		}
	}
}
