using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BEFTrial.DB;

namespace BEFTrial.Models
{
    public class DBUpdaterModels
    {
        public List<Student> GetStudentDetails()
        {
            SchoolSchemaEntities s = new SchoolSchemaEntities();
            var temp = s.Students.ToList();
            return temp;
        }

        //get 
        public IEnumerable<FacultyWithPosition> GetFacultyWithPositions(string FacultyPosition)
        {
            FacultyPosition = FacultyPosition.Equals(null) ? "None" : FacultyPosition;
            SchoolSchemaEntities db = new SchoolSchemaEntities();
            var query = from x in db.Faculties
                        join y in db.Positions on x.PositionID equals y.PositionID
                        where y.PositionName.Equals(FacultyPosition)
                        select new FacultyWithPosition
                        {
                            FacultyID = x.FacultyID,
                            FacultyName = x.FacultyName,
                            PositionName = y.PositionName
                        };
            IEnumerable<FacultyWithPosition> result = query.AsEnumerable<FacultyWithPosition>();
            return result;
        }

        public List<SP_FetchStudentAggregatePercentage_Result> GetStudentAggregateData()
        {
            using (SchoolSchemaEntities context = new SchoolSchemaEntities())
            {
                var result = context.SP_FetchStudentAggregatePercentage().ToList();
                return result;
            }
        }
    }
}