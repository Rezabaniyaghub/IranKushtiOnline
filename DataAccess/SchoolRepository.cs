﻿using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISchoolRepository
    {
        (string Message, bool IsSuccess) Insert(School model);
        (string Message, bool IsSuccess) Update(School model);
        (string Message, bool IsSuccess) Delete(int Id);
        List<School> GetAll();
        School GetById(int Id);
    }
    public class SchoolRepository : ISchoolRepository
    {
        private readonly AppDbContext _appDbContext;
        public SchoolRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<School> GetAll()
        {
         return _appDbContext.Schools.ToList();
           
        }
        public School GetById(int id)
        {
            return _appDbContext.Schools.FirstOrDefault(x => x.Id == id);
        }

        public (string Message, bool IsSuccess) Insert(School model)
        {
            try
            {
                _appDbContext.Schools.Add(model);
                var result = _appDbContext.SaveChanges();
                if (result > 0)
                    return ("Success Don!", true);
            }
            catch (Exception ex)
            {

            }
            return ("Faid!", false);
        }

        public (string Message, bool IsSuccess) Update(School model)
        {
            try
            {
                var old = _appDbContext.Schools.FirstOrDefault(x => x.Id == model.Id);
                if (old!= null)
                {
                    old.Name = model.Name;
                    old.PhoneNumber = model.PhoneNumber;
                    old.Address = model.Address;
                    old.Capacity = model.Capacity;
                    var result = _appDbContext.SaveChanges();
                    if (result > 0)
                        return ("Success Don!", true);
                }
               
            }
            catch (Exception ex)
            {

            }
            return ("Faid!", false);
        }
        public (string Message, bool IsSuccess) Delete(int Id)
        {
            try
            {
                var old = _appDbContext.Schools.FirstOrDefault(x => x.Id == Id);
                if (old != null)
                {
                    _appDbContext.Schools.Remove(old);
                    var result = _appDbContext.SaveChanges();
                    if (result > 0)
                        return ("Success Don!", true);
                }
                else
                {
                    return ("Entity Not Found!", false);
                }

            }
            catch (Exception ex)
            {

            }
            return ("Faid!", false);
        }

    }
}
