using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;
using GraduateTraineeEnrollmentApi.Services.Contract;

namespace GraduateTraineeEnrollmentApi.Services.Implementation
{
    public class DegreeService : IDegreeService
    {
        private readonly IDegreeRepository _degreeRepository;

        public DegreeService(IDegreeRepository degreeRepository)
        {
            _degreeRepository = degreeRepository;
        }

        public ServiceResponse<IEnumerable<DegreeDto>> GetAllDegrees()
        {
            var response = new ServiceResponse<IEnumerable<DegreeDto>>();
            var degrees = _degreeRepository.GetAllDegrees();
            if (degrees == null )
            {
                response.Success = false;
                response.Data = new List<DegreeDto>();
                response.Message = "No record found.";
                return response;
            }

            List<DegreeDto> degreeDtos = new List<DegreeDto>();

            foreach ( var degree in degrees.ToList() )
            {
                degreeDtos.Add(new DegreeDto()
                {
                    DegreeId = degree.DegreeId,
                    DegreeName = degree.DegreeName,
                    DegreeDescription = degree.DegreeDescription,
                });
            }

            response.Data = degreeDtos;
            return response;
        }

        public ServiceResponse<DegreeDto> GetDegreeById(int degreeId)
        {
            var response = new ServiceResponse<DegreeDto>();
            var existingDegree = _degreeRepository.GetDegreeById(degreeId);
            if(existingDegree != null)
            {
                var degree = new DegreeDto()
                {
                    DegreeId = degreeId,
                    DegreeName = existingDegree.DegreeName,
                    DegreeDescription = existingDegree.DegreeDescription,
                };
                response.Data = degree;
            }
            else
            {
                response.Success = false;
                response.Message = "No record found ! ";
            }
            return response;
        }

        public ServiceResponse<string> AddDegree(Degrees degrees)
        {
            var response = new ServiceResponse<string>();
            if (_degreeRepository.DegreeAlreadyExists(degrees.DegreeName))
            {
                response.Success = false;
                response.Message = "Degree already exists";
                return response;
            }

            var result = _degreeRepository.InsertDegree(degrees);
            if (result)
            {
                response.Message = "Degree Saved Successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong , please try after sometimes";
            }

            return response;
        }

        public ServiceResponse<string> ModifyDegree(Degrees degrees)
        {
            var response = new ServiceResponse<string>();
            var message = string.Empty;
            if(_degreeRepository.DegreeAlreadyExists(degrees.DegreeId, degrees.DegreeName))
            {
                response.Success= false;
                response.Message = "Degree already exist";
                return response;
            }

            var existingDegree = _degreeRepository.GetDegreeById(degrees.DegreeId);
            var result = false;
            if (existingDegree != null)
            {
                existingDegree.DegreeName = degrees.DegreeName;
                existingDegree.DegreeDescription = degrees.DegreeDescription;
                result = _degreeRepository.UpdateDegree(existingDegree);

            }

            if (result)
            {
                response.Message = "Degree updated Successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong , please try after sometimes";
            }

            return response;
        }

        public ServiceResponse<string> RemoveDegree(int id)
        {
            var response = new ServiceResponse<string>();
            var result = _degreeRepository.DeleteDegree(id);
            if (result)
            {
                response.Message = "Degree deleted successfully";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong , try after sometimes";
            }
            return response;
        }
    }
}
