using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAPI_Library.Helpers;
using TAPI_Library.Properties;

namespace TAPI_Library {
	public enum DebugEntryType { INFO, WARNING, ERROR, MESSAGE }
	public class DebugEntry {
		static readonly string[] EntryTypeConversion = new string[] { "INFO", "WARNING", "ERROR", "MESSAGE" };

		const int separationDistY = 16;
		const int separationDistX = 10;

		Panel master;

		PictureBox icon;

		Panel textPanel;

		Label nameLabel;
		Label name;

		Label locationLabel;
		Label location;

		Panel messagePanel;
		Label messageLabel;
		TextBox message;
		PictureBox messagePic;

		Label ETypeLabel;
		Label EType;

		Label TimeLabel;
		Label Time;

		DebugEntryType type;

		public Size MinimumSize {
			get { return master.MinimumSize; }
			set { master.MinimumSize = value;Resize(); }
		}
		public Size Size {
			get { return master.Size; }
			set { master.Size = value;Resize(); }
		}
		public Point Location {
			get { return master.Location; }
			set { master.Location = value; }
		}

		/// <summary>
		/// The constructor for the entry with a string message.
		/// </summary>
		/// <param name="P">The parent control</param>
		/// <param name="img">The icon for the message</param>
		/// <param name="name">The name of the sender</param>
		/// <param name="mess">The message</param>
		/// <param name="T">The type of message</param>
		/// <param name="time">The time the message was sent</param>
		/// <param name="location">The location the message came from</param>
		public DebugEntry(Control P, Image img, string name, string mess, DebugEntryType T, string time, string location) {
			type = T;

			setupBaseUI(P, img, name, T, time, location);

			message = new TextBox() {
				Parent=messagePanel,
				Lines=mess.Split('\n'),
				Multiline=true,
				BackColor = Color.DarkGray,
				Location = new Point(messageLabel.Width+separationDistX, 0),
				Size = new Size(messagePanel.Width-messageLabel.Width-separationDistX*2-8, messagePanel.Height-16),
				ScrollBars = ScrollBars.Vertical,
				ReadOnly=true,
				AcceptsReturn = true
			};

			rightAlignTextFields();
		}

		public DebugEntry(Control P, Image img, string name, Image mess, DebugEntryType T, string time, string location) {
			type = T;

			setupBaseUI(P, img, name, T, time, location);

			messagePic = new PictureBox() {
				Parent=messagePanel,
				BackColor = Color.DarkGray,
				Location = new Point(messageLabel.Width+separationDistX, 0),
				Size = new Size(messagePanel.Width-messageLabel.Width-separationDistX*2-8, messagePanel.Height-16),
				Image = mess,
				BorderStyle = BorderStyle.FixedSingle,
				SizeMode = PictureBoxSizeMode.StretchImage
			};

			rightAlignTextFields();
		}

		private void rightAlignTextFields() {
			int rightLoc;
			if (message != null) rightLoc = HMath.Max(this.name.Location.X, this.location.Location.X, Time.Location.X, EType.Location.X, message.Location.X);
			else rightLoc = HMath.Max(this.name.Location.X, this.location.Location.X, Time.Location.X, EType.Location.X, messagePic.Location.X);
			name.Location = new Point(rightLoc, this.name.Location.Y);
			location.Location = new Point(rightLoc, this.location.Location.Y);
			Time.Location = new Point(rightLoc, Time.Location.Y);
			EType.Location = new Point(rightLoc, EType.Location.Y);
			if (message != null) message.Location = new Point(rightLoc, message.Location.Y);
			else messagePic.Location = new Point(rightLoc, messagePic.Location.Y);
		}

		private void setupBaseUI(Control P, Image img, string name, DebugEntryType T, string time, string location) {
			master = new Panel() {
				Parent = P,
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				MinimumSize = new Size(64*8, 64*2),
				BorderStyle = BorderStyle.Fixed3D,
				BackColor = Color.DarkGray
			};

			if (img == null) img = Resources.DefaultUserIcon;
			icon = new PictureBox() {
				Parent=master,
				Image=img,
				Size=img.Size,
				Location=new Point(10, 10)
			};

			textPanel = new Panel() {
				Parent=master,
				Location=new Point(img.Width+10, 0+10),
				BorderStyle= BorderStyle.Fixed3D,
				Size = new Size(master.Width-icon.Width, master.Height)
			};

			nameLabel = new Label() {
				Parent=textPanel,
				Text="Name: ",
				Size = new Size(48, 16)
			};
			this.name = new Label() {
				Parent=textPanel,
				Text=name,
				BorderStyle= BorderStyle.FixedSingle,
				Location=new Point(nameLabel.Width+separationDistX, 0),
				Size = new Size(textPanel.Width-nameLabel.Width-separationDistX-2, 16)
			};

			locationLabel = new Label() {
				Parent=textPanel,
				Text="Location: ",
				Location = new Point(0, nameLabel.Location.Y+separationDistY),
				Size = new Size(8*7, 16)
			};
			this.location = new Label() {
				Parent=textPanel,
				Text=location,
				Location = new Point(locationLabel.Location.X+locationLabel.Width+separationDistX, locationLabel.Location.Y),
				Size = new Size(textPanel.Width-(locationLabel.Location.X+locationLabel.Width+separationDistX), 16),
				BorderStyle = BorderStyle.FixedSingle
			};

			TimeLabel = new Label() {
				Parent = textPanel,
				Text="Time: ",
				Location = new Point(0, this.location.Height+separationDistY),
				Size = new Size(8*6, 16)
			};
			Time = new Label() {
				Parent = textPanel,
				Text = time,
				Location = new Point(TimeLabel.Width+separationDistX, TimeLabel.Location.Y),
				BorderStyle = BorderStyle.FixedSingle,
				Size = new Size(textPanel.Width-(TimeLabel.Width+separationDistX), 16)
			};

			ETypeLabel = new Label() {
				Parent = textPanel,
				Text = "Entry type: ",
				Location = new Point(0, Time.Location.Y+separationDistY),
				Size = new Size(8*8, 16)
			};
			EType = new Label() {
				Parent=textPanel,
				Location = new Point(ETypeLabel.Width+separationDistX, ETypeLabel.Location.Y),
				Text = EntryTypeConversion[(int)T],
				Size = new Size(textPanel.Width-(ETypeLabel.Width+separationDistX), 16),
				BorderStyle = BorderStyle.FixedSingle
			};

			messagePanel = new Panel() {
				Parent = textPanel,
				BackColor = Color.DarkGray,
				Location = new Point(0, EType.Location.Y+separationDistY),
				Size = new Size(master.Width-icon.Width, master.Height-(EType.Location.Y+separationDistY))
			};
			messageLabel = new Label() {
				Parent = messagePanel,
				Text="Message: ",
				Size = new Size(8*8, 16)
			};
		}

		/// <summary>
		/// A method to resize the control after the size has been changed(shouldn't need to be called explicitly).
		/// </summary>
		public void Resize() {
			textPanel.Size = new Size(master.Width-icon.Width, master.Height);
			name.Size = new Size(textPanel.Width-nameLabel.Width-separationDistX, 16);
			Time.Size = new Size(textPanel.Width-(TimeLabel.Width+separationDistX), 16);
			EType.Size = new Size(textPanel.Width-(ETypeLabel.Width+separationDistX), 16);
			messagePanel.Size = new Size(master.Width-icon.Width, master.Height-(EType.Location.Y+separationDistY));
			message.Size = new Size(messagePanel.Width-messageLabel.Width-separationDistX, messagePanel.Height);
		}
	}
}
