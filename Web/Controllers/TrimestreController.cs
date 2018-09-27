using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using System.Data.Entity;

namespace Web.Controllers
{
    public class TrimestreController : BaseController<Trimestre>
    {
        // GET: Trimestre
        public override ActionResult GetRows()
        {
            return Json(_dt.Database.SqlQuery<int>("SELECT COUNT(*) FROM TRIMESTRES").FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public override ActionResult Create()
        {
            var l = new List<SelectListItem>();
            var meses = _dt.Meses.ToList();
            meses.ForEach(i => { l.Add(new SelectListItem() {Text=i.Nombre,Value=i.Id.ToString() }); });
            ViewBag.Meses = l;
            return View();
        }
        public override JsonResult GetList(int? page, int? total)
        {
            return Json(_rep.AsQueryable().Include(i => i.Mes).OrderBy(i => i.Id).Skip(((int)page - 1) * 13).Take(13).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}