using DataAccess;
using Litmus.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Litmus.Controllers
{
    public class UnitController : Controller
    {
        LitmusRepository voterRepository = new LitmusRepository();

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserCode"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            MasterUnit mu = voterRepository.GetUnit(Convert.ToInt32(Session["UnitCode"]));

            MasterUnitModel model = new MasterUnitModel();

            if (mu != null)
            {

                model.Id = mu.Id;
                model.CompanyCode = mu.CompanyCode;
                model.Code = mu.Code;
                model.Name = mu.Name;
                model.Address = mu.Address;
                model.CrushingSeason = mu.CrushingSeason;
                model.ReportStartTime = mu.ReportStartTime;
                model.CrushingStartDate = mu.CrushingStartDate;
                model.CrushingEndDate = mu.CrushingEndDate;
                model.DayHours = mu.DayHours;
                model.EntryDate = mu.EntryDate;
                model.ProcessDate = mu.ProcessDate;
                model.NewMillCapacity = mu.NewMillCapacity;
                model.OldMillCapacity = mu.OldMillCapacity;
                model.IsActive = mu.IsActive;
                model.Createdy = mu.Createdy;
                model.CreatedDate = mu.CreatedDate;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}
