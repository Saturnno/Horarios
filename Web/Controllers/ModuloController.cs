using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using System.Data.Entity.SqlServer;

namespace Web.Controllers
{
    public class ModuloController : BaseController<Modulo>
    {
        // GET: Modulo
        public override ActionResult GetRows()
        {
            return Json(_dt.Database.SqlQuery<int>("SELECT COUNT(*) FROM MODULOS").FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public override JsonResult GetList(int? page, int? total)
        {
            return Json(_rep.AsQueryable().OrderBy(i => i.Id).Skip(((int)page - 1) * 13).Take(13).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}