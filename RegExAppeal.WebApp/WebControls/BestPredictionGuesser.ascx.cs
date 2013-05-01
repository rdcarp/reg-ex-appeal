using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegExAppeal.Domain;

namespace RegExAppeal.WebApp.WebControls
{
	public partial class BestPredictionGuesser : System.Web.UI.UserControl
	{
		public int SuggestionsToList = 5;
		public Solver Solver { get; set; }

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			rptLetters.ItemDataBound += new RepeaterItemEventHandler(rptLetters_ItemDataBound);
		}

		void rptLetters_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.DataItem != null)
			{
				char c;

				if (char.TryParse(e.Item.DataItem.ToString(), out c))
				{
					var lit = e.Item.FindControl("lit") as Literal;
					if (lit != null)
					{
						lit.Text = c.ToString();
					}
				}
			}
		}
		protected void Page_Load(object sender, EventArgs e)
		{
		}
		public override void DataBind()
		{
			base.DataBind();

			rptLetters.DataSource = Solver.MostCommonLetterRemaining();
			rptLetters.DataBind();

			rptAnswers.DataSource = Solver.PossibleAnswers;
			rptAnswers.DataBind();
		}
	}
}