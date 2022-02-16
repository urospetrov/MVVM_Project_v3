using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarpAlgorithm
{
    public class RabinKarp
    {
        int mod = 64811;
        public int GetPatternCount(string baseString, string pattern)
        {
            int baseStringLen = baseString.Length;
            int patternLen = pattern.Length;

            if (patternLen > baseStringLen)
            {
                return 0;
            }

            char[] possibleMatchChar = baseString.Substring(0, patternLen).ToCharArray();

            int patternHash = HashMethod(pattern);

            int matchCount = 0;
            int rollingHashValue = 0;

            int j = 0;
            int power = patternLen - 1;

            bool isMatch = false;

            rollingHashValue = HashMethod(new string(possibleMatchChar));
            if (rollingHashValue == patternHash)
            {
                isMatch = pattern.Equals(new string(possibleMatchChar));
                if (isMatch == true)
                    matchCount++;
            }

            for (int i = 1; i <= baseStringLen - patternLen; i++)
            {
                j = 0;
                isMatch = false;
                
                possibleMatchChar = baseString.Substring(i, patternLen).ToCharArray();

                rollingHashValue = (((rollingHashValue - ((baseString[i - 1] * (int)Math.Pow(2, power)) % mod) + mod) % mod * 2) + baseString[i + patternLen - 1]) % mod;

                if ((rollingHashValue == patternHash))
                {
                    isMatch = pattern.Equals(new string(possibleMatchChar));
                    if (isMatch == true)
                        matchCount++;
                }
            }
            return matchCount;
        }
        private int HashMethod(string str)
        {
            int sum = 0;
            int power = str.Length - 1;
            foreach (char c in str)
            {
                sum += c * (int)Math.Pow(2, power);
                power--;
            }
            sum = sum % mod;
            return sum;
        }
    }
}
