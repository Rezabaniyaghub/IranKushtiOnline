using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IClassRoomService
    {
        (string Message, bool IsSuccess) Insert(ClassRoomModel model);
        (string Message, bool IsSuccess) Update(ClassRoomModel model);
        (string Message, bool IsSuccess) Delete(int Id);
        List<ClassRoomModel> GetAll();
        ClassRoomModel GetById(int id);
        ClassRoomModel GetNewModelCreate();
        ClassRoomModel GetNewOrExistingModel(int? id = null);
    }
}
