using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptAPet.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        /// <summary>
        /// Taxpayer Identification Number
        /// </summary>
        public string TIN { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
