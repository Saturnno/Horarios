using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Entities;
using Web.Models;

namespace Web.Controllers
{
    public class ProgramaEducativoDetalleController : BaseController<ProgramaEducativoDetalle>
    {
        // GET: ProgramaEducativoDetalle
        public ActionResult MassList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Guardar(List<Materia> materias, int? trimestre, int? programa)
        {
            materias.ForEach(i =>
            {
                if (!_rep.AsQueryable().Any(o => o.MateriaId == i.Id && o.TrimestreId == (int)trimestre && o.ProgamaEducativoId == (int)programa)){
                    _rep.Add(new ProgramaEducativoDetalle()
                    {
                        MateriaId = i.Id,
                        ProgamaEducativoId = (int)programa,
                        TrimestreId = (int)trimestre
                    });
                }
            });
            _rep.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Buscar(int? trimestre, int? programa)
        {
            if (!programa.HasValue)
                throw new BusinessException("Debe Escoger Un Programa Educativo");
            return Json(_rep.AsQueryable().Include(i=>i.Materia).Where(i => i.ProgamaEducativoId == programa && i.TrimestreId == trimestre).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}