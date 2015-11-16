using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PerformAnt.Controllers.WebApi
{
    public class SampleController : ApiController
    {
        [CacheControl(MaxAge = 3600)]
        public string Get()
        {
            return "Just a sample.";
        }
    }
}