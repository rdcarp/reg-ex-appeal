using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegExAppeal.Domain
{
	[Serializable]
	public class Character
	{
		public const char UnknownCharacter = '_';
		public const char SpecialCharacter = '~';

		private char _char = '\0';

		public char UpperCase
		{
			get { return char.Parse(_char.ToString().ToUpper()); }
		}
		public char LowerCase
		{
			get { return char.Parse(_char.ToString().ToLower()); }
		}

		public Character(char c)
		{
			if (!IsLetter() && !IsUnknownChar() && IsSpecialChar())
				throw new ArgumentException("Invalid character");

			_char = c;
		}

		public bool IsLetter()
		{
			for (char testChar = 'a'; testChar <= 'z'; testChar++)
				if (LowerCase.Equals(testChar))
					return true;

			return false;
		}
		public bool IsSpecialChar()
		{
			return _char.Equals(SpecialCharacter);
		}
		public bool IsUnknownChar()
		{
			return _char.Equals(UnknownCharacter);
		}
	}
}
