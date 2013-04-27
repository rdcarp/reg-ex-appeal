using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace RegExAppeal.WebControls
{
	public class CharacterButton : Button
	{
		public delegate void CharacterButtonClickedEventHandler(object sender, EventArgs e);

		public event CharacterButtonClickedEventHandler CharacterButtonClicked;

		public int Index { get; set; }

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			Height = 45;
			Width = 30;
		}
	}

	public class CharacterButtonClickedEventArgs : EventArgs
	{
		
	}
}
