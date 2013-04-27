using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace RegExAppeal.Domain
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
	[SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[XmlTypeAttribute(AnonymousType = true)]
	[XmlRootAttribute(Namespace = "", IsNullable = false)]
	public class AnswerSet
	{
		private string[] answerField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Answer")]
		public string[] Answer
		{
			get
			{
				return this.answerField;
			}
			set
			{
				this.answerField = value;
			}
		}

		private IEnumerable<Answer> _answers;
		public IEnumerable<Answer> Answers
		{
			get
			{
				if (_answers == null && Answer != null)
					_answers = Answer.Select(x => new Answer(x));

				return _answers;
			}
		}

		public AnswerSet()
		{}
		public static AnswerSet LoadAnswerSet(string fileName)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(AnswerSet));

			StreamReader reader = new StreamReader(fileName);
			var answers = (AnswerSet)serializer.Deserialize(reader);
			
			reader.Close();

			return answers;
		}


	}
}
