using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Controls;
using System.Windows.Documents;

namespace SZTGUI3
{
    internal class Worker
    {
        public string FileName => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.data");

        public void Serialize(ProgramData programData)
        {
            Stream ms = File.OpenWrite(FileName);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, programData);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        public ProgramData Deserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Open(FileName, FileMode.Open);
            var obj = formatter.Deserialize(fs);
            ProgramData programSettings = (ProgramData)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();

            return programSettings;
        }

        public List<KeyValuePair<string, List<KeyValuePair<string, bool>>>> GetQuestions()
        {
            if (File.Exists(this.FileName))
            {
                ProgramData data = this.Deserialize();
                return data.Questions;
            }

            return new List<KeyValuePair<string, List<KeyValuePair<string, bool>>>>
            {
                new KeyValuePair<string, List<KeyValuePair<string, bool>>>("Milyen színű a villamos?", new List<KeyValuePair<string, bool>> {
                    new KeyValuePair<string, bool>("Barna", false),
                    new KeyValuePair<string, bool>("Piros", false),
                    new KeyValuePair<string, bool>("Sárga", true)
                })
            };
        }

        public void SaveQuestions(List<KeyValuePair<string, List<KeyValuePair<string, bool>>>> questions)
        {
            ProgramData data = new ProgramData() { Questions = questions };
            this.Serialize(data);
        }
    }
}
