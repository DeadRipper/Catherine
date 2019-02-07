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
		/// <summary>
		/// Saying method == first version of answer
		/// </summary>
		/// <returns></returns>
		/*public string Saying()
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
			return SentenceConstruct();
		}*/


		///
		/// SentenceConstruct - answer tryhard
		///
		public string SentenceConstruct()
		{
			Random rnd = new Random();
			string speech = ""; 
			int a = rnd.Next(3);

			string[] firstword = new string[] {"I", "Me", "You" };
			string[] secondword = new string[] { "don't", "shoot", "humans" };
			string[] thirdword = new string[] { "oh", "my", "god" };

			for (int j = 0; j < firstword.Length; j++)
			{
				speech = $"{firstword[a]} {secondword[a]} {thirdword[a]}";
			}
			return speech;
		}
	}
}
