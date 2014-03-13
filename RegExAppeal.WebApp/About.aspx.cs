using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegExAppeal.Domain;
using RegExAppeal.WebApp.WebControls;

namespace RegExAppeal.WebApp
{
	public partial class About : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var path = MapPath("App_Data/ProgrammingLanguages.xml");

			//todo create overloads that take BoardFormats and AnswerSets
			var solver = new Solver(new AnswerSet(path), 4, 6, 5);

			AnswerSet a = AnswerSet.LoadAnswerSet(path);
			foreach (var ans in a.Answers)
			{
				lit.Text +=(ans.Value + " " + ans.EncodedValue);
				lit.Text += "<br />";
			}

			AddBr();
			AddBr();
			lit.Text += "Posbbile answers for this board";
			var bf = new BoardFormat(4, 6, 5);

			foreach (var possibleAnswer in solver.PossibleAnswers)
			{
				AddBr();
				lit.Text += possibleAnswer.Value;
			}

			AddBr();
			AddBr();

			solver.UpdateFormat(1, 0, 'a');
			solver.UpdateFormat(2, 3, 'E');

			solver.UpdatePossibleAnswers();

			foreach (var possibleAnswer in solver.PossibleAnswers)
			{
				AddBr();
				lit.Text += possibleAnswer.Value;
			}
		}

		private void AddBr()
		{
			lit.Text += "<br />";
		}
	}
}
