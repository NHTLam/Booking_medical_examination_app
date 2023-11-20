using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Booking_medical_examination_app
{
    public class User
    {
        public string name { get; set; }
        public int yob { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string gender { get; set; }

        List<Register> registers = new List<Register>();
        public User(string name, string phone, int yob, string address, string gender)
        {
            this.name = name;
            this.phone = phone;
            this.yob = yob;
            this.address = address;
            this.gender = gender;
        }

        public void CreateFormRegister(User user, ServicesEnum serviceName, string doctor, DateTime time, string reason, IService service)
        {
            Register r = new Register(user, serviceName, doctor, time, reason, service);
            Console.Write("Registration confirmation (Y/N), Your option: ");
            string confirm = Console.ReadLine();
            if (confirm.Equals("Y"))
            {
                registers.Add(r);
                if (registers.Count > 0)
                {
                    Console.WriteLine("Successful registration !!!");
                }
            }
            else
            {
                Console.WriteLine("Successfully canceled registration !");
            }
        }

        public void RefreshHistory()
        {
            Random random = new Random();
            int checkNull = 0;
            Console.WriteLine("Update the results of this examination: ");
            Console.Write("Waiting for results: ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine();
            foreach (Register r in registers)
            {
                if (r.result == null)
                {
                    int result = random.Next(3);
                    if (result == 0)
                    {
                        r.result = "good";
                    }
                    else if (result == 1)
                    {
                        r.result = "normal";
                    }
                    else
                    {
                        r.result = "bad";
                    }
                }
                else
                {
                    checkNull++;
                }
            }

            if (checkNull == registers.Count)
            {
                Console.WriteLine("History is the latest");
            }
            else
            {
                Console.WriteLine("Update success history !!!");
            }
            Console.WriteLine("----------------------------------------------------------------------");
        }

        public void ViewAppointmentSchedule()
        {
            int i = 0, checkNoNull = 0;
            foreach (Register r in registers)
            {
                if (r.result == null)
                {
                    Console.WriteLine(i + 1 + ".");
                    Console.WriteLine(r);
                    Console.WriteLine("----------------------------------------------------------------------");
                    i++;
                }
                else
                {
                    checkNoNull++;
                }
            }

            if (checkNoNull == registers.Count)
            {
                Console.WriteLine("No appointment schedule");
            }
        }

        public void ViewMedicalHistory()
        {
            int i = 0, checkNull = 0;
            string draw = "";
            foreach (Register r in registers)
            {
                if (r.result != null)
                {
                    Console.WriteLine(i + 1 + ".");
                    Console.WriteLine(r);
                    Console.WriteLine(r.Diagnose());
                    Console.WriteLine("----------------------------------------------------------------------");
                    i++;
                }
                else
                {
                    checkNull++;
                }
            }

            if(checkNull == registers.Count)
            {
                Console.WriteLine("No History");
            }

            foreach (Register r in registers)
            {
                if (r.result != null)
                {
                    if (r.result == "good")
                    {
                        draw = "*******";
                        Console.Write(r.time + ": ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(draw);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (r.result == "normal")
                    {
                        draw = "*****";
                        Console.Write(r.time + ": ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(draw);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        draw = "***";
                        Console.Write(r.time + ": ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(draw);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }

        public void GetOverallResult()
        {
            int count = 0,good = 0,normal = 0,bad = 0;
            foreach (Register r in registers)
            {
                if (r.result != null)
                {
                    if (r.result.Equals("good"))
                        good++;
                    else if (r.result.Equals("normal"))
                        normal++;
                    else
                        bad++;
                    count++;    
                }
            }
            Console.WriteLine("So far, your visits to the doctor are: " + count);
            Console.Write("Based on statistics from your medical history, your current health diagnosis is: ");
            if (good >= normal && good >= bad)
            {
                Console.WriteLine("Your health is still very good right now.");
            }
            else if (normal >= bad)
            {
                Console.WriteLine("Your health is currently at a normal level.");
            }
            else
            {
                Console.WriteLine("Your health is currently quite bad.");
            }

            Console.WriteLine("\nList the services you have examined: ");
            Console.WriteLine("Service: Specialized examination" +
                "\r\nOsteoarthritis       - 500000 : " + Statistical("Osteoarthritis") +
                "\r\nCardiology           - 450000 : " + Statistical("Cardiology") +
                "\r\nDermatology          - 550000 : " + Statistical("Dermatology") +
                "\r\nMaternity            - 350000 : " + Statistical("Maternity") +
                "\r\n\r\nService: General examination" +
                "\r\nBasic examination    - 450000 : " + Statistical("Basic examination") +
                "\r\nAdvanced examination - 650000 : " + Statistical("Advanced examination") +
                "\r\nFor Children         - 400000 : " + Statistical("For Children") +
                "\r\nFor elderly          - 400000 : " + Statistical("For elderly") +
                "\r\n\r\nService: Medical test" +
                "\r\nBlood test           - 300000 : " + Statistical("Blood test") +
                "\r\nCancer test          - 400000 : " + Statistical("Cancer test") +
                "\r\nAllergy test         - 250000 : " + Statistical("Allergy test"));
        }
        
        private int Statistical(string nameServiceOption)
        {
            int check = 0;
            foreach (Register r in registers)
            {
                if (nameServiceOption.Equals(r.service.name))
                {
                    check++;
                }
            }
            return check;
        }

        public string selectDoctor()
        {
            CheckValidation c = new CheckValidation();
            Console.WriteLine("List of doctors:");
            string[] doctorName = { "Tung Lam", "Van Hue", "Tuan Anh", "Duy Minh" };
            for(int i = 0; i< doctorName.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + doctorName[i]);
            }
            Console.Write("Select doctor: ");
            //int option = int.Parse(Console.ReadLine());
            int option = c.CheckOption(doctorName.Length);

            string doctor = doctorName[option - 1];
            return doctor;
        }

        public void CreateFormRegisterForDummy(User user, ServicesEnum serviceName, string doctor, DateTime time, string reason, IService service, string result)
        {
            Register r = new Register(user, serviceName, doctor, time, reason, service);
            r.result = result;
            registers.Add(r);
        }

        public override string ToString()
        {
            string str = "\r\n\r\nRegistrant Information:\r\n" +
                "- Name: " + this.name +
                "\r\n- Age:" + (DateTime.Now.Year - this.yob) +
                "\r\n- Phone: " + this.phone +
                "\r\n- gender: " + this.gender +
                "\r\n- address: " + this.address;
            return str;
        }
    }
}
