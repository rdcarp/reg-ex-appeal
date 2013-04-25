using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegExAppeal.Domain
{
	public class Word : List<Character>
	{
		public Word(params char[] characters)
		{
			AddRange(characters.Select(x => new Character(x)));
		}
		public Word(int length)
		{
			for (int i = 0; i < length; i++)
			{
				Add(new Character(Character.UnknownCharacter));
			}
		}
	}
}
