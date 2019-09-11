using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entity;
using Dal.Helper;
using Models;

namespace Dal.Repository
{
    public class UserRepository
    {
        private EventsContext _dbContext = new EventsContext();

        public List<UserDto> GetAllUsers()
        {
            return Mapper.ToUserDtoList(_dbContext.Users.ToList());
        }
        public UserDto GetUserByUsername(string name)
        {
            return Mapper.ToUserDto(_dbContext.Users.Where(x => x.FullName == name).First());
        }
        public UserDto GetUserById(int? id)
        {
            return Mapper.ToUserDto(_dbContext.Users.Find(id));
        }

        public Boolean UserExists(UserAccountDto user)
        {
            UserAccount ua=Mapper.ToUserAccount(user);
            Boolean result = _dbContext.UserAccounts.Where(
                                    x => x.EmailID.Equals(ua.EmailID)).
                                    SingleOrDefault() != null ? true : false;
            return result;
        }

        public UserDto IsValidUser(UserAccountDto user)
        {
            UserAccount ua=Mapper.ToUserAccount(user);
            UserAccount IsValidUserAccount = _dbContext.UserAccounts.Where(
                                    x => x.EmailID.Equals(ua.EmailID)
                                    && x.Password.Equals(ua.Password)).SingleOrDefault();
            if(IsValidUserAccount == null)
            {
                return null;
            }
            return GetUserFromUserAccount(Mapper.ToUserAccountDto(IsValidUserAccount));
        }

        public UserDto GetUserFromUserAccount(UserAccountDto user)
        {
            UserAccount ua=Mapper.ToUserAccount(user);
            User userDetail = _dbContext.Users.Where(x => x.UserAccount.UserAccountID == ua.UserAccountID).SingleOrDefault();
            return Mapper.ToUserDto(userDetail);
        }

        public void CreateUser(UserDto user)
        {
            _dbContext.Users.Add(Mapper.ToUser(user));
            _dbContext.SaveChanges();
        }

        public void DeleteUser(UserDto user)
        {
            _dbContext.Users.Remove(Mapper.ToUser(user));
            _dbContext.SaveChanges();
        }

        public void EditUser(UserDto user, int id)
        {
            User usr = _dbContext.Users.Find(id);
            usr = Mapper.ToUser(user);
            _dbContext.SaveChanges();
        }


       

    }
}
