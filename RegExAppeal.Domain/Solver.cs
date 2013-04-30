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

		private BoardFormat _format;
		private AnswerSet _answers;
		private List<Answer> _possibleAnswers;
		private List<char> _wrongLetters = new List<char>();

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

		public Solver(string fileName, params int[] wordLengths)
			: this(fileName, new BoardFormat(wordLengths))
		{
		}

		public Solver(string fileName, BoardFormat format)
		{
			_answers = AnswerSet.LoadAnswerSet(fileName);
			_format = format;

			UpdatePossibleAnswers();
		}

		public void UpdateFormat(int wordIndex, int characterIndex, char c)
		{
			_format.UpdateCharacter(wordIndex, characterIndex, c);
		}
		public void UpdateFormat(int index, char c)
		{
			_format.UpdateCharacter(index, c);
		}

		protected virtual void OnKeyboardButtonClicked(GameBoardFormatChangedEventArgs e)
		{
			if (GameBoardFormatChanged != null)
			{
				GameBoardFormatChanged(this, e);
			}
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

			foreach (var answer in _answers.Answers)
			{
				if (r.IsMatch(answer.EncodedAnswer))
					possibleAnswers.Add(answer);
			}

			_possibleAnswers = possibleAnswers;

			return PossibleAnswers.Count;
		}
		public List<char> MostCommonLetterRemaining()
		{
			var letterFrequency = new Dictionary<char, int>();

			foreach (Answer a in _possibleAnswers)
			{
				foreach (char c in a.DistintCharacters)
				{
					if (char.IsLetter(c) && !_wrongLetters.Contains(char.ToUpper(c)))
					{
						if (letterFrequency.ContainsKey(c))
							letterFrequency[c]++;
						else
							letterFrequency[c] = 1;
					}
				}
			}

			int maxOccurrence = letterFrequency.Values.Max();

			List<char> l = new List<char>();

			foreach (KeyValuePair<char, int> kvp in letterFrequency)
			{
				if (kvp.Value == maxOccurrence)
				{
					l.Add(kvp.Key);
				}
			}

			return l;
		}
	}
}
