using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using backend.Models;
using System.Web.Http.Cors;

namespace backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class usersController : ApiController
    {
        [HttpGet]
        [Route("api/users/all")]
        public List<cuser> selectall()
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var query = (from i in context.users
                        select new cuser
                        {
                            id = i.id,
                            fname = i.fname,
                            lname = i.lname,
                            email = i.email,
                            pass = i.pass,
                            phone = i.phone
                        }).ToList();
            return query;
        }

        [HttpGet]
        [Route("api/users/{phone}")]
        public cuser sselect(string phone)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var query = (from i in context.users
                         where i.phone == phone
                         select new cuser
                         {
                             id = i.id,
                             fname = i.fname,
                             lname = i.lname,
                             email = i.email,
                             pass = i.pass,
                             phone = i.phone
                         }).FirstOrDefault();
            return query;
        }

        [HttpPost]
        public void insert(cuser u)
        {
            var ins = new user
            {
                id = u.id,
                fname = u.fname,
                lname = u.lname,
                email = u.email,
                pass = u.pass,
                phone = u.phone
            };
            DataClassesDataContext context = new DataClassesDataContext();
            context.users.InsertOnSubmit(ins);
            context.SubmitChanges();
        }

    }
}
