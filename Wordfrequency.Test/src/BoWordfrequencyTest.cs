using System.IO;
using Wordfrequency.APP.src;
using Xunit;

namespace Wordfrequency.Test
{
    public class BoWordfrequencyTest
    {
        private string directoryTemp = @"C:\temp";
        private string TextWithFiveVoce = @"Você pode começar agora, mas você também pode esquecer.
                                    Porém eu não sei o que você quer, assim não fica fácil dizer para
                                    você como agir. Dessa forma você deve escolher apenas.";

        private string pathTextWithFiveVoce = "";                            
        public BoWordfrequencyTest()
        {
            string pathFile;
            pathFile = Path.Combine(directoryTemp, "Voce5.txt");

            File.WriteAllText(pathFile, TextWithFiveVoce);

            pathTextWithFiveVoce = pathFile;
        }
        
        [Fact]
        public void ShouldReturnFiveFrequencyForTextWithWordVoce()
        {     
            BoWordfrequency boWordfrequency = new BoWordfrequency();

            boWordfrequency.Handler(pathTextWithFiveVoce);

            Assert.True(boWordfrequency.Frequency["voce"] == 5);

            if(File.Exists(pathTextWithFiveVoce)){
                File.Delete(pathTextWithFiveVoce);
            }

            if(File.Exists(boWordfrequency.PathFileOut)){
                File.Delete(boWordfrequency.PathFileOut);
            }

        }

        [Fact]
        public void ShouldCreatedNewFile()
        {     
            BoWordfrequency boWordfrequency = new BoWordfrequency();

            boWordfrequency.Handler(pathTextWithFiveVoce);

            Assert.True(File.Exists(boWordfrequency.PathFileOut));

            if(File.Exists(pathTextWithFiveVoce)){
                File.Delete(pathTextWithFiveVoce);
            }

            if(File.Exists(boWordfrequency.PathFileOut)){
                File.Delete(boWordfrequency.PathFileOut);
            }

        }

    }
}
