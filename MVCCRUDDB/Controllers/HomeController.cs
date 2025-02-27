﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUDDB.Controllers
{
    public class HomeController : Controller
    {
        MVCCRUDDBContext _context=new MVCCRUDDBContext();
        public ActionResult Index()
        {
            var lisofData = _context.Students.ToList();
            return View(lisofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data InsertSuccessfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            var data=_context.Students.Where(x => x.StudentId == model.StudentId).FirstOrDefault();
            if(data!=null)
                {
                data.StudentCity = model.StudentCity;
                data.StudentFee = model.StudentFee;
                data.StudentName= model.StudentName;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var data=_context.Students.Where(x=>x.StudentId == id).FirstOrDefault();    
            return View();
        }
        public ActionResult delete(int id)
        {
            var data=_context.Students.Where(x=>x.StudentId==id).FirstOrDefault();
            _context.Students.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Data deleted";
            return RedirectToAction("Index");
        }
    }
}