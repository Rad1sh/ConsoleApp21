using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp21
{
    



    class Program
    {
        public static int wordCounter = 0;
        public static string[] wordList;
        public static string[] dictList;
        public static Dictionary<string, bool> dictionary = new Dictionary<string, bool>();

        static void ReadDict()
        {
            string s = File.ReadAllText(@"C:\Users\ZUN\Documents\Visual Studio 2017\Projects\ConsoleApp21\Dict.txt");
            dictList = s.Split(' ');

            
            foreach (var word in dictList)
            {
                
                if (!dictionary.ContainsKey(word))
                {

                   dictionary.Add(word, true);
                }
            }   
          /*  foreach(var word in dictionary)
            {
                Console.WriteLine(word);
            }  */
            
        }
        static void ReadFile()
        {
            string s = File.ReadAllText(@"C:\Users\ZUN\Documents\Visual Studio 2017\Projects\ConsoleApp21\Word.txt");
            wordList = s.Split(' ');
            
            
        }

        static bool checker(string word)
        {
            if (dictionary.ContainsKey(word))
            {
                return true;

            }
            return false;
        }

        static void Main(string[] args)
        {
            string alphabet = "abcdefghigklmnopqrstuvwxyz";


            ReadDict();
            ReadFile();
            
            foreach(var item in wordList)
            {
                wordCounter++;

                if (!dictionary.ContainsKey(item))
                {
                    var ansList = new List<string>();
                    Console.Write("Wrong Word: \t"+item+" \t\t#Word :\t" +wordCounter);
                    
                    for(int i = 0; i < item.Length; i++)         
                    {
                        var a = item.Substring(0, i);
                        var b = item.Substring(i);
                        for (int j = 0; j < alphabet.Length ; j++){
                            
                            if (checker(a+alphabet[j]))
                            {
                                
                                ansList.Add(a+alphabet[j]);
                            }
                            if (checker(b+alphabet[j]))
                            {
                                ansList.Add(b+alphabet[j]);
                            }
                        }
                    }       // Added Substring 
                    
                    for(int i = 0; i < item.Length ; i++)
                    {
                        var a = item.Remove(i, 0);
                        if (checker(a))
                        {
                            ansList.Add(a);
                        }
                    }     //Remove Char

                    for (int i = 0; i < item.Length; i++)
                    {
                        for(int j = 0; j < alphabet.Length; j++)
                        {
                            var a = item.Substring(0, i) + alphabet[j]+ item.Substring(i + 1);
                            
                            if (checker(a))
                            {
                                ansList.Add(a);
                            }
                        }
                        
                    }     //Raplace Char 

                    if (item.Length > 2)
                    {
                        for (int i = 0; i < item.Length - 2; i++)
                        {
                            var a = item.Substring(i + 1, 0) + item.Substring(i, 0) + item.Substring(i + 2);
                            if (checker(a))
                            {
                                ansList.Add(a);
                            }
                        }      // swap Char
                    }   
                    
                

                    Console.Write(" \t\tSuggest Word : ");
                    
                    foreach( var word in ansList)
                    {
                        Console.Write(word + " " );
                    }
                    Console.WriteLine();
                }
                
                
            }      
              

            Console.ReadKey();

        }
    }
}
