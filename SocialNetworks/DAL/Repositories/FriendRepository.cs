using SocialNetworks.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworks.DAL.Repositories
{
    public class FriendRepository : BaseRepositories, IFriendRepository
    {
        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            return Query<FriendEntity>(@"select * from friends where user_id = :user_id", new { user_id = userId });
        }

        public int Update(FriendEntity friendEntity)
        {
            return Execute(@"update friends set user_id = :user_id, friend_id = :friend_id", friendEntity);
        }

        public int Create(FriendEntity friendEntity)
        {
            return Execute(@"insert into friends (user_id,friend_id) values (:user_id,:friend_id)", friendEntity);
        }

        public int Delete(int id)
        {
            return Execute(@"delete from friends where id = :id_p", new { id_p = id });
        }
    }

    public interface IFriendRepository
    {
        int Create(FriendEntity friendEntity);
        IEnumerable<FriendEntity> FindAllByUserId(int userId);
        int Delete(int id);
    }
}


