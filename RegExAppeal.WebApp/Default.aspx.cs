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
		private Solver solver;
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			keyboard.KeyboardButtonClicked += new WebControls.Keyboard.KeyboardButtonClickedEventHandler(keyboard_KeyboardButtonClicked);
			gameBoard.GameBoardButtonClicked += new WebControls.GameBoard.GameBoardButtonClickedEventHandler(gameBoard_GameBoardButtonClicked);

		}
		protected void Page_Load(object sender, EventArgs e)
		{
			var path = MapPath("App_Data/ProgrammingLanguages.xml");
			solver = new Solver(path, 4, 6, 5);

			gameBoard.Format = solver.Format;
			gameBoard.DataBind();

			prediction.Solver = solver;
			prediction.DataBind();
		}

		void gameBoard_GameBoardButtonClicked(object sender, WebControls.GameBoardButtonClickedEventArgs e)
		{
			solver.UpdateFormat(e.Word, e.Character, gameBoard.ActiveCharacter.LowerCase, true);
			prediction.Solver = solver;
			prediction.DataBind();
		}

		void keyboard_KeyboardButtonClicked(object sender, WebControls.KeyboardButtonClickedEventArgs e)
		{
			gameBoard.ActiveCharacter = new Character(e.Button.Text[0]);
		}

	}
}
