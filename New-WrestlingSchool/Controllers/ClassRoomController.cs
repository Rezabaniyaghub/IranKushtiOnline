using AutoMapper;
using DataAccess.Entity;
using Domain.Abstract;
using Domain.Srvices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using System.Data;

namespace New_WrestlingSchool.Controllers
{
    public class ClassRoomController : Controller
    {
        #region [Ctor]
        private readonly IClassRoomService _classRoomService;
        private readonly IMapper _mapper;
        public ClassRoomController(IClassRoomService classRoomService, IMapper mapper)
        {
            _classRoomService = classRoomService;
            _mapper = mapper;
        }
        #endregion

        #region [Index]

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var list = _classRoomService.GetAll();
            return View(list);
        }
        #endregion

        #region [Create]
        [HttpGet]
        public IActionResult Create()
        {
            var model = _classRoomService.GetNewModelCreate();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles ="admin")]
        public IActionResult Create(ClassRoomModel model)
        {
            var result = _classRoomService.Insert(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = result.Message;
                model.SchoolSelectList = _classRoomService.GetNewModelCreate().SchoolSelectList;
                return View(model);
            }
        }
        #endregion

        #region [Edit]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _classRoomService.GetNewOrExistingModel(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClassRoomModel model)
        {
            var result = _classRoomService.Update(model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = result.Message;
                model.SchoolSelectList = _classRoomService.GetNewModelCreate().SchoolSelectList;
                return View(model);
            }
        } 
        #endregion

        #region [Delete]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _classRoomService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(ClassRoomModel model)
        {
            var result = _classRoomService.Delete(model.Id);
            if (result.IsSuccess)
                return RedirectToAction("Index");

            else
                ViewBag.Message = result.Message;
            model.SchoolSelectList = _classRoomService.GetNewModelCreate().SchoolSelectList;
            return View(model);

        }
        #endregion


    }
}
