using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Catherine
{
	class LogicOfAnswer
	{
		public string Saying()
		{
			
			string pattern = "(^[A-Z]{1}[a-z]{1,14} [A-Z]{1}[a-z]{1,14}$)|(^[А-Я]{1}[а-я]{1,14} [А-Я]{1}[а-я]{1,14}$)";
			string words = "";
			char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
			Random rnd = new Random();
			int num_letters = rnd.Next(10);
			for (int i = 1; i <= num_letters; i++)
			{
				int letter_num = rnd.Next(0, letters.Length - 1);
				words += letters[letter_num];
				Regex.IsMatch(words, pattern);
			}
			return words;
		}
	}
}
