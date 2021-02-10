using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wordfrequency.APP.src;

namespace Wordfrequency.APP
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Para execução é esperado o caminho do arquivo contendo o texto");
                return 1;
            }
                
            string pathFile = args[0];   

            if(string.IsNullOrEmpty(pathFile))
            {
                Console.WriteLine("Caminho para arquivo de texto não informado");
                return 1;
            }

            if(!File.Exists(pathFile))
            {
                Console.WriteLine("Arquivo não encontrado");
                return 1;
            }

            BoWordfrequency wordfrequency = new BoWordfrequency();

            wordfrequency.Handler(pathFile);

            if(wordfrequency.Error.Length > 0)
            {
                Console.WriteLine(wordfrequency.Error);
                return 1;
            }

            Console.Write($"Resultado gerando em arquivo no caminho: {wordfrequency.PathFileOut}");
            return 0;
        }   
    }
}
