using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking_medical_examination_app
{
    public class GeneralExamination : IService
    {
        public string name { get ; set ; }
        public decimal price { get ; set ; }
        public string description { get; } = "Examination, Diagnosis, Treatment, etc.";

        public GeneralExamination()
        {
            this.name = "Unknow";
            this.price = 0;
        }

        public GeneralExamination(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public void register(User user, string doc, IService s)
        {
            CheckValidation c = new CheckValidation();
            Console.WriteLine("Select the date you want to see the doctor, Please enter in the format : 21-03-2022 13:26");
            Console.Write("Your choice: ");
            DateTime option = c.CheckTime();
            Console.WriteLine("Reason for visit (how does your body feel, where it hurts, what's wrong, etc.)");
            Console.WriteLine("Answer: ");
            string reason = Console.ReadLine();
            user.CreateFormRegister(user, ServicesEnum.SpecializedExamination, doc, option, reason, s);
        }

        public string selectOption()
        {
            CheckValidation c = new CheckValidation();
            string[] nameOption2 = { "Basic examination", "Advanced examination", "For Children", "For elderly" };
            Console.WriteLine("Please select the service you want:");
            for (int i = 0; i < nameOption2.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + nameOption2[i]);
            }
            Console.Write("Your option: ");
            //int option1 = int.Parse(Console.ReadLine());
            int option1 = c.CheckOption(nameOption2.Length);

            return nameOption2[option1 - 1];
        }

        public decimal getPrice()
        {
            if (name.Equals("Basic examination"))
                return price = 450000;
            else if (name.Equals("Advanced examination"))
                return price = 650000;
            else if (name.Equals("For Children"))
                return price = 400000;
            else
                return price = 400000;
        }
    }
}
