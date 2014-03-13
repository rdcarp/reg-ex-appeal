using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace RegExAppeal.Domain
{
	public class AnswerSet
	{
        public ICollection<Answer> Answers { get; set; }
        public string Name { get; set; }

        public AnswerSet()
        {
            this.Answers = new Collection<Answer>();
        }
        public AnswerSet(Collection<string> answers)
            : this()
        {
            this.Answers = answers.Select(x => new Answer(x)).ToList();
        }
        public AnswerSet(string file)
            : this(new AnswerFile(file))
        {
        }
        public AnswerSet(AnswerFile file)
        {
            this.Answers = file.Answers.Select(x => new Answer(x)).ToList();
            this.Name = file.Name;
        }

	    public static AnswerSet LoadAnswerSet(string fileName)
	    {
	        var reader = new StreamReader(fileName);
	        var serializer = new JavaScriptSerializer();
	        
            var answerFile = serializer.Deserialize<AnswerFile>(reader.ReadToEnd());

            return new AnswerSet(answerFile);
	    }


	}
}
