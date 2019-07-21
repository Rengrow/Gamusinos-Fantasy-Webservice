using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceGamusinoFantasy.Models
{
    public class Response
    {
        public Response(string message)
        {
            this.message = message;
        }
        public Response()
        {
        }

        public string message { get; set; } 
    }
}