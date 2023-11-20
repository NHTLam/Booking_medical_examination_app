using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_medical_examination_app
{
    public class CheckValidation
    {
        public string CheckString(string input)
        {
            int checkAlphabet = 0;
            int checkSpace = 0;
            for (int i = 0; i < input.Length; i++)
            {
                bool check = char.IsLetter(input[i]);
                bool checkS = char.IsWhiteSpace(input[i]);
                if (check)
                    checkAlphabet++;
                if (checkS)
                {
                    checkAlphabet++;
                    checkSpace++;
                }
            }

            if (checkSpace == input.Length)
            {
                Console.Write("You are leaving blank, please re-enter: ");
                return CheckString(Console.ReadLine());
            }
            else if (checkAlphabet == input.Length)
            {
                return input;
            }
            else
            {
                Console.Write("Cannot contains numbers or special chars, please re-enter: ");
                return CheckString(Console.ReadLine());
            }
        }

        public int CheckNumber()
        {
            while (true)
            {
                int yob;
                try
                {
                    yob = int.Parse(Console.ReadLine());
                    if (yob >= 1950)
                        return yob;
                    else
                    {
                        Console.Write("Age must be above 1950, please re-enter: ");
                        return CheckNumber();
                    }
                }
                catch (Exception)
                {
                    Console.Write("Something went wrong, Please re-enter: ");
                }
            }
        }

        public string CheckPhone(string input)
        {
            int checkPhone = 0;
            for (int i = 0; i < input.Length; i++)
            {
                bool check = char.IsDigit(input[i]);
                if (check)
                    checkPhone++;
            }

            if (checkPhone == input.Length)
            {
                return input;
            }
            else
            {
                Console.Write("Something went wrong, please re-enter: ");
                return CheckPhone(Console.ReadLine());
            }
        }

        public string CheckGender(string input)
        {
            if (input.Equals("male") || input.Equals("female") || input.Equals("other"))
            {
                return input;
            }
            else
            {
                Console.Write("Please only choose 3 option male, female or other, Re-enter: ");
                return CheckGender(Console.ReadLine());
            }
        }

        public int CheckOption(int n)
        {
            while (true)
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if(input <= n && input > 0)
                        return input;
                    else
                    {
                        Console.Write("Something went wrong, please re-enter: ");
                        return CheckOption(n);
                    }
                }
                catch
                {
                    Console.Write("Something went wrong, please re-enter: ");
                    return CheckOption(n);
                }
            }
        }

        public DateTime CheckTime()
        {
            while (true)
            {
                try
                {
                    DateTime input = DateTime.Parse(Console.ReadLine());
                    return input;
                }
                catch
                {
                    Console.Write("Something went wrong, please re-enter: ");
                    return CheckTime();
                }
            }
        }
    }
}
