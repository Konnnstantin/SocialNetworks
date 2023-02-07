using SocialNetworks.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworks.PLL.Views
{
    public class UserAddingFrendsView
    {
        public void Show(IEnumerable<Friends> addFriends)
        {
            Console.WriteLine("Ваши Друзья: ");


            if (addFriends.Count() == 0)
            {
                Console.WriteLine("У вас нет друзей");
                return;
            }
          
            addFriends.ToList().ForEach(_ =>
            {
                Console.WriteLine("Пользователь теперь ваш друг: {0}", _.RecipientEmail);
            });
        }
    }
}
