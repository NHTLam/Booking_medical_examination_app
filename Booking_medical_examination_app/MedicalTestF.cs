using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_medical_examination_app
{
    public class MedicalTestF : IServiceFactory
    {
        public IService CreateService(string name, decimal price)
        {
            MedicalTest medicalTest = new MedicalTest(name, price);
            return medicalTest;
        }
    }
}
