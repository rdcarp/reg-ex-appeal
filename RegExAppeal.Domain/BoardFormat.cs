using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegExAppeal.Domain
{
	public class BoardFormat : List<Word>
	{
		public BoardFormat(params int[] wordLengths)
		{
			AddRange(wordLengths.Select(x => new Word(x)));
		}
	}
}
