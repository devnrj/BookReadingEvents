using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Repository;
using Models;

namespace Service
{
    public class UserService
    {
        static UserRepository userOperations = new UserRepository();
        public static List<UserDto> getAllUsers()
        {
            return userOperations.GetAllUsers();
        }
        public static UserDto GetUserByUsername(string name)
        {
            return userOperations.GetUserByUsername(name);
        }
        public static UserDto IsValidUser(UserAccountDto user)
        {
            return userOperations.IsValidUser(user);
        }

        public static Boolean UserExists(UserAccountDto user)
        {
            return userOperations.UserExists(user);
        }
        public static UserDto GetUserById(int? id)
        {
            return userOperations.GetUserById(id);
        }
        public static void CreateUser(UserDto user)
        {
            userOperations.CreateUser(user);
        }
    }
}
