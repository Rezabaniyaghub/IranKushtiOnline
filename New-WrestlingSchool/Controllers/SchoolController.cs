using Domain.Abstract;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace New_WrestlingSchool.Controllers
{
    public class SchoolController : Controller
    {
        #region [Ctor]
        private readonly ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        #endregion

        #region [Index]
        [HttpGet]
        public IActionResult Index()
        {
            var SchoolList = _schoolService.GetAll();
            return View(SchoolList);
        }
        #endregion

      
        #region [Create]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new SchoolModel());
        }

        [HttpPost]
        public IActionResult Create(SchoolModel model)
        {
            var result = _schoolService.Insert(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(model);
            }
        }
        #endregion

        #region [Edit]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _schoolService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SchoolModel model)
        {
            var result = _schoolService.Update(model);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            else
                ViewBag.Message = result.Message;
            return View(model);
        }
        #endregion

        #region [Delete]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _schoolService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(SchoolModel model)
        {
            var result = _schoolService.Delete(model.Id);
            if (result.IsSuccess)
                return RedirectToAction("Index");
            else
                ViewBag.Message = result.Message;
            return View(model);
        }
        #endregion
    }
}
