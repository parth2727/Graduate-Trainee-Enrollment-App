using GraduateTraineeEnrollmentApi.Data.Contract;
using GraduateTraineeEnrollmentApi.Dtos;
using GraduateTraineeEnrollmentApi.Models;
using GraduateTraineeEnrollmentApi.Services.Contract;
using System.IO;

namespace GraduateTraineeEnrollmentApi.Services.Implementation
{
    public class GraduateTraineeService : IGraduateTraineeService
    {
        public readonly IGraduateTraineeRepository _graduateTraineeRepository;

        public GraduateTraineeService(IGraduateTraineeRepository graduateTraineeRepository)
        {
            _graduateTraineeRepository = graduateTraineeRepository;
        }

        public ServiceResponse<IEnumerable<GraduateTraineeDto>> GetGraduateTrainees()
        {
            var response = new ServiceResponse<IEnumerable<GraduateTraineeDto>>();

            var graduates = _graduateTraineeRepository.GetAllTrainee();

            if (graduates == null)
            {
                response.Success = false;
                response.Data = new List<GraduateTraineeDto>();
                response.Message = "No record found.";
                return response;
            }


            
                List<GraduateTraineeDto> graduateTraineeDtos = new List<GraduateTraineeDto>();

                foreach (var gt in graduates)
                {
                    graduateTraineeDtos.Add(new GraduateTraineeDto()
                        {
                            GraduateTraineeId = gt.GraduateTraineeId,
                            DegreeId = gt.DegreeId,
                            StreamId = gt.StreamId,
                            TraineeName = gt.TraineeName,
                            TraineeEmail = gt.TraineeEmail,
                            UniversityName = gt.UniversityName,
                            IsLastSemesterPending = gt.IsLastSemesterPending,
                            Gender = gt.Gender,
                            DateOfApplication = gt.DateOfApplication,
                            Image = gt.Image,
                            Ai = gt.Ai,
                            Phyton = gt.Phyton,
                            BusinessAnalysis = gt.BusinessAnalysis,
                            MachineLearning = gt.MachineLearning,
                            Practical = gt.Practical,
                            TotalMarks = gt.TotalMarks,
                            Percentages = gt.Percentages,
                            IsAdmisisonConfirmed = gt.IsAdmisisonConfirmed,
                            //Degree = new Models.Degrees()
                            //{
                            //    DegreeId = gt.Degree.DegreeId,
                            //    DegreeName = gt.Degree.DegreeName,
                            //    DegreeDescription = gt.Degree.DegreeDescription,
                            //},
                            //Stream = new Models.Streams()
                            //{
                            //    StreamId = gt.Stream.StreamId,
                            //    StreamName = gt.Stream.StreamName,
                            //    StreamDescription = gt.Stream.StreamDescription,
                            //},

                    });
                }

                response.Data = graduateTraineeDtos;

            return response;
        }


        public ServiceResponse<GraduateTraineeDto> GetGraduateTraineeById(int id)
        {
            var response = new ServiceResponse<GraduateTraineeDto>();
            var existingTrainee = _graduateTraineeRepository.GetGraduateTraineeById(id);

            if (existingTrainee != null)
            {
                var Trainee = new GraduateTraineeDto()
                {
                    GraduateTraineeId = existingTrainee.GraduateTraineeId,
                    DegreeId = existingTrainee.DegreeId,
                    StreamId = existingTrainee.StreamId,
                    TraineeName = existingTrainee.TraineeName,
                    TraineeEmail = existingTrainee.TraineeEmail,
                    UniversityName = existingTrainee.UniversityName,
                    IsLastSemesterPending = existingTrainee.IsLastSemesterPending,
                    Gender = existingTrainee.Gender,
                    DateOfApplication = existingTrainee.DateOfApplication,
                    Image = existingTrainee.Image,
                    Ai = existingTrainee.Ai,
                    Phyton = existingTrainee.Phyton,
                    BusinessAnalysis = existingTrainee.BusinessAnalysis,
                    MachineLearning = existingTrainee.MachineLearning,
                    Practical = existingTrainee.Practical,
                    TotalMarks = existingTrainee.TotalMarks,
                    Percentages = existingTrainee.Percentages,
                    IsAdmisisonConfirmed = existingTrainee.IsAdmisisonConfirmed,
                    Degree = new Degrees()
                    {
                        DegreeId = existingTrainee.Degree.DegreeId,
                        DegreeName = existingTrainee.Degree.DegreeName,
                        DegreeDescription = existingTrainee.Degree.DegreeDescription,
                    },
                    Stream = new Streams()
                    {
                        StreamId = existingTrainee.Stream.StreamId,
                        StreamName = existingTrainee.Stream.StreamName,
                        StreamDescription = existingTrainee.Stream.StreamDescription,
                    },
                    
                };
                response.Data = Trainee;
            }

            else
            {
                response.Success = false;
                response.Message = "No records found";
            }

            return response;
        }


        public ServiceResponse<string> AddGraduateTrainee(GraduateTrainees graduateTrainees)
        {
            var response = new ServiceResponse<string>();

            if(graduateTrainees == null)
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime";
                return response;
            }
            if (AlreadyExists(graduateTrainees.TraineeEmail))
            {
                response.Success = false;
                response.Message = "Trainee already exists";
                return response;
            }

