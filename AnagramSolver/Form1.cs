using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AnagramSolver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var anagram = anagramTb.Text;

            var wordList = File.ReadAllLines(@"D:\words_alpha.txt").ToList();

            //Get list of words that are same length or lower than anagram:
            var firstList = (from x in wordList
                             where x.Length <= anagram.Length
                             select x).ToList();

            var firstChar = anagram.First();
            var firstCharList = new List<string>();

            var anagramArray = anagram.OrderBy(x=>x).ToArray();

            foreach (var word in firstList)
            {
                //First pass for first character in anagram:

                //from here, only check with new anagram (all characters, not including first)

                //First edge case, it's only first char, then just append and continue:
                if (word.Length == 1 && anagram.Contains(word))
                {
                    listBox1.Items.Add(word);
                    continue;
                }

                var wordArray = word.OrderBy(x => x).ToArray();

                var wordCheck = false;

                //Second case, if word < anagram:
                if (word.Length < anagram.Length)
                {
                    foreach (var character in wordArray.Distinct())
                    {
                        //Check every character in the word:
                        if (!anagramArray.Contains(character)) break;
                        else
                        {
                            //Count the number of specified character in the word:
                            if (anagramArray.Where(x => x == character).Select(x => x).Count() < wordArray.Where(x => x == character).Select(x => x).Count()) wordCheck = false;
                            else wordCheck = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < anagramArray.Length; i++)
                    {
                        if (anagramArray[i] != wordArray[i])
                        {
                            wordCheck = false;
                        }
                        else
                        {
                            wordCheck = true;
                        }
                    }
                }
                

                if (wordCheck)
                {
                    listBox1.Items.Add(word);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
