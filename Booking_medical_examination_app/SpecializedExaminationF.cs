using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_medical_examination_app
{
    public class SpecializedExaminationF : IServiceFactory
    {
        public IService CreateService(string name, decimal price)
        {
            SpecializedExamination s = new SpecializedExamination(name, price);
            return s;
        }
    }
}
