using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u24789730_Inf272_Prac9.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ClubName { get; set; }
        public int Age { get; set; }
        public decimal MembershipFee { get; set; }
    }
} 