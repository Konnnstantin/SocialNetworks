using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SocialNetworks.BLL.Models
{
    public class Friends
    {
        public int Id { get; set; }
        public string RecipientEmail { get; set; }
       

        public Friends(int id, string recipientEmail)
        {
            Id = id;
            RecipientEmail = recipientEmail;
        }
    }
}
