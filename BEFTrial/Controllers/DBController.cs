using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BEFTrial.DB;
using BEFTrial.Models;

namespace BEFTrial.Controllers
{
    public class DBController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("studentdata/{className}/{section}")]
        public HttpResponseMessage GetStudentList(int className, string section)
        {
            try
            {
                List<Student> studentList = new List<Student>();
                DBUpdaterModels obj = new DBUpdaterModels();
                studentList = obj.GetStudentDetails().ToList<Student>();
                var JsonResponse = new
                {
                    statusCode = HttpStatusCode.OK,
                    message = "Success",
                    data = studentList
                };
                var response = Request.CreateResponse(HttpStatusCode.OK, JsonResponse);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        //[Authorize(Roles = "Administrator")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("facultyinfo")]
        public HttpResponseMessage GetFacultyByPosition(string fPosition)
        {

            try
            {
                fPosition = fPosition.Equals(null) ? "None" : fPosition;

                List<FacultyWithPosition> FacultyList = new List<FacultyWithPosition>();
                DBUpdaterModels obj = new DBUpdaterModels();
                FacultyList = obj.GetFacultyWithPositions(fPosition).ToList<FacultyWithPosition>();
                var JsonResponse = new
                {
                    statusCode = HttpStatusCode.OK,
                    message = "Success",
                    data = FacultyList
                };
                var response = Request.CreateResponse(HttpStatusCode.OK, JsonResponse);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("aggrdetails")]
        public HttpResponseMessage GetStudentAggregatePercentage()
        {

            try
            {
                DBUpdaterModels obj = new DBUpdaterModels();
                var aggrList = obj.GetStudentAggregateData();
                var JsonResponse = new
                {
                    statusCode = HttpStatusCode.OK,
                    message = "Success",
                    data = aggrList
                };
                var response = Request.CreateResponse(HttpStatusCode.OK, JsonResponse);
                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
