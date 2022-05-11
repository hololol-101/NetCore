using NetCore.Data.DataModels;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCore.Services.Svcs
{
    public class UserServices : IUser
    {
        #region private methods

        private IEnumerable<User> GetUserInfos() {
            return new List<User>() {
                new User(){
                    UserId="RiverIs",
                    UserEmail="kangeun.noh@lotte.net",
                    UserName="Kawa",
                    Password="181818",
                    JoinedUtcDate=DateTime.Now
                }                
            };
        }
        private bool checkTheUserInfo(string userid, string password) {
            return GetUserInfos().Where(u => u.UserId.Equals(userid) && u.Password.Equals(password)).Any();
        }
        #endregion

        bool IUser.MatchTheUserInfo(LoginInfo login)
        {
            return checkTheUserInfo(login.UserId, login.Password);
        }
    }

}
