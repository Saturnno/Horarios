using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;

namespace Web.Controllers
{
    public class ModuloGrupoController : BaseController<ModuloGrupo>
    {
        // GET: ModuloGrupo
        public override ActionResult GetRows()
        {
            return Json(_dt.Database.SqlQuery<int>("SELECT COUNT(*) FROM MODULOSGRUPO").FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public override JsonResult GetList(int? page, int? total)
        {
            return Json(_rep.AsQueryable().OrderBy(i => i.Id).Skip(((int)page - 1) * 13).Take(13).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}