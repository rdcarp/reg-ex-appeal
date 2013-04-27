using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegExAppeal.Domain;

namespace RegExAppeal.WebApp
{
	public partial class About : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var path = MapPath("App_Data/ProgrammingLanguages.xml");

			AnswerSet a = AnswerSet.LoadAnswerSet(path);

			foreach (var ans in a.Answers)
			{
				Response.Write(ans.OriginalAnswer + " " + ans.EncodedAnswer);
			}
		}
	}
}
