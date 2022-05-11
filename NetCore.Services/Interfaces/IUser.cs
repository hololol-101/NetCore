using NetCore.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Services.Interfaces
{
    public interface IUser
    {
        //실제 사용할 서비스메서드 선언
        bool MatchTheUserInfo(LoginInfo login); //정보가 일치하는지 확인하는 메서드
    }
}