            var result = _graduateTraineeRepository.InsertGraduateTrainee(graduateTrainees);
            response.Success = result;
            response.Message = result ? "Trainee saved successfully." : "Something went wrong , Please try after sometimes";

            return response;
        }

        public ServiceResponse<string> ModifyTrainee(GraduateTrainees graduateTrainees)
        {
            var response = new ServiceResponse<string>();

            if (graduateTrainees == null)
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
                return response;
            }
            if (AlreadyExists(graduateTrainees.GraduateTraineeId,graduateTrainees.TraineeEmail))
            {
                response.Success = false;
                response.Message = "Trainee already exists";
                return response;
            }

            var updateTrainee = _graduateTraineeRepository.GetGraduateTraineeById(graduateTrainees.GraduateTraineeId);
            if(updateTrainee != null)
            {
                updateTrainee.DegreeId = graduateTrainees.DegreeId;
                updateTrainee.StreamId = graduateTrainees.StreamId;
                updateTrainee.TraineeName = graduateTrainees.TraineeName;
                updateTrainee.TraineeEmail = graduateTrainees.TraineeEmail;
                updateTrainee.UniversityName = graduateTrainees.UniversityName;
                updateTrainee.IsLastSemesterPending = graduateTrainees.IsLastSemesterPending;
                updateTrainee.Gender = graduateTrainees.Gender;
                updateTrainee.DateOfApplication = graduateTrainees.DateOfApplication;
                updateTrainee.Image = graduateTrainees.Image;
                updateTrainee.Ai = graduateTrainees.Ai;
                updateTrainee.Phyton = graduateTrainees.Phyton;
                updateTrainee.BusinessAnalysis = graduateTrainees.BusinessAnalysis;
                updateTrainee.MachineLearning = graduateTrainees.MachineLearning;
                updateTrainee.Practical = graduateTrainees.Practical;
                updateTrainee.TotalMarks = graduateTrainees.TotalMarks;
                updateTrainee.Percentages = graduateTrainees.Percentages;
                updateTrainee.IsAdmisisonConfirmed = graduateTrainees.IsAdmisisonConfirmed;

                var result = _graduateTraineeRepository.UpdateGraduateTrainee(updateTrainee);
                response.Success = result;
                response.Message = result ? "Trainee updated successfully." : "Something went wrong. Please try after sometime.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try after sometime.";
                return response;
            }

            return response;

        }

        public ServiceResponse<string> DeleteTrainee(int id)
        {
            var response = new ServiceResponse<string>();
            if (id < 0)
            {
                response.Success= false;
                response.Message = "No record to delete";
            }

            var result = _graduateTraineeRepository.DeleteGraduateTrainee(id);
            response.Success = result;
            response.Message = result ? "Trainee deleted successfully." : "Something went wrong, please try after sometime.";

            return response;
        }



            public ServiceResponse<IEnumerable<TraineeEnrollmentReportResult>> TraineeReport()
            {
                var response = new ServiceResponse<IEnumerable<TraineeEnrollmentReportResult>>();
                var report = _graduateTraineeRepository.TraineeEnrollmentReport();
                if (report != null && report.Any())
                {
                    List<TraineeEnrollmentReportResult> reports = new List<TraineeEnrollmentReportResult>();
                    foreach (var rep in report)
                    {
                        reports.Add(new TraineeEnrollmentReportResult()
                        {
                            DegreeName = rep.DegreeName,
                            StreamName = rep.StreamName,
                            TotalTraineeCount = rep.TotalTraineeCount,
                        });
                    }
                    response.Data = reports;
                }
                else
                {
                    response.Success = false;
                    response.Message = "No record found";
                }
                return response;
            }

            private bool AlreadyExists(string traineeEmail)
            {
                var result = false;
                var trainee = _graduateTraineeRepository.GetGradsByDegreeIdStreamIdGradsName(traineeEmail);
                if (trainee != null)
                {
                    result = true;
                }
                return result;
            }

            private bool AlreadyExists(int gradsId, string traineeEmail)
            {
                var result = false;
                var trainee = _graduateTraineeRepository.GetGradsByDegreeIdStreamIdGradsName(gradsId, traineeEmail);
                if (trainee != null)
                {
                    result = true;
                }
                return result;
            }

        //private bool CalculateAndSetAdmissionStatus(GraduateTrainees trainees)
        //{
        //    var result = false;

        //    trainees.TotalMarks = trainees.Ai + trainees.Phyton + trainees.BusinessAnalysis + trainees.MachineLearning + trainees.Practical;

        //    trainees.Percentages = (trainees.TotalMarks / 500) * 100;

        //    if (trainees.IsLastSemesterPending)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        if (trainees.Percentages >= 60)
        //        {
        //            trainees.IsAdmisisonConfirmed = true;
        //            Console.WriteLine("Admission Confirmed");
        //            return true;

        //        }
        //        else
        //        {
        //            trainees.IsAdmisisonConfirmed = false;
        //            Console.WriteLine("Admission Not Confirmed");
        //            return false;

        //        }

        //    }

        //}

        



    }
}
