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
                    if (words.Count(x => x == word) > 1)
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
    }
}
