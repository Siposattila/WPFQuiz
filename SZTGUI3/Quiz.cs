using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUI3
{
    public class Quiz
    {
        string question;
        int correctAnswer;
        string[] answers = new string[4];
        public Quiz(KeyValuePair<string,List<KeyValuePair<string,bool>>> avgAdapter)
        {
            this.question = avgAdapter.Key;
            for (int i = 0; i < avgAdapter.Value.Count; i++)
            {
                answers[i] = avgAdapter.Value.ElementAt(i).Key;
                if (avgAdapter.Value.ElementAt(i).Value)
                {
                    correctAnswer = i;
                }
            }
        }
        public int CorrectAnswer { get { return correctAnswer; }  }
        public string Question { get { return question; } }
        public string[] Answers { get { return answers; } }
    }
}
