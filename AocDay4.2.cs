using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Aoc
{
    public class Program
    {
        static void Main(string[] args)
        {
            int validPassphrases = 0;
            foreach (string passphrase in System.IO.File.ReadLines("input4.1.txt"))
            {
                bool passphraseValid = true;
                List<string> words = passphrase.Split(' ').ToList();
                foreach (string word in words)
                {
                    if (AnagramExists(words, word))
                    {
                        passphraseValid = false;
                    }
                }

                if (passphraseValid)
                {
                    validPassphrases++;
                }
            }

            Console.WriteLine(validPassphrases);
        }
        private static bool AnagramExists(List<string> words, string word)
        {
            List<string> withoutWord = new List<string>(words);
            withoutWord.Remove(word);

            foreach (string possibleAnagram in withoutWord)
            {
                if (IsAnagram(possibleAnagram, word))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsAnagram(string word1, string word2)
        {
            if (word1.Length != word2.Length)
            {
                return false;
            }

            foreach (char c in word1)
            {
                if (word1.Count(x => x == c) != word2.Count(x => x == c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
