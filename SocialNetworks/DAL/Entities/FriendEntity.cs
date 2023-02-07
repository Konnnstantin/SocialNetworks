using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworks.DAL.Entities
{
    public class FriendEntity
    {
        public int id { get; set; }
        public int user_id { get; set; }

        public int friend_id { get; set; }
        
    }
}
