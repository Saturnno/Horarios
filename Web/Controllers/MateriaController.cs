using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using System.Data.Entity;

namespace Web.Controllers
{
    public class MateriaController : BaseController<Materia>
    {
        // GET: Materia
        public override ActionResult GetRows()
        {
            return Json(_dt.Database.SqlQuery<int>("SELECT COUNT (*) FROM MATERIAS").FirstOrDefault(),JsonRequestBehavior.AllowGet);
        }
        public override JsonResult GetList(int? page, int? total)
        {
            return Json(_rep.AsQueryable().Include(i => i.Categoria).OrderBy(i => i.Id).Skip(((int)page-1)*13).Take(13).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}