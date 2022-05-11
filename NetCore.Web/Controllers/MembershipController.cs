using Microsoft.AspNetCore.Mvc;
using NetCore.Data.ViewModels;
using NetCore.Services.Interfaces;
using NetCore.Services.Svcs;
using NetCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Web.Controllers
{
    public class MembershipController : Controller
    {
        //의존성 주입 - .net core에서 기본적으로 제공하는 생성자 주입 방식 사용
        private IUser _user;
        public MembershipController(IUser user) {
            //user 값을 startup class 에서 가져온다
            _user = user;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginInfo login)
        {
            string message = string.Empty;
            if (ModelState.IsValid) {

                //서비스 부분 프로젝트로 관리 -> 재사용, 효율성 올라감
                if(_user.MatchTheUserInfo(login))
                {
                    TempData["Message"] = "로그인이 성공적으로 이루어졌습니다.";

                    return RedirectToAction("Index", "Membership");

                }
                else {
                    message = "로그인되지 않았습니다.";
                }

            }
            else{
                message = "로그인정보를 올바르게 입력하세요.";
            }
            ModelState.AddModelError(string.Empty, message);
            return View(login);
        }
    }
}
