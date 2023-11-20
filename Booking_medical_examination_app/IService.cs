using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_medical_examination_app
{
    public interface IService
    {
        string name { get; set; }
        decimal price { get; set; }
        string description { get; }

        void register(User u, string doc, IService s);

        string selectOption();

        decimal getPrice();
    }
}
