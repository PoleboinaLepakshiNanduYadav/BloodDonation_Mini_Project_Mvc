using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using BloodDonation_Mini_Project_Mvc.Models;

namespace BloodDonation_Mini_Project_Mvc.Controllers
{
    public class DataController : Controller
    {
        string constr = @"server=NANDUYADAV\SQLEXPRESS;user id=sa;password=Lepakshi;database=WebApplications";
        SqlConnection con;SqlCommand cmd;
        SqlDataReader Dr;
        BloodOperations BO = new BloodOperations();
        public BloodData BD = new BloodData();
        // GET: Data
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(BloodData BD)
        {
            con = new SqlConnection(constr);
            string Query = "Select * From BloodDetails Where Id=@p1 and Password=@p2";
            cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@p1", BD.Id);
            cmd.Parameters.AddWithValue("@p2", BD.Password);
            con.Open();
            Dr = cmd.ExecuteReader();
            if (Dr.Read())
            {
                return RedirectToAction("Home");
            }
            else
            {
                ViewBag.Message = "Invalid Credentials";
            }
            con.Close();
            return View();
        }
        public ActionResult BloodRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BloodRegistration(BloodData BD)
        {
            if(ModelState.IsValid)
            {
                BO.Insert(BD);
                ViewBag.Message = "Successfully Registered";
            }
            else
            {
                ViewBag.Message = "Invalid Data";
            }
            return View();
        }
        [ChildActionOnly]
        public ActionResult Navigate()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult DisplayAll()
        {
            return View(BO.ViewAll());
        }
        public ActionResult ViewEmp(int Id)
        {
            BD = BO.View(Id);
            return View(BD);
        }
        public ActionResult Delete(int Id)
        {
            BD = BO.View(Id);
            return View(BD);
        }
        [HttpPost]
        public ActionResult Delete(int Id,string B1)
        {
            if (BO.Delete(Id) == 0)
            {
                ViewBag.Message = "Error Accured";
            }
            else
            {
                ViewBag.Message = "Deleted Successfully";
            }
            return View();
        }
        public ActionResult Edit(int Id)
        {
            BD = BO.View(Id);
            return View(BD);
        }
        [HttpPost]
        public ActionResult Edit(BloodData BD)
        {
            if (BO.Update(BD) == 0)
            {
                ViewBag.Message = "Error Accured";
            }
            else
            {
                ViewBag.Message = "Updated Successfully";
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(BloodData BD)
        {
            if (ModelState.IsValid)
            {
                BO.Insert(BD);
                ViewBag.Message = "Successfully Registered";
            }
            else
            {
                ViewBag.Message = "Invalid Data";
            }
            return View();
        }
    }
}