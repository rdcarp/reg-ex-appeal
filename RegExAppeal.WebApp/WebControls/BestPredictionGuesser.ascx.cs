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
			var item = e.Item.DataItem as string;

			if (item != null)
			{
				var lit = e.Item.FindControl("lit") as Literal;
				if (lit != null)
				{
					lit.Text = item;
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
		}
	}
}