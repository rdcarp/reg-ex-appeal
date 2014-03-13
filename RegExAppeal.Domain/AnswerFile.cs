using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Web.Script.Serialization;

namespace RegExAppeal.Domain
{
    public class AnswerFile
    {
        public string Name { get; set; }
        public IEnumerable<string> Answers { get; set; }

        public AnswerFile()
        {
            this.Answers = new Collection<string>();
        }
        public AnswerFile(string filePath)
            : this()
        {
            var reader = new StreamReader(filePath);
            var serializer = new JavaScriptSerializer();
            var answerFile = serializer.Deserialize<AnswerFile>(reader.ReadToEnd());

            this.Answers = answerFile.Answers;
            this.Name = answerFile.Name;
        }
    }
}