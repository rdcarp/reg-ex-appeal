using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RegExAppeal.Domain
{
	public class Answer
	{
		private string _originalAnswer;

		public string OriginalAnswer
		{
			get { return _originalAnswer; }
		}

		private string _encodedAnswer;
		public string EncodedAnswer
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_encodedAnswer) && !string.IsNullOrWhiteSpace(_originalAnswer))
					_encodedAnswer = EncodeAnswer(_originalAnswer);

				return _encodedAnswer;
			}
		}

		public Answer(string answer)
		{
			_originalAnswer = answer;
		}

		public static string EncodeAnswer(string originalAnswer)
		{
			var temp = string.Empty;

			for (int i = 0; i < originalAnswer.Length; i++)
				if (originalAnswer.ToLower()[i] < 'a' || originalAnswer.ToLower()[i] > 'z')
					temp += Character.SpecialCharacter;
				else
					temp += originalAnswer.ToLower()[i];

			return temp;
		}

	}
}
