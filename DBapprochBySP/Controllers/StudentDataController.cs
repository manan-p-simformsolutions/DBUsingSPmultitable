using DBapprochBySP.Models;
using LanguageExt.ClassInstances;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace DBapprochBySP.Controllers
{
    public class StudentDataController : Controller
    {
        private readonly StudentEntities1 obj = new StudentEntities1();
        // GET: StudentData
        public ActionResult StudentList(int Cpage = 1)
        {

            ViewBag.PageCount = (int)Math.Ceiling((double)((decimal)obj.StudentDatas.Count() / 2));
            ViewBag.CPage = Cpage;
            var s = obj.Database.SqlQuery<StudentList>(
                "exec Pagination @PageNumber,@PageSize",
                new SqlParameter("@PageNumber", Cpage), new SqlParameter("@PageSize", 2)).ToList();


            /*IList<StudentList_Result> studentList = obj.StudentList().Select(x => new StudentList_Result()
            {
                Id = x.Id,
                Name = x.Name,
                RollNo = x.RollNo,
                Class = x.Class,
                City = x.City,
                Address = x.Address,
                Amount = x.Amount,
                Year = x.Year
            }).ToList();*/
             ViewBag.studentList = obj.StudentList().ToList();
            return View(s);
        }
        public ActionResult Edit(int id)
        {
            var st = obj.StudentList().FirstOrDefault(x=>x.Id==id);
            return View(st);

        }
        [HttpPost]
        public ActionResult Edit(StudentList_Result st)
        {
            obj.UpdateStudent(st.Id, st.Id,st.Name, st.RollNo, Int32.Parse(st.Class), st.City, st.Address, st.Amount, st.Year);
            return View();
        }


    }
}