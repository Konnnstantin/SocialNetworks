using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworks.BLL.Models
{
    public class FriendSendingData
    {
        public int SenderId { get; set; }
        public string RecipientEmail { get; set; }
    }
}
