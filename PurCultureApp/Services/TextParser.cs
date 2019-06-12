using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PurCultureApp.Services
{
	class TextParser
	{
		public TextParser()
		{

		}

		public static string RemoveSpecialChars(String s)
		{
			var charsToRemove = new string[] { "&" };
			foreach (var c in charsToRemove)
			{
				s = s.Replace(c, string.Empty);
			}
			return s;
		}

		public static string ReplaceSpecialChars(String s)
		{
			var charsToRemove = new string[] { "&quot;" };
			foreach (var c in charsToRemove)
			{
				switch (c) {
					case "&quot;":
						s = s.Replace(c, "\"");
						break;
				}
			}
			return s;
		}

		public static string DeleteEndArticle(String s)
		{
			string[] lines = Regex.Split(s,"Facebook0");
			return lines[0];
		}
	}
}
