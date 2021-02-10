using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Wordfrequency.APP.src
{
    public class BoWordfrequency
    {
        public Dictionary<string, long> Frequency { get; set; }

        private string[] NotWords = {"a", "e", "i", "o", "u", "ate", "da", "ja"};
        
        public string Error { get; private set; } = "";

        public string PathFileOut { get; private set; }
        
        public BoWordfrequency()
        {
            Frequency = new Dictionary<string, long>();
        }

        public void Handler(string pathFile)
        {
            try{
                string text = File.ReadAllText(pathFile);
                string directoryOut = Path.GetDirectoryName(pathFile);
                
                string[] words = text.Split(' ');

                foreach (string word in words)
                {
                    string uniqueWord = GetUniqueWord(word);

                    if(!NotWords.Contains(uniqueWord)){
                        if(Frequency.ContainsKey(uniqueWord))
                        {
                            Frequency[uniqueWord] = Frequency[uniqueWord] + 1;
                        }
                        else
                            Frequency.Add(uniqueWord, 1);
                    }
                }
                GeneretFile(directoryOut);
            }
            catch(Exception exception){
                Error = $"Erro durante o processamento: {exception.Message}";
            }
        }

        private void GeneretFile(string directoryOut)
        {
            string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", string.Empty)
                                                                      .Replace(":", string.Empty)
                                                                      .Replace(" ", string.Empty);
            string fileName = $"wordfrequency_{date}.json";

            string jsonResult = JsonSerializer.Serialize(Frequency.ToArray());

            PathFileOut = Path.Combine(directoryOut,fileName);

            File.WriteAllText(PathFileOut, jsonResult);
        }

        private string GetUniqueWord(string word)
        {
            string treatedWord = WordsTool.RemoveSpecialCharacters(word);
            treatedWord =  treatedWord.ToLower();
            treatedWord = WordsTool.RemoveAccent(treatedWord);
            return treatedWord;
        }

    }
}