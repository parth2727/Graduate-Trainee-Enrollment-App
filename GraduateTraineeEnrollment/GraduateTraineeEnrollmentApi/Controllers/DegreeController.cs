using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;
using GraduateTraineeEnrollmentApi.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateTraineeEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AllowAnonymous]
    [Authorize]
    public class DegreeController : ControllerBase
    {
        private readonly IDegreeService _degreeService;

        public DegreeController(IDegreeService degreeService)
        {
            _degreeService = degreeService;
        }

        [HttpGet("GetAllDegrees")]
        public IActionResult GetAllDegree()
        {
            var response = _degreeService.GetAllDegrees();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        //Degree CRUD Operation 

        [HttpGet("GetDegreeById/{id}")]
        public IActionResult GetDegreeById(int id)
        {
            var response = _degreeService.GetDegreeById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("CreateDegree")]
        public IActionResult AddDegree(AddDegreeDto degreeDto)
        {
            var degree = new Degrees()
            {
                DegreeName = degreeDto.DegreeName,
                DegreeDescription = degreeDto.DegreeDescription,
            };

            var result = _degreeService.AddDegree(degree);
            return !result.Success ? BadRequest(result) : Ok(result);
        }

        [HttpPut("ModifyDegree")]
        public IActionResult UpdateDegree(UpdateDegreeDto degreeDto)
        {
            var degree = new Degrees()
            {
                DegreeId = degreeDto.DegreeId,
                DegreeName = degreeDto.DegreeName,
                DegreeDescription = degreeDto.DegreeDescription,
            };

            var result = _degreeService.ModifyDegree(degree);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("RemoveDegree/{id}")]
        public IActionResult DeleteDegree(int id)
        {
            if(id>0)
            {
                var response = _degreeService.RemoveDegree(id);
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
    }
}
