using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDDemo.Models;
using CRUDDemo.DataAccessLayer;

namespace CRUD.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult InsertStudent()
        {
            return View();
        }
            [HttpPost]
        public ActionResult InsertStudent(Student objStudent)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayer dal = new DataAccessLayer();
                bool result = dal.InsertData(objStudent);
                ModelState.Clear();
                return RedirectToAction("ShowAllStudentDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving Data");
                return View();
            }
            
            
        }

        [HttpGet]
        public ActionResult ShowAllStudentDetails(string SelectOption)
        {
            Student objStudent = new Student();
            DataAccessLayer dal = new DataAccessLayer();
            objStudent.listStudents = dal.SelectAllData();
            return View(objStudent);
        }

        [HttpPost]
        public ActionResult ShowAllStudentDetails(string SelectOption, string searchTerm)
        {
            Student objStudent = new Student();
            DataAccessLayer dal = new DataAccessLayer();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                switch (SelectOption)
                {
                    case "StudentName":
                        objStudent.listStudents = dal.SelectAllData().Where(x => x.StudentName.StartsWith(searchTerm)).ToList();
                        break;

                    case "StudentClass":
                        objStudent.listStudents = dal.SelectAllData().Where(x => Convert.ToString(x.StudentClass).StartsWith(searchTerm)).ToList();
                        break;

                    case "StudentAge":
                        objStudent.listStudents = dal.SelectAllData().Where(x => Convert.ToString(x.StudentAge).StartsWith(searchTerm)).ToList();
                        break;

                }
                return View(objStudent);
                
            }
            else
            {
                objStudent.listStudents = dal.SelectAllData();
                return View(objStudent);
            }
        }

        [HttpGet]
        public ActionResult UpdateData(int StudentId=0)
        
        {
            Student objStudent = new Student();
            DataAccessLayer dal = new DataAccessLayer();
            return View(dal.SelectById(StudentId));
            //RedirectToAction("ShowAllStudentDetails");
        }

        [HttpPost]
        public ActionResult UpdateData(Student objStudent)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayer dal = new DataAccessLayer();
                bool result = dal.UpdateData(objStudent);
                ModelState.Clear();
                return RedirectToAction("ShowAllStudentDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in Updating Data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult SelectById(int StudentId)
        {

            Student objStudent = new Student();
            DataAccessLayer dal = new DataAccessLayer();
            return View(dal.SelectById(StudentId));
        }

        [HttpGet]
        public ActionResult DeleteData(int StudentId = 4)
        {
            Student objStudent = new Student();
            DataAccessLayer dal = new DataAccessLayer();
            objStudent = dal.SelectById(StudentId);
            return View(dal.SelectById(StudentId));
        }



        [HttpPost]
        public ActionResult DeleteData(Student objStudent)
        {
            
                DataAccessLayer dal = new DataAccessLayer();
                objStudent = dal.SelectById(objStudent.StudentId);
                Student result = dal.DeleteData(objStudent);
                //ModelState.Clear();
            
            View();
            return RedirectToAction("ShowAllStudentDetails");
        }
    }
}