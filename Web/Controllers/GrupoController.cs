using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using System.Data.Entity;

namespace Web.Controllers
{
    public class GrupoController : BaseController<Grupo>
    {
        // GET: Grupo
        public override ActionResult GetRows()
        {
            return Json(_dt.Database.SqlQuery<int>("SELECT COUNT(*) FROM GRUPOS").FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public override JsonResult GetList(int? page, int? total)
        {
            return Json(_rep.AsQueryable().Include(i => i.ProgramaEducativo).Include(i => i.Trimestre).Include(i => i.Turno).OrderBy(i=>i.Id).Skip(((int)page - 1) * 13).Take(13).ToList(), JsonRequestBehavior.AllowGet);
        }
        public override JsonResult GetEditEntidad(int id)
        {
            return Json(_rep.AsQueryable().Where(i => i.Id == id).Include(i=>i.ProgramaEducativo.Departamento).Select(i=>new {
                i.Id,
                i.Nombre,
                i.Aula,
                i.ProgramaEducativoId,
                i.TrimestreId,
                i.TurnoId,
                UnidadId=i.ProgramaEducativo.Departamento.UnidadId,
                i.Ano
            }).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
    }
}