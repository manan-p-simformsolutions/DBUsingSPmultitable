using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBapprochBySP.Models
{
    public class StudentList
    {
        public int StudentId { get; set; }
        public Nullable<int> ScholarshipId { get; set; }
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> Year { get; set; }

    }
}