using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_medical_examination_app
{
    public class MedicalTest : IService
    {
        public string name { get ; set ; }
        public decimal price { get ; set ; }

        public string description { get; } = "none";

        public MedicalTest(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public void register(User u, string doc, IService s)
        {
            CheckValidation c = new CheckValidation();
            Console.WriteLine("Select the date you want to see the doctor, Please enter in the format : 21-03-2022 13:26");
            Console.Write("Your choice: ");
            DateTime option = c.CheckTime();
            Console.WriteLine("Reason for visit (how does your body feel, where it hurts, what's wrong, etc.)");
            Console.WriteLine("Answer: ");
            string reason = Console.ReadLine();
            u.CreateFormRegister(u, ServicesEnum.SpecializedExamination, doc, option, reason, s);
        }

        public string selectOption()
        {
            CheckValidation c = new CheckValidation();
            string[] nameOption3 = { "Blood test", "Cancer test", "Allergy test" };
            Console.WriteLine("Please select the service you want:");
            for (int i = 0; i < nameOption3.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + nameOption3[i]);
            }
            Console.Write("Your option: ");
            //int option2 = int.Parse(Console.ReadLine());
            int option2 = c.CheckOption(nameOption3.Length);

            return nameOption3[option2 - 1];
        }

        public decimal getPrice()
        {
            if (name.Equals("Blood test"))
                return price = 300000;
            else if (name.Equals("Cancer test"))
                return price = 400000;
            else
                return price = 250000;
        }
    }
}
