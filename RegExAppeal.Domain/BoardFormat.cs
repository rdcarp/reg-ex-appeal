using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegExAppeal.Domain
{
	[Serializable]
	public class BoardFormat : List<Word>
	{
		public BoardFormat(params int[] wordLengths)
		{
			AddRange(wordLengths.Select(x => new Word(x)));
		}
		public void UpdateCharacter(int wordIndex, int characterIndex, char character)
		{
			this[wordIndex][characterIndex] = new Character(character);
		}
		public void UpdateCharacter(int letterIndex, char character)
		{
			var wordIndex = 0;
			var characterIndex = 0;

			while (letterIndex > 0)
			{
				if (this[wordIndex].Count < letterIndex)
				{
					wordIndex++;
					letterIndex = -this[wordIndex].Count;
				}
				else
				{
					characterIndex = letterIndex;
					letterIndex = - letterIndex;
				}
			}

			this[wordIndex][characterIndex] = new Character(character);
		}
	}
}
