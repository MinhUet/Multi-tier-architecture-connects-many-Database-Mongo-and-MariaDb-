using BVMinh.DemoArchitecture.DL.EntityMongoRepositories;
using BVMinh.DemoArchitecture.DL.Repositories;
using BVMinh.DemoArchitecture.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BVMinh.DemoArchitecture.BL.APIs
{
    public class StudentsController :  BaseController
    {
        private readonly StudentMongoRepository _studentRepo;

        public StudentsController(IRepository<Student> studentRepo)
        {
            _studentRepo = (StudentMongoRepository)studentRepo;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            IEnumerable<Student> students = _studentRepo.GetAll();
            return students;
        }
    }
}
