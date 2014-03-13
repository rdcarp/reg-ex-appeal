using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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
		    if (!IsPostBack)
		    {
		        var path = MapPath("App_Data/ProgrammingLanguages.json");

		        var answerSet = new AnswerSet(path);
		        Random r = new Random();

		        var correctAnswer = answerSet.Answers.ToArray()[r.Next(0, answerSet.Answers.Count() - 1)];

		        solver = new Solver(answerSet, correctAnswer.Format);

		        gameBoard.Format = solver.Format;
		        gameBoard.DataBind();

		        prediction.Solver = solver;
		        prediction.DataBind();
		    }
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
