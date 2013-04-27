using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegExAppeal.Domain;
using RegExAppeal.WebControls;

namespace RegExAppeal.WebApp.WebControls
{
	public partial class Keyboard : System.Web.UI.UserControl
	{
		public delegate void KeyboardButtonClickedEventHandler(object sender, KeyboardButtonClickedEventArgs e);

		public event KeyboardButtonClickedEventHandler KeyboardButtonClicked;

		private List<string> TopRow = new List<string> {"Q", "W", "E", "R", "T,", "Y", "U", "I", "O", "P"};
		private List<string> MiddleRow = new List<string> {"A", "S", "D", "F", "G,", "H", "J", "K", "L"};
		private List<string> BottomRow = new List<string> {"Z", "X", "C", "V", "B,", "N", "M", Character.SpecialCharacter.ToString(), Character.UnknownCharacter.ToString()};

		protected void Page_Load(object sender, EventArgs e)
		{
			List<List<string>> rows = new List<List<string>>();
			rows.Add(TopRow);
			rows.Add(MiddleRow);
			rows.Add(BottomRow);

			rptRows.ItemDataBound += new RepeaterItemEventHandler(rptRows_ItemDataBound);
			rptRows.DataSource = rows;
			rptRows.DataBind();
		}

		private void rptRows_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			var letters = e.Item.DataItem as List<string>;
			var rptLetters = e.Item.FindControl("rptLetters") as Repeater;

			if (letters != null && rptLetters != null)
			{
				rptLetters.ItemDataBound += new RepeaterItemEventHandler(rptLetters_ItemDataBound);
				rptLetters.DataSource = letters;
				rptLetters.DataBind();
			}
		}
		private void rptLetters_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			var charButton = e.Item.FindControl("charButton") as CharacterButton;
			var letter = e.Item.DataItem as string;

			if (charButton != null && letter != null)
			{
				charButton.Text = letter;
			}
		}

		public void charButton_Click(object sender, EventArgs e)
		{
			KeyboardButtonClickedEventArgs arg = new KeyboardButtonClickedEventArgs();
			arg.Button = sender as CharacterButton;

			OnKeyboardButtonClicked(arg);
		}

		protected virtual void OnKeyboardButtonClicked(KeyboardButtonClickedEventArgs e)
		{
			if (KeyboardButtonClicked != null)
			{
				KeyboardButtonClicked(this, e);
			}
		}
	}

	public class KeyboardButtonClickedEventArgs : EventArgs
	{
		public CharacterButton Button { get; set; }
	}
}