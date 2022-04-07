using NEW_MVC.Models;
using NEW_MVC;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TeacherController(ApplicationDbContext db)
        {
            _db = db;
        }
       // public IActionResult Index()
        //{
//            IEnumerable<Teacher> listofsubjects = _db.Teacher;
        //    return View(listofsubjects);
//        }
//   [HttpPost]
        public async Task<IActionResult> Index (string searchString)
        {
            var teachers = from t in _db.Teacher select t;
            if(!String.IsNullOrEmpty(searchString))
            {
                teachers = teachers.Where(s => s.Teacher_Name!.Contains(searchString));
            
            }
            return View(await teachers.ToListAsync());

        }
        [HttpGet]
        public IActionResult Edit(int TeacherID)
        {
            var subobj = _db.Teacher.Find(TeacherID);
            return View(subobj);

        }

        [HttpPost]
        public IActionResult Edit(Teacher updatedvaluesobj)
        {
            _db.Teacher.Update(updatedvaluesobj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        
        public IActionResult Delete(int TeacherID) {
            var subobj = _db.Teacher.Find(TeacherID);
            _db.Teacher.Remove(subobj);
            _db.SaveChanges();
            var updated_db = _db.Teacher;
            return RedirectToAction("Index",updated_db);
        }

         [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Teacher_Name, Class, SubjectID")]Teacher createdvaluesobj)
        {
            // _db.Teacher.create(createdvaluesobj);
            _db.Teacher.Add(createdvaluesobj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}