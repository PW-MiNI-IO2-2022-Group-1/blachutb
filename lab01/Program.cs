using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static int Calculate(string str)
        {
            int sum = 0;
            List<string> delimiters = new List<string>{ ",", "\n" };
            string[] arr;

            if (str.Length == 0)
                return 0;

            if (str[0] == '/' && str[1] == '/')
            {
                string d;
                var first_line = str.Split('\n', 2)[0].Substring(2);

                if (first_line.StartsWith('['))
                    d = first_line.Substring(1, first_line.Length - 2);
                else
                    d = first_line;
                
                delimiters.Add(d);
                str = str.Split('\n', 2)[1];
            }

            arr = str.Split(delimiters.ToArray(), StringSplitOptions.None);

            foreach (var item in arr)
            {
                int n = Int32.Parse(item);

                if (n < 0)
                    throw new ArgumentException("argument " + n + " is less than 0");

                if (n > 1000)
                    n = 0;

                sum += n;
            }
                
            return sum;
        }
    }
}
