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
                    new KeyValuePair<string, bool>("Sárga", true),
                    new KeyValuePair<string, bool>("Hupilila", false)
                }),
                new KeyValuePair<string, List<KeyValuePair<string, bool>>>("Melyik a meta OS?", new List<KeyValuePair<string, bool>> {
                    new KeyValuePair<string, bool>("Windows", false),
                    new KeyValuePair<string, bool>("Ubuntu", false),
                    new KeyValuePair<string, bool>("Fedora", true),
                    new KeyValuePair<string, bool>("MacOS", false)
                }),
                new KeyValuePair<string, List<KeyValuePair<string, bool>>>("Hány pontot kapunk erre a feladatra?", new List<KeyValuePair<string, bool>> {
                    new KeyValuePair<string, bool>("1", false),
                    new KeyValuePair<string, bool>("az összes", true),
                    new KeyValuePair<string, bool>("0.5", false),
                    new KeyValuePair<string, bool>("3", false)
                }),
                new KeyValuePair<string, List<KeyValuePair<string, bool>>>("Hány ablaka van a NIK-nek?", new List<KeyValuePair<string, bool>> {
                    new KeyValuePair<string, bool>("who cares", true),
                    new KeyValuePair<string, bool>("nemtom", false),
                    new KeyValuePair<string, bool>("500", false),
                    new KeyValuePair<string, bool>("1200", false)
                }),
                new KeyValuePair<string, List<KeyValuePair<string, bool>>>("Milyen vonat van a BC mellett?", new List<KeyValuePair<string, bool>> {
                    new KeyValuePair<string, bool>("Kék", true),
                    new KeyValuePair<string, bool>("Piros", false),
                    new KeyValuePair<string, bool>("Sárga", false),
                    new KeyValuePair<string, bool>("Zöld", false)
                }),
                new KeyValuePair<string, List<KeyValuePair<string, bool>>>("Mennyi az esélye annak, hogy valaki átmeg valszámból?", new List<KeyValuePair<string, bool>> {
                    new KeyValuePair<string, bool>("Barna", false),
                    new KeyValuePair<string, bool>("Piros", false),
                    new KeyValuePair<string, bool>("Sárga", true),
                    new KeyValuePair<string, bool>("Hupilila", false)
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
