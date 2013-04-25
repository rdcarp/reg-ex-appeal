using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegExAppeal.Domain;
using RegExAppeal.WebControls;

namespace RegExAppeal.WebApp
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			gameBoard.Format = new BoardFormat(3, 4, 5, 6);
			gameBoard.DataBind();
			keyboard.KeyboardButtonClicked += new WebControls.Keyboard.KeyboardButtonClickedEventHandler(keyboard_KeyboardButtonClicked);	
		}

		void keyboard_KeyboardButtonClicked(object sender, WebControls.KeyboardButtonClickedEventArgs e)
		{
			gameBoard.ActiveCharacter = new Character(e.Button.Text[0]);
		}

	}
}
