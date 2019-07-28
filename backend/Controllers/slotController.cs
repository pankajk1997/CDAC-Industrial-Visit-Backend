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
    public class slotController : ApiController
    {
        [HttpGet]
        [Route("api/slot/all")]
        public List<cslot> selectall()
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var query = (from i in context.slots
                         orderby i.vdate descending
                         select new cslot
                         {
                             id=i.id,
                             vdate=i.vdate,
                             stat=i.stat,
                             feedback=i.feedback,
                             org=i.org,
                             uid=i.uid
                         }).ToList();
            return query;
        }

        [HttpGet]
        [Route("api/slot/{reqid}")]
        public cslot sselect(int reqid)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var query = (from i in context.slots
                         where i.id == reqid
                         select new cslot
                         {
                             id = i.id,
                             vdate = i.vdate,
                             stat = i.stat,
                             feedback = i.feedback,
                             org = i.org,
                             uid = i.uid
                         }).FirstOrDefault();
            return query;
        }

        [HttpGet]
        [Route("api/slot/usel/{userid}")]
        public List<cslot> uselect(int userid)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            var query = (from i in context.slots
                         where i.uid == userid
                         select new cslot
                         {
                             id = i.id,
                             vdate = i.vdate,
                             stat = i.stat,
                             feedback = i.feedback,
                             org = i.org,
                             uid = i.uid
                         }).ToList();
            return query;
        }

        [HttpPost]
        public void insert(cslot u)
        {
            var ins = new slot
            {
                id = u.id,
                vdate = u.vdate,
                stat = u.stat,
                feedback = u.feedback,
                org = u.org,
                uid = u.uid
            };
            DataClassesDataContext context = new DataClassesDataContext();
            context.slots.InsertOnSubmit(ins);
            context.SubmitChanges();
        }

        [HttpGet]
        [Route("api/slot/pupd/{reqid}")]
        public void pupdate(int reqid)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            slot upd = context.slots.Single(i => i.id == reqid);
            upd.stat = "pending";
            context.SubmitChanges();
        }

        [HttpGet]
        [Route("api/slot/cupd/{reqid}")]
        public void cupdate(int reqid)
        {
            DataClassesDataContext context = new DataClassesDataContext();
            slot upd = context.slots.Single(i => i.id == reqid);
            upd.stat = "confirmed";
            context.SubmitChanges();
        }
    }
} 