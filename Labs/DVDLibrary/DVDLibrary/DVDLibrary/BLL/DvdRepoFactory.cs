using DVDLibrary.DATA;
using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DVDLibrary.BLL
{
    public static class DvdRepoFactory
    {
        public static DvdManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new DvdManager(new DvdRepositoryMock());
                case "EntityFramework":
                    return new DvdManager(new DvdRepositoryEF());
                case "ADO":
                    return new DvdManager(new DvdRepositoryADO());
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}