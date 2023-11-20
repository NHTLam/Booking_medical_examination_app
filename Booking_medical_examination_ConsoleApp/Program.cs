
using Booking_medical_examination_app;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Booking_medical_examination_ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            CheckValidation c = new CheckValidation();
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("|                                                                    |");
            Console.WriteLine("|                   Booking medical examination app                  |");
            Console.WriteLine("|                                                                    |");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");

            Console.WriteLine("Log in to the software:");
            Console.Write("Name: ");
            string name = c.CheckString(Console.ReadLine());
            Console.Write("YoB: ");
            int yob = c.CheckNumber();
            Console.Write("Phone: ");
            string phone = c.CheckPhone(Console.ReadLine());
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Gender: male/female/other: ");
            string gender = c.CheckGender(Console.ReadLine());

            User newUser = new User(name, phone, yob, address, gender);
            dummyHistory dummy = new dummyHistory();
            dummy.DummyData(newUser);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------");

            int o = -1;
            do
            {
                try
                {
                    Console.WriteLine("Option 1: Schedule an appointment for a specialist");
                    Console.WriteLine("Option 2: Schedule a general medical examination");
                    Console.WriteLine("Option 3: Schedule a medical test");
                    Console.WriteLine("Option 4: View appointment schedule");
                    Console.WriteLine("Option 5: View medical history");
                    Console.WriteLine("Option 6: Refresh History");
                    Console.WriteLine("Option 7: Diagnosis of current body condition based on medical history");
                    Console.WriteLine("Option 0: Exit program");
                    Console.WriteLine("----------------------------------------------------------------------");

                    Console.Write("Please choose an option:");
                    o = int.Parse(Console.ReadLine());

                    switch (o)
                    {
                        case 1:
                            IServiceFactory service1 = new SpecializedExaminationF();
                            IService s1 = service1.CreateService("", 1);
                            s1 = service1.CreateService(s1.selectOption(), s1.getPrice());
                            s1.register(newUser, newUser.selectDoctor(), s1);

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("----------------------------------------------------------------------");
                            break;
                        case 2:
                            IServiceFactory service2 = new GeneralExaminationF();
                            IService s2 = service2.CreateService("", 1);
                            s2 = service2.CreateService(s2.selectOption(), s2.getPrice());
                            s2.register(newUser, newUser.selectDoctor(), s2);

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("----------------------------------------------------------------------");
                            break;
                        case 3:
                            IServiceFactory service3 = new MedicalTestF();
                            IService s3 = service3.CreateService("", 1);
                            s3 = service3.CreateService(s3.selectOption(), s3.getPrice());
                            s3.register(newUser, newUser.selectDoctor(), s3);

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("----------------------------------------------------------------------");
                            break;
                        case 6:
                            newUser.RefreshHistory();

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("----------------------------------------------------------------------");
                            break;
                        case 5:
                            newUser.ViewMedicalHistory();

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("----------------------------------------------------------------------");
                            break;
                        case 7:
                            newUser.GetOverallResult();

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("----------------------------------------------------------------------");
                            break;
                        case 4:
                            newUser.ViewAppointmentSchedule();

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("----------------------------------------------------------------------");
                            break;
                        case 0:
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("----------------------------------------------------------------------");
                            Console.WriteLine("Exit !!!");
                            break;
                        default:
                            Console.WriteLine("Something went wrong");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("----------------------------------------------------------------------");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong!!!");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------------");
                }
            } while (o != 0);             
        }
    }
}
