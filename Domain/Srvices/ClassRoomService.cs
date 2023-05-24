using AutoMapper;
using DataAccess;
using DataAccess.Entity;
using Domain.Abstract;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Srvices
{
    public class ClassRoomService : IClassRoomService
    {
        #region [Ctor]
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        public ClassRoomService(IClassRoomRepository classRoomRepository, IMapper mapper, ISchoolRepository schoolRepository)
        {
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
            _schoolRepository = schoolRepository;
        }

        #endregion

        #region [Methods]
        public List<ClassRoomModel> GetAll() =>
       _mapper.Map<List<ClassRoomModel>>(_classRoomRepository.GetAll());

        public ClassRoomModel GetById(int id) =>
            _mapper.Map<ClassRoomModel>(_classRoomRepository.GetById(id));

        public (string Message, bool IsSuccess) Insert(ClassRoomModel model)
        {
            var entity = _mapper.Map<ClassRoom>(model);
            entity.CreatedAt = DateTime.Now;
            return _classRoomRepository.Insert(entity);
        }

        public (string Message, bool IsSuccess) Delete(int Id) =>
                _classRoomRepository.Delete(Id);

        public (string Message, bool IsSuccess) Update(ClassRoomModel model)
        {
            if (model.Id <= 0)
                return ("Id Is Not Valid", false);
            var result = _classRoomRepository.Update(_mapper.Map<ClassRoom>(model));
            return result;
        }

        public ClassRoomModel GetNewModelCreate()
        {
            var schools = _schoolRepository.GetAll();
            var model = new ClassRoomModel();
            model.SchoolSelectList = schools.Select(x =>
            new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            return model;
        }
        public ClassRoomModel GetNewOrExistingModel(int? id = null)
        {
            var model = id.HasValue ? GetById(id.Value) : new ClassRoomModel();
            var schools = _schoolRepository.GetAll();
            model.SchoolSelectList = schools.Select(x =>
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = x.Id == model.SchoolId // optional: select the school that matches the model's SchoolId
                }).ToList();
            return model;
        }

        #endregion

    }
}
