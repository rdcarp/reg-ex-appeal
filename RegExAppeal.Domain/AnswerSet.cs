using System;
using System.IO;
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
		private Answer[] answerField;

		/// <remarks/>
		[XmlElementAttribute("Answer")]
		public Answer[] Answer
		{
			get { return this.answerField; }
			set { this.answerField = value; }
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
