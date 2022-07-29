using Models.DTOs;
using Models.Entities;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.BL.Interfaces
{
    public interface ICourseService : IAutoDependencyService
    {
        Task<BaseResponseDTO> CreateCourse(CourseDTO model);
        Task<OperationResponseDTO<Course>> DeleteCourse(string coursecode);
        Task<OperationResponseDTO<Course>> GetCourse(string coursecode);
    }
}
