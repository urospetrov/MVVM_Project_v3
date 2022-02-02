using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarpAlgorithm
{
    public class RabinKarp
    {
        int mod = 113;
        public int GetPatternCount(string baseString, string pattern)
        {
            int baseStringLen = baseString.Length;
            int patternLen = pattern.Length;

            char[] possibleMatchChar = new char[patternLen];

            int patternHash = HashMethod(pattern);

            int cnt = 0;
            int sum = 0;

            int i, j = 0;
            int pwr = patternLen - 1;

            bool match = false;

            while (j < patternLen)
            {
                possibleMatchChar[j] = baseString[j];
                j++;
            }

            sum = HashMethod(new string(possibleMatchChar));

            //1.
            if (sum == patternHash)
                match = pattern.Equals(new string(possibleMatchChar));
            if (match == true)
                cnt++;

            for (i = 1; i <= baseStringLen - patternLen; i++)
            {
                j = 0;
                match = false;

                while (j < patternLen - 1)
                {
                    possibleMatchChar[j] = possibleMatchChar[j + 1];
                    j++;
                }
                possibleMatchChar[patternLen - 1] = baseString[i + patternLen - 1];
                sum = (((sum - ((baseString[i - 1] * (int)Math.Pow(10, pwr)) % mod) + mod) % mod * 10) + baseString[i + patternLen - 1]) % mod;

                //Completely same as 1., could be method
                if (sum == patternHash)
                    match = pattern.Equals(new string(possibleMatchChar));
                if (match == true)
                    cnt++;
            }
            return cnt;
        }
        private int HashMethod(string str)
        {
            int sum = 0;
            int pwr = str.Length - 1;
            foreach (char c in str)
            {
                sum += c * (int)Math.Pow(10, pwr);
                pwr--;
            }
            sum = sum % mod;
            return sum;
        }
    }
}
