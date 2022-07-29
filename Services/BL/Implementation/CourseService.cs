using AutoMapper;
using Models.DTOs;
using Models.Entities;
using Repository;
using Services.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.BL.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepo;
        private readonly IMapper _mapper;

       
        public CourseService(IRepository<Course> courseRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }

        public Task<BaseResponseDTO> CreateCourse(CourseDTO model)
        {
            var baseResponse = new BaseResponseDTO();
            if(model != null)
            {
                var course =_mapper.Map<Course>(model);
                var status = _courseRepo.Create(course);

                baseResponse.IsSuccessful = status;
                baseResponse.Message = "BookCreated";
                return Task.FromResult(baseResponse);
            }
            baseResponse.Message = "Couldn't create book";
            baseResponse.IsSuccessful = false;
            return Task.FromResult(baseResponse);
        }

        public async Task<OperationResponseDTO<Course>> DeleteCourse(string coursecode)
        {
            if(!string.IsNullOrEmpty(coursecode))
            {
                var course = _courseRepo.FindByCourseCode(coursecode);
                if(course != null)
                {
                    var status = _courseRepo.Delete(course);
                    return new OperationResponseDTO<Course>
                    {
                        IsSuccessful = status,
                        data = course,
                        Message = status ? "Course Deleted" : "Couldn't Delete Course "
                    };
                }
                
            }
            return new OperationResponseDTO<Course> 
            {
                IsSuccessful = false ,
                data = null,
                Message ="Couldn't delete course"
            };
        }

        public async Task<OperationResponseDTO<Course>> GetCourse(string coursecode)
        {
            if (!string.IsNullOrEmpty(coursecode))
            {
                var course = _courseRepo.FindByCourseCode(coursecode);
                if (course != null)
                {
                    return new OperationResponseDTO<Course>
                    {
                        IsSuccessful = true,
                        data = course,
                        Message = "Course Found"

                    };
                }
            }
            return new OperationResponseDTO<Course>
            {
                IsSuccessful = false,
                data = null,
                Message = "Course Not Found"

            };
        }
    }
}
