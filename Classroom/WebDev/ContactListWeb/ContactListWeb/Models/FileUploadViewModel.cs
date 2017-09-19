using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactListWeb.Models
{
    public class FileUploadViewModel
    {
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}