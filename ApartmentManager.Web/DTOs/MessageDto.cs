using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmentManager.Web.DTOs
{
    public class MessageDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
    }
}
