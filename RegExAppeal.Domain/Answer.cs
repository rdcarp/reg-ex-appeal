using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RegExAppeal.Domain
{
	public class Answer
	{
        private string _value;
        private string _encodedAnswer;
        private List<char> _distinctCharacters;
	    private int[] _format;

		public string Value
		{
			get { return _value; }
		}

		public string EncodedValue
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_encodedAnswer) && !string.IsNullOrWhiteSpace(_value))
					_encodedAnswer = EncodeAnswer(_value);

				return _encodedAnswer;
			}
		}

		public List<char> DistintCharacters
		{
			get
			{
				if (_distinctCharacters == null)
				{
					_distinctCharacters = _encodedAnswer.Replace(" ", "").Replace(Character.SpecialCharacter.ToString(), " ").Distinct().ToList();
				}
				return _distinctCharacters;
			}
		}

		public Answer(string answer)
		{
			_value = answer;
		}

		public static string EncodeAnswer(string originalAnswer)
		{
			var temp = string.Empty;

			for (int i = 0; i < originalAnswer.Length; i++)
			{
				if (originalAnswer.ToLower()[i].Equals(' '))
					temp += " ";
				else if (originalAnswer.ToLower()[i] < 'a' || originalAnswer.ToLower()[i] > 'z')
					temp += Character.SpecialCharacter;
				else
					temp += originalAnswer.ToLower()[i];
			}
			return temp;
		}

        public int[] Format
        {
            get
            {
                if (_format == null)
                {
                    this._format = this.EncodedValue.Split(' ').Select(x => x.Length).ToArray();
                }
                return _format;
            }
        }

        public override string ToString()
        {
            return this.Value;
        }
	}
}
