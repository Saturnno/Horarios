using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using System.Data.Entity;

namespace Web.Controllers
{
    public class MaestroController : BaseController<Maestro>
    {
        // GET: Maestro
        public override ActionResult GetRows()
        {
            return Json(_dt.Database.SqlQuery<int>("SELECT COUNT(*) FROM MAESTROS").FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public override JsonResult GetList(int? page, int? total)
        {
            return Json(_rep.AsQueryable().Include(i=>i.Unidad).Include(i=>i.Departamento).Include(i=>i.ProgramaEducativo).Include(i=>i.Nombramiento).OrderBy(i=>i.Id).Skip(((int)page-1)*13).Take(13).ToList(),JsonRequestBehavior.AllowGet);
        }
    }
}