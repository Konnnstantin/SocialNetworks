using SocialNetworks.BLL.Exceptions;
using SocialNetworks.BLL.Models;
using SocialNetworks.DAL.Entities;
using SocialNetworks.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace SocialNetworks.BLL.Services
{
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;
        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }
        public IEnumerable<Friends> GetInComingByFriendId(int userId)
        {
            var friends = new List<Friends>();
            friendRepository.FindAllByUserId(userId).ToList().ForEach(_ =>
            {
                var sendUserUserEntity = userRepository.FindById(_.user_id);
                var receopientUserEntity = userRepository.FindById(_.friend_id);

                friends.Add(new Friends(_.id, sendUserUserEntity.email));
            });
            return friends;
        }
        public void AddingOrUpdateFriends(FriendSendingData friendSendingData)
        {
            if (String.IsNullOrEmpty(friendSendingData.RecipientEmail))
                throw new ArgumentException();
            

           var findUserEntity = this.userRepository.FindByEmail(friendSendingData.RecipientEmail);
      
            if (findUserEntity is null) throw new UserNotFoundException();
            var friendEntity = new FriendEntity()
            {
                user_id = friendSendingData.SenderId,
                friend_id= findUserEntity.friends_id
            };
            if(friendEntity.user_id == friendEntity.friend_id)
                throw new UserNotFoundException();
            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();

        }
    }
}



