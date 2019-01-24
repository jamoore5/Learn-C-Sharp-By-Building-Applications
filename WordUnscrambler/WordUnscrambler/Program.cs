using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using WordUnscrambler.Data;
using WordUnscrambler.Worker;

namespace WordUnscrambler
{
    class Program
    {   
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        
        private static void Main(string[] args)
        {
            try
            {

                var continueWordUnscrambler = true;

                do
                {
                    Console.WriteLine(Constants.optionsOnHowToEnterScrambledWords);
                    var option = Console.ReadLine()?.ToUpper() ?? string.Empty;

                    switch (option)
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordsInFileSenario();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteScrambledWordsInManualEntrySenario();
                            break;
                        default:
                            Console.WriteLine(Constants.EnterScrambledWordsOptionNotRecognized);
                            break;
                    }

                    var continueProgram = string.Empty;

                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                        continueProgram = Console.ReadLine() ?? string.Empty;

                    } while (
                        !continueProgram.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                        !continueProgram.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueWordUnscrambler = continueProgram.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);

                } while (continueWordUnscrambler);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }
        }

        private static void ExecuteScrambledWordsInManualEntrySenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            TrimWords(scrambledWords);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsInFileSenario()
        {
            try
            {
                var fileName = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(fileName);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBetLoaded + ex.Message);
            }
        }
        
        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            Dictionary<string, HashSet<string>> wordList = _fileReader.ParseWordList(Constants.WordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
                
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }

        private static void TrimWords(string[] words)
        {
            for (var i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
            }
        }
        
    }
}