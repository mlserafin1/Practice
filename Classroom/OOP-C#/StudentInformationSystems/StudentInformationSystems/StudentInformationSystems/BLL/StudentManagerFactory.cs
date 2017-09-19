using System.Configuration;
using StudentInformationSystems.Data;

namespace StudentInformationSystems.BLL
{
    public class StudentManagerFactory
    {
        public static StudentManager Create()
        {
            string mode = ConfigurationManager.AppSettings["mode"];
            StudentManager result;

            switch (mode)
            {
                case "test":
                    result = new StudentManager(new TestStudentRepository());
                    break;
                default:
                    string filename = ConfigurationManager.AppSettings["FilePath"];
                    result = new StudentManager(new FileStudentRepository(filename));
                    break;
            }
            return result;
        }
    }
}
