using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegExAppeal.Domain
{
	public class Solver
	{
		public delegate void GameBoardFormatChangedEventHandler(object sender, GameBoardFormatChangedEventArgs e);

		public event GameBoardFormatChangedEventHandler GameBoardFormatChanged;

		//todo viewstate this badboy!
		private BoardFormat _format;
		private AnswerSet _answerSet;
		private List<Answer> _possibleAnswers;
		private List<char> _wrongLetters = new List<char>();
		private List<char> PlayedLetters
		{
			get
			{
				var words = _format;
				var includedChars = new List<char>();
				foreach (var word in _format)
				{
					includedChars.AddRange(word.Select(character => character.UpperCase).Where(x => x >= 'A' && x <= 'Z'));
				}

				includedChars.AddRange(_wrongLetters);

				return includedChars;
			}
		}

		public List<Answer> PossibleAnswers
		{
			get { return _possibleAnswers ?? new List<Answer>(); }
		}
		public List<char> BestGuesses
		{
			get
			{
				return MostCommonLetterRemaining();
			}
		}
		public BoardFormat Format { get { return _format; } }

		public Solver(AnswerSet answerSet, params int[] wordLengths)
			: this(answerSet, new BoardFormat(wordLengths))
		{
		}

		public Solver(AnswerSet answerSet, BoardFormat format)
		{
		    this._answerSet = answerSet;
			this._format = format;

			UpdatePossibleAnswers();
		}

		public void UpdateFormat(int wordIndex, int characterIndex, char c, bool update = false)
		{
			_format.UpdateCharacter(wordIndex, characterIndex, c);
			
			if (update)
				Recalculate();
		}
		public void UpdateFormat(int index, char c, bool update = false)
		{
			_format.UpdateCharacter(index, c);

			if (update)
				Recalculate();
		}
		public int UpdatePossibleAnswers()
		{
			List<Answer> possibleAnswers = new List<Answer>();

			StringBuilder sb = new StringBuilder();

			foreach (var word in _format)
			{
				foreach (var character in word)
				{
					if (character.IsLetter())
					{
						sb.Append(character.UpperCase);
					}
					else if (character.IsUnknownChar())
					{
						sb.Append("[A-Za-z]{1}");
					}
					else if (character.IsSpecialChar())
					{
						sb.Append("[" + Character.SpecialCharacter + "]{1}");
					}
				}
				sb.Append(" ");
			}

			Regex r = new Regex(sb.ToString().Trim(), RegexOptions.IgnoreCase);

			foreach (var answer in _answerSet.Answers)
			{
				if (r.IsMatch(answer.EncodedValue))
					possibleAnswers.Add(answer);
			}

			_possibleAnswers = possibleAnswers;

			return PossibleAnswers.Count;
		}
		public void AddWrongLetter(char c, bool update = false)
		{
			if(_wrongLetters == null)
				_wrongLetters = new List<char>();

			_wrongLetters.Add(c);
		}

		public List<char> MostCommonLetterRemaining()
		{
			// get all possible letters
			// count how many answers they are in
			// list in order of count

			var counter = new Dictionary<char, int>();
			for (char c = 'a'; c <= 'z'; c++)
			{
				foreach (var possibleAnswer in _possibleAnswers)
				{
					if((possibleAnswer.DistintCharacters.Except(PlayedLetters)).Contains(c))
					{
						if (counter.ContainsKey(c))
							counter[c]++;
						else
							counter[c] = 1;
					}
				}
			}

			return (from kvp in counter orderby kvp.Value descending select kvp.Key).ToList();
		}

		public int Recalculate()
		{
			var possibleAnswers = UpdatePossibleAnswers();

			return possibleAnswers;
		}

		protected virtual void OnKeyboardButtonClicked(GameBoardFormatChangedEventArgs e)
		{
			if (GameBoardFormatChanged != null)
			{
				GameBoardFormatChanged(this, e);
			}
		}
	}
}
