﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace QLKSProject.Controllers
{
    public class TestController : ApiController
    {
        //This resource is For all types of role
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        public IHttpActionResult GetResource1()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello: " + identity.Name);
        }
        //This resource is only For Admin and SuperAdmin role
        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet]
        public IHttpActionResult GetResource2()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var Email = identity.Claims
                      .FirstOrDefault(c => c.Type == "Email").Value;
            var UserName = identity.Name;

            return Ok("Hello " + UserName + ", Your Email ID is :" + Email);
        }
        //This resource is only For SuperAdmin role
        [Authorize(Roles = "")]
        [HttpGet]
        public IHttpActionResult GetResource3()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + "Your Role(s) are: " + string.Join(",", roles.ToList()));
        }
    }
}
