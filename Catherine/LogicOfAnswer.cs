using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Catherine
{
	class LogicOfAnswer
	{
		public string Saying(string param)
		{
			string reg = param;
			reg = "[A-Za-z]";
			Random rnd = new Random();
			return reg;
		}
	}
}
