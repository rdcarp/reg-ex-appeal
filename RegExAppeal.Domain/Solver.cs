using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegExAppeal.Domain
{
	public class Solver
	{
		public delegate void GameBoardFormatChangedEventHandler(object sender, GameBoardFormatChangedEventArgs e);

		public event GameBoardFormatChangedEventHandler GameBoardFormatChanged;

		private List<Answer> _possibleAnswers;
		private BoardFormat _format;
		private AnswerSet _answers;

		public Solver(string fileName, params int[] wordLengths)
			: this(fileName, new BoardFormat(wordLengths))
		{
		}

		public Solver(string fileName, BoardFormat format)
		{
			_answers = AnswerSet.LoadAnswerSet(fileName);
		}

		public void UpdateFormat(int index, char c)
		{
			_format.UpdateCharacter(index, c);
		}

		// get some unit tests for this first

	protected virtual void OnKeyboardButtonClicked(GameBoardFormatChangedEventArgs e)
		{
			if (GameBoardFormatChanged != null)
			{
				GameBoardFormatChanged(this, e);
			}
		}
	}
}
