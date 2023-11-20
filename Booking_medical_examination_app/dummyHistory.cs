using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_medical_examination_app
{
    public class dummyHistory
    {
        public void DummyData(User user)
        {
            ServicesEnum serviceName = ServicesEnum.SpecializedExamination;
            string doctor = "Tung Lam";
            DateTime time = DateTime.Parse("21 - 10 - 2022 13:26");
            string reason = "no";

            IServiceFactory service = new SpecializedExaminationF();
            IService s = service.CreateService("Osteoarthritis", 500000);

            Random random = new Random();
            string result;
            
            for (int i = 0; i < 5; i++) 
            {
                int r = random.Next(3);
                if (r == 0)
                {
                    result = "good";
                }
                else if (r == 1)
                {
                    result = "normal";
                }
                else
                {
                    result = "bad";
                }
                user.CreateFormRegisterForDummy(user, serviceName, doctor, time, reason, s, result);
                time = time.AddDays(10);
            }
        }
    }
}
