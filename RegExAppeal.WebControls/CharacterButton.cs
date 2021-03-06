﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace RegExAppeal.WebControls
{
	public class CharacterButton : Button
	{
		private const string WordIndexViewStateKey = "wordindex";
		private const string CharacterIndexViewStateKey = "characterindex";

		public delegate void CharacterButtonClickedEventHandler(CharacterButton sender, EventArgs e);

		public event CharacterButtonClickedEventHandler CharacterButtonClicked;

		public int WordIndex
		{
			get { return ViewState[WordIndexViewStateKey] != null ? (int)ViewState[WordIndexViewStateKey] : 0; }
			set { ViewState[WordIndexViewStateKey] = value; }
		}

		public int CharacterIndex
		{
			get { return ViewState[CharacterIndexViewStateKey] != null ? (int) ViewState[CharacterIndexViewStateKey] : 0; }
			set { ViewState[CharacterIndexViewStateKey] = value; }
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			Height = 45;
			Width = 30;
			this.Click += new EventHandler(CharacterButton_Click);
		}

		void CharacterButton_Click(object sender, EventArgs e)
		{
			if (CharacterButtonClicked != null)
			{
				CharacterButtonClicked.Invoke(sender as CharacterButton, e);
			}
		}

		protected virtual void OnCharacterButtonClicked(EventArgs e)
		{
			if (CharacterButtonClicked != null)
			{
				CharacterButtonClicked(this, e);
			}
		}
	}
}
