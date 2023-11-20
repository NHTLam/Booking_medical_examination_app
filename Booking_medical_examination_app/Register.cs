using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_medical_examination_app
{
    public class Register
    {
        public User patient { get; set; }
        public ServicesEnum serviceName { get; set; }
        public string DoctorName { get; set; }
        public DateTime time { get; set; }
        public string reason { get; set; }
        public string result { get; set; }
        public IService service { get; set; }

        public Register(User users, ServicesEnum serviceName, string doctor, DateTime time, string reason, IService service)
        {
            this.patient = users;
            this.serviceName = serviceName;
            this.DoctorName = doctor;
            this.time = time;
            this.reason = reason;
            this.service = service;
        }

        public string Diagnose()
        {
            string str = "The results of this examination: " + this.result;
            return str;
        }

        public override string ToString()
        {
            string str = "Doctor Name: " + this.DoctorName +
            "\r\n- " + this.serviceName + ": " + this.service.name +
            "\r\n- Examination content: " + this.service.description +
            "\r\n- Exam start time: " + this.time +
            this.patient.ToString() +
            "\r\n- Reason: " + this.reason +
            "\r\n*** Total cost of examination: " + this.service.getPrice();
            return str;
        }
    }
}
