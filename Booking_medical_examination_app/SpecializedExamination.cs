using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_medical_examination_app
{
    public class SpecializedExamination : IService
    {
        public string name { get ; set; }
        public decimal price { get ; set ; }
        public string description { get; } = "Examination, X-ray, Diagnosis, list of cures, etc.";

        public SpecializedExamination()
        {
            name = "Unknow";
            price = 0;
        }
        public SpecializedExamination(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public void register(User user, string doctor, IService service)
        {
            CheckValidation c = new CheckValidation();
            Console.WriteLine("Select the date you want to see the doctor, Please enter in the format : 21-03-2022 13:26");
            Console.Write("Your choice: ");
            //DateTime option = DateTime.Parse(Console.ReadLine());
            DateTime option = c.CheckTime();
            Console.WriteLine("Reason for visit (how does your body feel, where it hurts, what's wrong, etc.)");
            Console.WriteLine("Answer: ");
            string reason = Console.ReadLine();
            user.CreateFormRegister(user, ServicesEnum.SpecializedExamination, doctor, option, reason, service);
        }

        public string selectOption()
        {
            CheckValidation c = new CheckValidation();
            string[] nameSpecialized = { "Osteoarthritis", "Cardiology", "Dermatology", "Maternity" };
            Console.WriteLine("Please select the specialty you want to visit:");
            for (int i = 0; i < nameSpecialized.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + nameSpecialized[i]);
            }
            Console.Write("Your option: ");
            //int option = int.Parse(Console.ReadLine());
            int option = c.CheckOption(nameSpecialized.Length);

            return nameSpecialized[option - 1];
        }

        public decimal getPrice()
        {
            if (name.Equals("Osteoarthritis"))
                return price = 500000;
            else if (name.Equals("Cardiology"))
                return price = 450000;
            else if (name.Equals("Dermatology"))
                return price = 550000;
            else
                return price = 350000;
        }
    }
}
