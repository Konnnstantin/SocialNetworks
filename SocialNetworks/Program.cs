using SocialNetworks.BLL.Exceptions;
using SocialNetworks.BLL.Models;
using SocialNetworks.BLL.Services;
using SocialNetworks.PLL.Views;
using System;
using System.Reflection.Metadata;

namespace SocialNetworks
{
    public class Program
    {
        static MessageService messageService;
        static UserService userService;
        static FriendService friendService;

        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        public static UserFriendsView userFriendsView;
        public static UserAddingFrendsView userAddingFrendsView;
        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();
            friendService = new FriendService();

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView (userService, messageService);
            userFriendsView = new UserFriendsView(userService,friendService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();
            userAddingFrendsView = new UserAddingFrendsView();


            while (true)
            {
                mainView.Show();
                
            }

        }
    }
}
