using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDRentalsSystem
{
    class Validation
    {
        public Validation()
        {

        }

        public static Boolean textIsEmpty(String text)
        {
            Boolean check = false;

            if(text != "")
            {
                check = false;
            }
            else
            {
                check = true;
            }

            return check;
        }

        public static Boolean hasDigits(String text)
        {
            Boolean valid = false;
            Char[] ch = new Char[text.Length];

            ch = text.ToCharArray();

            for(int i = 0; i < text.Length; i++)
            {
                if(Char.IsDigit(ch[i]))
                {
                    return true;
                }
                else
                {
                    valid = false;
                }
            }
            return valid;
        }

        public static Boolean allDigits(String text)
        {
            int digits = 0;

            Char[] ch = new Char[text.Length];

            ch = text.ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(ch[i]))
                {
                    digits++;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static Boolean isEmail(String text)
        {
            Boolean chars = false;
            Boolean fullStops = false;
            Boolean at = false;

            Char[] ch = new Char[text.Length];

            ch = text.ToCharArray();
            for(int i = 0;i < text.Length; i++)
            {
                if (Char.IsLetter(ch[i]) || Char.IsDigit(ch[i]))
                {                    
                   chars = true;
                }
                if(chars)
                {
                    if(ch[i] == '@')
                    {
                        at = true;
                    }
                    if (chars && at)
                    {
                        if (ch[i] == '.')
                        {
                            fullStops = true;
                        }
                        if (chars && fullStops && at)
                        {
                            return true;
                        }
                    }
                }
            }                
            return false;
        }
    }
}
