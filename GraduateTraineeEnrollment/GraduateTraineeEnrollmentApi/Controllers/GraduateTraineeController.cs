using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;
using GraduateTraineeEnrollmentApi.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GraduateTraineeEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class GraduateTraineeController : ControllerBase
    {
        public readonly IGraduateTraineeService _graduateTraineeService;

        public GraduateTraineeController(IGraduateTraineeService graduateTraineeService)
        {
            _graduateTraineeService = graduateTraineeService;   
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _graduateTraineeService.GetGraduateTrainees();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetGraduateTraineeById(int id)
        {
            var response = _graduateTraineeService.GetGraduateTraineeById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpPost("AddTrainee")]
        public IActionResult AddTrainee(AddGraduateTraineeDto traineeDto)
        {
           if(ModelState.IsValid)
            {
                var trainee = new GraduateTrainees
                {
                    DegreeId = traineeDto.DegreeId,
                    StreamId = traineeDto.StreamId,
                    TraineeName = traineeDto.TraineeName,
                    TraineeEmail = traineeDto.TraineeEmail,
                    UniversityName = traineeDto.UniversityName,
                    IsLastSemesterPending = traineeDto.IsLastSemesterPending,
                    Gender = traineeDto.Gender,
                    DateOfApplication = traineeDto.DateOfApplication,
                    Image = traineeDto.Image,
                    Ai = traineeDto.Ai,
                    Phyton = traineeDto.Phyton,
                    BusinessAnalysis = traineeDto.BusinessAnalysis,
                    MachineLearning = traineeDto.MachineLearning,
                    Practical = traineeDto.Practical,
                    TotalMarks = traineeDto.TotalMarks,
                    Percentages = traineeDto.Percentages,
                    IsAdmisisonConfirmed = traineeDto.IsAdmisisonConfirmed,
                };
                if(traineeDto.IsLastSemesterPending)
                {
                    trainee.Ai= null;
                    trainee.Phyton= null;
                    trainee.BusinessAnalysis= null;
                    trainee.MachineLearning= null;
                    trainee.Practical= null;
                    trainee.TotalMarks=null;
                    trainee.Percentages=null;
                    trainee.IsAdmisisonConfirmed = false;
                }
                else
                {
                    trainee.TotalMarks = trainee.Ai + trainee.Phyton + trainee.BusinessAnalysis + trainee.MachineLearning + trainee.Practical;

                    trainee.Percentages = ((trainee.TotalMarks) / 500) * 100;

                    if(trainee.Percentages >= 60)
                    {
                        trainee.IsAdmisisonConfirmed= true;
                    }
                    else
                    {
                        trainee.IsAdmisisonConfirmed = false;
                    }
                }


                var result = _graduateTraineeService.AddGraduateTrainee(trainee);
                return !result.Success ? BadRequest(result) : Ok(result);
            }
            else
            {
                return BadRequest();
            }
                

           
        }


        [HttpPut("UpdateTrainee")]
        public IActionResult UpdateGraduatrainee(UpdateGraduateTraineeDto trineeDto)
        {
            var trainee = new GraduateTrainees()
            {
                GraduateTraineeId = trineeDto.GraduateTraineeId,
                DegreeId = trineeDto.DegreeId,
                StreamId = trineeDto.StreamId,
                TraineeName = trineeDto.TraineeName,
                TraineeEmail = trineeDto.TraineeEmail,
                UniversityName = trineeDto.UniversityName,
                IsLastSemesterPending = trineeDto.IsLastSemesterPending,
                Gender = trineeDto.Gender,
                DateOfApplication = trineeDto.DateOfApplication,
                Image = trineeDto.Image,
                Ai = trineeDto.Ai,
                Phyton = trineeDto.Phyton,
                BusinessAnalysis = trineeDto.BusinessAnalysis,
                MachineLearning = trineeDto.MachineLearning,
                Practical = trineeDto.Practical,
                TotalMarks = trineeDto.TotalMarks,
                Percentages = trineeDto.Percentages,
                IsAdmisisonConfirmed = trineeDto.IsAdmisisonConfirmed,
            };
            if (trineeDto.IsLastSemesterPending)
            {
                trainee.Ai = null;
                trainee.Phyton = null;
                trainee.BusinessAnalysis = null;
                trainee.MachineLearning = null;
                trainee.Practical = null;
                trainee.TotalMarks = null;
                trainee.Percentages = null;
                trainee.IsAdmisisonConfirmed = false;
            }
            else
            {
                trainee.TotalMarks = trainee.Ai + trainee.Phyton + trainee.BusinessAnalysis + trainee.MachineLearning + trainee.Practical;

                trainee.Percentages = ((trainee.TotalMarks) / 500) * 100;

                if (trainee.Percentages >= 60)
                {
                    trainee.IsAdmisisonConfirmed = true;
                }
                else
                {
                    trainee.IsAdmisisonConfirmed = false;
                }
            }
            var response = _graduateTraineeService.ModifyTrainee(trainee);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpDelete("RemoveTrainee/{id}")]
        public IActionResult RemoveTrainee(int id)
        {
            if (id > 0)
            {
                var response = _graduateTraineeService.DeleteTrainee(id);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            else
            {
                return BadRequest("Please enter proper data");
            }
        }


        [HttpGet("GetTraineeEnrollmentReport")]
        public IActionResult TraineeReport()
        {
            var response = _graduateTraineeService.TraineeReport();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
