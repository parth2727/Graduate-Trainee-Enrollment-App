using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;
using GraduateTraineeEnrollmentApi.Services.Contract;

namespace GraduateTraineeEnrollmentApi.Services.Implementation
{
    public class StreamService : IStreamService
    {
        public readonly IStreamRepository _streamRepository;

        public StreamService(IStreamRepository streamRepository)
        {
            _streamRepository = streamRepository;
        }


        public ServiceResponse<IEnumerable<StreamDto>> GetAllStreams()
        {
            var response = new ServiceResponse<IEnumerable<StreamDto>>();

            var streams = _streamRepository.GetAllStreams();

            if (streams == null)
            {
                response.Success = false;
                response.Data = new List<StreamDto>();
                response.Message = "No record found.";
                return response;
            }

            List<StreamDto> streamDtos = new List<StreamDto>();

            foreach (var stream in streams.ToList())
            {
                streamDtos.Add(new StreamDto()
                {
                    StreamId = stream.StreamId,
                    StreamName = stream.StreamName,
                    StreamDescription = stream.StreamDescription,
                    Degree = new Models.Degrees()
                    {
                        DegreeId = stream.Degree.DegreeId,
                        DegreeName = stream.Degree.DegreeName,
                        DegreeDescription = stream.Degree.DegreeDescription,
                    }
                });
            }

            response.Data = streamDtos;
            return response;
        }


        public ServiceResponse<IEnumerable<StreamDto>> GetStreamByDegreeId(int id)
        {
            var response = new ServiceResponse<IEnumerable<StreamDto>>();

            var streams = _streamRepository.GetStreamByDegreeId(id);

            if (streams != null && streams.Any())
            {
                var streamDto = new List<StreamDto>();  
                foreach(var stream in streams)
                {
                    streamDto.Add(new StreamDto()
                    {
                        StreamId = stream.StreamId,
                        StreamName = stream.StreamName,
                        StreamDescription = stream.StreamDescription,
                        DegreeId = stream.DegreeId,
                    });
                }
                response.Data = streamDto;

            }
            else
            {
                response.Success = false;
                response.Message = "No record found";
            }

            return response;
        }

        public IEnumerable<Streams> GetPaginatedStreams(int page, int pageSize)
        {
            return _streamRepository.GetAllStreamByPagination(page, pageSize);
        }

        public int TotalNoOfStreams()
        {
            return _streamRepository.TotalNoOfStreams();
        }

        public ServiceResponse<string> AddStream(Streams stream)
        {
            var response = new ServiceResponse<string>();

            if(stream == null)
            {
                response.Success=false;
                response.Message = "Something went wrong, Please try after sometimes";
                return response;
            }
            if (AlreadyExists(stream.DegreeId, stream.StreamName))
            {
                response.Success = false;
                response.Message = "Stream Already exists";
                return response;
            }

            var result = _streamRepository.InsertStream(stream);
            response.Success = result;
            response.Message = result ? "Stream saved successfully." : "Something went wrong , Please try after sometime.";

            return response;
        }

        public ServiceResponse<string> UpdateStream(Streams streams)
        {
            var response = new ServiceResponse<string>();
            if(streams == null)
            {
                response.Success = false;
                response.Message = "Something went wrong.Please try after sometime.";
                return response;
            }
            if (AlreadyExists(streams.StreamId, streams.DegreeId, streams.StreamName))
            {
                response.Success = false;
                response.Message = "Stream already exists";
                return response;
            }

            var updateStream = _streamRepository.GetStreamById(streams.StreamId);
            if(updateStream != null)
            {
                updateStream.StreamName = streams.StreamName;
                updateStream.StreamDescription = streams.StreamDescription;
                updateStream.DegreeId = streams.DegreeId;
                var result = _streamRepository.UpdateStream(updateStream);

                response.Success = result;
                response.Message = result ? "Stream Updated Successfully" : "Something went wrong ,Please try after sometimes";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong , Please try after sometime";
                return response;
            }

            return response;
        }

        public ServiceResponse<string> DeleteStream(int id)
        {
            var response = new ServiceResponse<string>();

            if(id < 0)
            {
                response.Success=false;
                response.Message = "No record to delete.";
            }

            var result = _streamRepository.DeleteStream(id);
            response.Success = result;
            response.Message = result ? "Stream deleted Successfully" : "Something went wrong, please try after sometime.";
            return response;
        }

        public ServiceResponse<StreamDto> GetStreamById(int id)
        {
            var response = new ServiceResponse<StreamDto>();

            var stream = _streamRepository.GetStreamById(id);

            var streamDto = new StreamDto()
            {
                StreamId = stream.StreamId,
                StreamName = stream.StreamName,
                StreamDescription = stream.StreamDescription,
                DegreeId = stream.DegreeId,
                Degree = new Degrees()
                {
                    DegreeId = stream.Degree.DegreeId,
                    DegreeName = stream.Degree.DegreeName,
                    DegreeDescription = stream.Degree.DegreeDescription,
                },
            };

            response.Data = streamDto;
            return response;
        }

        private bool AlreadyExists(int degreeId,string streamName)
        {
            var result = false;
            var stream = _streamRepository.GetStreamsByDegreeIdStreamName(degreeId, streamName);
            if(stream != null)
            {
                result = true;
            }
            return result;
        }

        private bool AlreadyExists(int streamId ,int degreeId, string streamName)
        {
            var result = false;
            var stream = _streamRepository.GetStreamsByDegreeIdStreamName(streamId,degreeId, streamName);
            if (stream != null)
            {
                result = true;
            }
            return result;
        }

    }
}
