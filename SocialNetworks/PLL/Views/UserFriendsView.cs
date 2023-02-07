using SocialNetworks.BLL.Exceptions;
using SocialNetworks.BLL.Models;
using SocialNetworks.BLL.Services;
using SocialNetworks.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworks.PLL.Views
{
    public class UserFriendsView
    {
        UserService userService;
        FriendService friendService;
        public UserFriendsView(UserService userService, FriendService friendService)
        {
            this.userService = userService;
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            var frendAddData = new FriendSendingData();
            Console.WriteLine("Введите почтовый адрес пользователя которого хотите добавить");
            frendAddData.RecipientEmail = Console.ReadLine();

            frendAddData.SenderId = user.Id;
            try
            {
                friendService.AddingOrUpdateFriends(frendAddData);
                SuccessMessage.Show("Пользователь успешно добавлен");
                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавление пользователя!");
            }
        }
    }
}


