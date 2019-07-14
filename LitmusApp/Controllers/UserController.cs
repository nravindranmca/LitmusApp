using DataAccess;
using System.Linq;
using Litmus.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace Litmus.Controllers
{
    public class UserController : Controller
    {
        LitmusRepository litmusRepo = new LitmusRepository();

        // GET: User
        public ActionResult Index()
        {
            if (Session["UserCode"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<MasterUserModel> lstUsers = new List<MasterUserModel>();

            var users = litmusRepo.GetMasterUsers();

            foreach (var user in users)
            {
                MasterUserModel masterUser = new MasterUserModel()
                {
                    Id = user.Id,
                    CompanyCode = user.CompanyCode,
                    UnitCode = user.UnitCode,
                    Code = user.Code,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsActive = user.IsActive,
                    CreatedDate = user.CreatedDate,
                    CreatedBy = user.CreatedBy
                };

                lstUsers.Add(masterUser);
            }

            return View(lstUsers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["UserCode"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new MasterUserModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterUserModel masterUser)
        {
            if (Session["UserCode"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                MasterUser userInfo = new MasterUser()
                {
                    Id = masterUser.Id,
                    CompanyCode = Convert.ToByte(masterUser.CompanyCode.ToString()),
                    UnitCode = masterUser.UnitCode,
                    Code = masterUser.Code,
                    FirstName = masterUser.FirstName,
                    LastName = masterUser.LastName,
                    Password = masterUser.Password,
                    IsActive = masterUser.IsActive,
                    CreatedDate = DateTime.Now,
                    CreatedBy = Session["UnitName"].ToString()
                };

                bool result = litmusRepo.AddMasterUser(userInfo);

                if (result)
                {
                    return RedirectToAction("Index");
                }

                return View("Error");

            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Session["UserCode"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var masterUser = litmusRepo.GetMasterUser(Id);

            MasterUserModel muModel = new MasterUserModel()
            {
                Id = masterUser.Id,
                CompanyCode = masterUser.CompanyCode,
                UnitCode = masterUser.UnitCode,
                Code = masterUser.Code,
                FirstName = masterUser.FirstName,
                LastName = masterUser.LastName,
                Password = masterUser.Password,
                IsActive = masterUser.IsActive,
                CreatedDate = masterUser.CreatedDate,
                CreatedBy = masterUser.CreatedBy
            };

            return View(muModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MasterUserModel masterUser)
        {
            if (Session["UserCode"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var usr = litmusRepo.GetMasterUser(masterUser.Id);


            if (ModelState.IsValid)
            {
                usr.CompanyCode = Convert.ToByte(masterUser.CompanyCode.ToString());
                usr.UnitCode = masterUser.UnitCode;
                usr.Code = masterUser.Code;
                usr.FirstName = masterUser.FirstName;
                usr.LastName = masterUser.LastName;
                usr.Password = masterUser.Password;
                usr.IsActive = masterUser.IsActive;

                bool result = litmusRepo.UpdateMasterUser(usr);

                if (!result)
                {
                    return View("Error");
                }

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["UserCode"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var masterUser = litmusRepo.GetMasterUser(id);

            MasterUserModel muModel = new MasterUserModel()
            {
                Id = masterUser.Id,
                CompanyCode = masterUser.CompanyCode,
                UnitCode = masterUser.UnitCode,
                Code = masterUser.Code,
                FirstName = masterUser.FirstName,
                LastName = masterUser.LastName,
                Password = masterUser.Password,
                IsActive = masterUser.IsActive,
                CreatedDate = masterUser.CreatedDate,
                CreatedBy = masterUser.CreatedBy
            };

            return View(muModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserCode"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            bool result = litmusRepo.DeleteMasterUser(id);

            if (!result)
            {
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}