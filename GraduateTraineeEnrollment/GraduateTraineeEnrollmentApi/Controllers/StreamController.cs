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
    [Authorize]

    public class StreamController : ControllerBase
    {
        public readonly IStreamService _streamService;

        public StreamController(IStreamService streamService)
        {
            _streamService = streamService;
        }

        [HttpGet("GetAllStream")]
        public IActionResult GetAllStreams()
        {
            var response = _streamService.GetAllStreams();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetStreamByDegreeId/{degreeId}")]
        public IActionResult GetStreamByDegreeId(int degreeId)
        {
            var response = _streamService.GetStreamByDegreeId(degreeId);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetAllStreamByPagination")]
        public IActionResult GetAllStreamByPagination(int page, int pageSize)
        {
            var totalRecords = _streamService.TotalNoOfStreams();
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            var response = _streamService.GetPaginatedStreams(page, pageSize);


            return Ok(new { Data = response });
        }

        [HttpGet("GetStreamById/{id}")]
        public IActionResult GetStreamById(int id)
        {
            var response = _streamService.GetStreamById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("AddStream")]
        public IActionResult AddStream(AddStreamDto addStreamDto)
        {
            var stream = new Streams
            {
                
                StreamName = addStreamDto.StreamName,
                StreamDescription = addStreamDto.StreamDescription,
                DegreeId = addStreamDto.DegreeId,

            };

            var result = _streamService.AddStream(stream);
            return !result.Success ? BadRequest(result) : Ok(result);
        }

        

        [HttpPut("ModifyStream")]
        public IActionResult UpdateStream(UpdateStreamDto updateStreamDto)
        {
            var stream = new Streams()
            {
                StreamId = updateStreamDto.StreamId,
                StreamName = updateStreamDto.StreamName,
                StreamDescription = updateStreamDto.StreamDescription,
                DegreeId = updateStreamDto.DegreeId,
            };

            var result = _streamService.UpdateStream(stream);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete("RemoveStream/{id}")]
        public IActionResult DeleteStream(int id)
        {
            if(id>0)
            {
                var response = _streamService.DeleteStream(id);
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
