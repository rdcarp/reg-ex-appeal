using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RegExAppeal.Domain
{
	public class Answer
	{
		public string Value { get; set; }
		public Answer(string answer)
		{
			Value = answer;
		}
	}
}
