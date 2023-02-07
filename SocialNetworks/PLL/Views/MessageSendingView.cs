using SocialNetworks.BLL.Exceptions;
using SocialNetworks.BLL.Models;
using SocialNetworks.BLL.Services;
using SocialNetworks.DAL.Entities;
using SocialNetworks.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworks.PLL.Views
{
    public class MessageSendingView
    {
        UserService userService;
        MessageService messageService;
       public MessageSendingView(UserService userService, MessageService messageService)
        {
            this.userService = userService;
            this.messageService = messageService;
        }

        public void Show(User user)
        {
            var messageSendingData = new MessageSendingData();
            Console.WriteLine("Введите почтовый адрес получателя");
            messageSendingData.RecipientEmail = Console.ReadLine();

            Console.WriteLine("Введите сообщение(не больше 5000 символов");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.SenderId = user.Id;

            try
            {
                messageService.SendMessage(messageSendingData);
                SuccessMessage.Show("Сообщение успешно отправлено!");
                user = userService.FindById(user.Id);
            }
            catch(UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
            catch(ArgumentException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }
            catch(Exception)
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
            }
        }
    }
}
