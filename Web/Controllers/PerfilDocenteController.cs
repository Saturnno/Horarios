using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using Web.Models;

namespace Web.Controllers
{
    public class PerfilDocenteController : BaseController<PerfilDocente>
    {
        // GET: PerfilDocente
       public ActionResult Guardar(List<Materia>materias, int? id)
        {
            materias.ForEach(i =>
            {
                if (!_rep.AsQueryable().Any(o => o.MaestroId == (int)id && o.MateriaId == i.Id))
                {
                    _rep.Add(new PerfilDocente()
                    {
                        MaestroId = (int)id,
                        MateriaId = i.Id
                    });
                }
                
            });
            _rep.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MassList()
        {
            return View();
        }
    }
}