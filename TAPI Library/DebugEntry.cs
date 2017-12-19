﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAPI_Library {
	public enum DebugEntryType { INFO, WARNING, ERROR, MESSAGE }
	public class DebugEntry {
		static readonly string[] EntryTypeConversion = new string[] { "INFO", "WARNING", "ERROR", "MESSAGE" };

		const int separationDistY = 16;
		const int separationDistX = 10;

		Panel master;

		PictureBox icon;

		Panel textPanel;

		Panel namePanel;
		Label nameLabel;
		Label name;

		Panel messagePanel;
		Label messageLabel;
		RichTextBox message;

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
		/// The constructor for the entry.
		/// </summary>
		/// <param name="P">The parent control</param>
		/// <param name="img">The icon for the message</param>
		/// <param name="name">The name of the sender</param>
		/// <param name="mess">The message</param>
		/// <param name="T">The type of message</param>
		/// <param name="time">The time the message was sent</param>
		public DebugEntry(Control P, Image img, string name, string mess, DebugEntryType T, string time) {
			type = T;

			master = new Panel() {
				Parent = P,
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				MinimumSize = new Size(64*8, 64*2),
				BorderStyle = BorderStyle.Fixed3D,
				BackColor = Color.DarkGray
			};

			icon = new PictureBox() {
				Parent=master,
				Image=img,
				Size=img.Size,
				Location=new Point(10,10)
			};

			textPanel = new Panel() {
				Parent=master,
				Location=new Point(img.Width+10, 0+10),
				BorderStyle= BorderStyle.Fixed3D,
				Size = new Size(master.Width-icon.Width, master.Height)
			};

			namePanel = new Panel() {
				Parent=textPanel,
				BackColor = Color.DarkGray,
				Size = new Size(textPanel.Width, 16)
			};
			nameLabel = new Label() {
				Parent=namePanel,
				Text="Name: ",
				Size = new Size(48, 16)
			};
			this.name = new Label() {
				Parent=namePanel,
				Text=name,
				BorderStyle= BorderStyle.FixedSingle,
				Enabled=false,
				Location=new Point(nameLabel.Width+separationDistX, 0),
				Size = new Size(namePanel.Width-nameLabel.Width-separationDistX, 16)
			};

			TimeLabel = new Label() {
				Parent = textPanel,
				Text="Time: ",
				Location = new Point(0, namePanel.Height+separationDistY),
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
			message = new RichTextBox() {
				Parent=messagePanel,
				Text=mess,
				Multiline=true,
				Enabled=false,
				BackColor = Color.DarkGray,
				Location = new Point(messageLabel.Width+separationDistX, 0),
				Size = new Size(messagePanel.Width-messageLabel.Width-separationDistX, messagePanel.Height),
				ScrollBars = RichTextBoxScrollBars.Vertical
			};
		}

		/// <summary>
		/// A method to resize the control after the size has been changed(shouldn't need to be called explicitly).
		/// </summary>
		public void Resize() {
			textPanel.Size = new Size(master.Width-icon.Width, master.Height);
			namePanel.Size = new Size(textPanel.Width, 16);
			name.Size = new Size(namePanel.Width-nameLabel.Width-separationDistX, 16);
			Time.Size = new Size(textPanel.Width-(TimeLabel.Width+separationDistX), 16);
			EType.Size = new Size(textPanel.Width-(ETypeLabel.Width+separationDistX), 16);
			messagePanel.Size = new Size(master.Width-icon.Width, master.Height-(EType.Location.Y+separationDistY));
			message.Size = new Size(messagePanel.Width-messageLabel.Width-separationDistX, messagePanel.Height);
		}
	}
}
