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
	public partial class GameBoard : System.Web.UI.UserControl
	{
		public delegate void GameBoardButtonClickedEventHandler(object sender, GameBoardButtonClickedEventArgs e);

		public event GameBoardButtonClickedEventHandler GameBoardButtonClicked;

		private int wordIndex = 0;

		public BoardFormat Format { get; set; }
		public Character ActiveCharacter
		{
			get { return ViewState["ActiveCharacter"] as Character; }
			set { ViewState["ActiveCharacter"] = value; }
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ActiveCharacter = new Character('s');
			}
		}

		public override void DataBind()
		{
			if (!IsPostBack)
			{
				rptWords.ItemDataBound += new RepeaterItemEventHandler(rptWords_ItemDataBound);
				rptWords.DataSource = Format;
				rptWords.DataBind();
			}
		}

		void rptWords_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				var word = e.Item.DataItem as Word;
				var rptCharacters = e.Item.FindControl("rptCharacters") as Repeater;

				if (rptCharacters != null)
				{
					rptCharacters.ItemDataBound += new RepeaterItemEventHandler(rptCharacters_ItemDataBound);
					rptCharacters.DataSource = word;
					rptCharacters.DataBind();
				}

				wordIndex++;
			}
		}

		void rptCharacters_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				var character = e.Item.DataItem as Character;

				var characterButton = e.Item.FindControl("character") as CharacterButton;
				if (characterButton != null)
				{
					characterButton.Text = character.LowerCase.ToString();
					characterButton.WordIndex = wordIndex;
					characterButton.CharacterIndex = e.Item.ItemIndex;
					characterButton.CommandArgument = character.LowerCase.ToString();
					characterButton.CharacterButtonClicked += new CharacterButton.CharacterButtonClickedEventHandler(characterButton_CharacterButtonClicked);
				}
			}
		}

		protected void characterButton_CharacterButtonClicked(object sender, EventArgs e)
		{
			var button = sender as CharacterButton;
			if (button == null)
				return;
			
			var newArgs = new GameBoardButtonClickedEventArgs
				{
					Word = button.WordIndex, 
					Character = button.CharacterIndex
				};

			OnKeyboardButtonClicked(newArgs);
		}

		public void characterButton_Command(object sender, CommandEventArgs e)
		{
			switch (e.CommandName)
			{
				case "UpdateLetter":
					UpdateLetter(sender as CharacterButton, ActiveCharacter.LowerCase.ToString());			
					break;
			}
		}

		private void UpdateLetter(CharacterButton sender, string newValue)
		{
			sender.Text = newValue;
			Format.UpdateCharacter(1, 1, sender.Text[0]);
		}

		protected virtual void OnKeyboardButtonClicked(GameBoardButtonClickedEventArgs e)
		{
			if (GameBoardButtonClicked != null)
			{
				GameBoardButtonClicked(this, e);
			}
		}
	}

	public class GameBoardButtonClickedEventArgs : EventArgs
	{
		public int Word { get; set; }
		public int Character { get; set; }
	}
}