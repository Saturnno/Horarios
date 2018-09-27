using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Web.Controllers
{
    public class DepartamentoController : BaseController<Departamento>
    {
        // GET: Departamento
        public override JsonResult GetList(int? page,int? total)
        {
            return Json(_rep.AsQueryable().Include(i => i.Unidad).OrderBy(i => i.Id).Skip(((int)page - 1) * 13).Take(13).ToList(), JsonRequestBehavior.AllowGet);
        }
        public override ActionResult GetEntidad(int? id)
        {
            return Json(_rep.AsQueryable().Include(i => i.Unidad).FirstOrDefault(i => i.Id == id), JsonRequestBehavior.AllowGet);
        }
        public override ActionResult GetRows()
        {
            return Json(_dt.Database.SqlQuery<int>("SELECT COUNT(*) FROM DEPARTAMENTOS").FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public override ActionResult Create()
        {
            var items = new List<SelectListItem>();
            var res = _dt.Unidades.ToList();
            res.ForEach(i => { items.Add(new SelectListItem() {Value=i.Id.ToString(),Text=i.Nombre }); });
            ViewBag.Items = items;
            return View();
        }
        public override ActionResult Edit(int? id)
        {
            return View();
        }
       
    }
}