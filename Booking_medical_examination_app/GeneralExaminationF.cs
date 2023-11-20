using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_medical_examination_app
{
    public class GeneralExaminationF : IServiceFactory
    {
        public IService CreateService(string name, decimal price)
        {
            GeneralExamination generalExamination = new GeneralExamination(name, price);
            return generalExamination;
        }
    }
}
