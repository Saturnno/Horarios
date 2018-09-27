using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Web.Controllers
{
    public class ProgramaEducativoController : BaseController<ProgramaEducativo>
    {
        // GET: ProgramaEducativo
        public override ActionResult GetRows()
        {
            return Json(_dt.Database.SqlQuery<int>("SELECT COUNT(*) FROM PROGRAMASEDUCATIVOS").FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public override JsonResult GetList(int? page, int? total)
        {
            return Json(_rep.AsQueryable().Include(i => i.Departamento).Include(i => i.Departamento.Unidad).OrderBy(i => i.Id).Skip(((int)page - 1) * 13).Take(13).ToList(), JsonRequestBehavior.AllowGet);
        }
        public override ActionResult Create()
        {
            List<SelectListItem> l = new List<SelectListItem>();
            var unidades = _dt.Unidades.ToList();
            unidades.ForEach(i=> { l.Add(new SelectListItem() {Text=i.Nombre,Value=i.Id.ToString() }); });
            ViewBag.Unidades = l;
            return View(); ;
        }
    }
}