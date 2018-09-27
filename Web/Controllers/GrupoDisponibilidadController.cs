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
    public class GrupoDisponibilidadController : BaseController<GrupoDisponibilidad>
    {
        // GET: GrupoDisponibilidad
        public override JsonResult GetEditEntidad(int id)
        {
            return Json(_rep.AsQueryable().Include(i=>i.Maestro).Where(i=>i.Id==id).Select(i=>new
            {
                i.Id,
                i.GrupoId,
                i.MaestroId,
                i.MateriaId,
                i.ModuloId,
                i.Dia,
                UnidadId=i.Maestro.UnidadId,
                DepartamentoId=i.Maestro.DepartamentoId,
                ProgramaEducativoId=i.Maestro.ProgramaEducativoId,
                i.Maestro.Disponibilidad,
                i.TrimestreId
            }).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult MassList()
        {
            return View();
        }
        public ActionResult ListGrupoDisponibilidad(int grupo,int dia,int trimestre)
        {
        
           
            return Json(_rep.AsQueryable().Include(i => i.Grupo).Include(i => i.Maestro).Include(i => i.Materia).Include(i => i.Modulo).Where(i => i.GrupoId == grupo && i.Dia == dia&&i.TrimestreId==trimestre).Select(i=>new {
                i.Id,
                Grupo=i.Grupo.Nombre,
                Materia=i.Materia.Nombre,
                Dia=i.Dia,
                Modulo=i.Modulo.FechaInicio+" - "+i.Modulo.FechaFinal,
                Maestro=i.Maestro.Nombre
            }).ToList(), JsonRequestBehavior.AllowGet);

        }
        public string BuscaDia(int i)
        {
            Dictionary<int,string> dias = new Dictionary<int, string>();
            dias.Add(1, "Lunes");
            dias.Add(1, "Martes");
            dias.Add(1, "Miercoles");
            dias.Add(1, "Jueves");
            dias.Add(1, "Viernes");
            dias.Add(1, "Sabado");
            return dias[i];
        }
        public override ActionResult Create(GrupoDisponibilidad g)
        {
            if (ModelState.IsValid)
            {
                if (!_rep.AsQueryable().Any(i =>i.Dia==g.Dia&& i.ModuloId == g.ModuloId&&i.TrimestreId==i.TrimestreId&&i.MaestroId==g.MaestroId))
                {
                    _rep.Add(g);
                    _rep.SaveChanges();
                    var res = _rep.AsQueryable().Include(i => i.Maestro).Include(i => i.Trimestre).Include(i => i.Grupo).Include(i => i.Materia).Include(i => i.Modulo).Include(i => i.Dia).Where(i => i.Id==g.Id).Select(i => new {
                        Maestro = i.Maestro.Nombre,
                        Trimestre = i.Trimestre.Nombre,
                        Grupo = i.Grupo.Nombre,
                        Materia = i.Materia.Nombre,
                        Dia = i.Dia,
                        Modulo = i.Modulo.FechaInicio + " a " + i.Modulo.FechaFinal
                    }).FirstOrDefault();
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new BusinessException("El grupo ya esta tiene el modulo cubierto");
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult BuscaDisponibilidades(int? maestro, int? trimestre)
        {
            var res = _rep.AsQueryable().Include(i => i.Maestro).Include(i => i.Trimestre).Include(i => i.Grupo).Include(i => i.Materia).Include(i => i.Modulo).Include(i => i.Dia).Where(i => i.MaestroId == (int)maestro && i.TrimestreId == (int)trimestre).Select(i=>new {
                Maestro=i.Maestro.Nombre,
                Trimestre=i.Trimestre.Nombre,
                Grupo=i.Grupo.Nombre,
                Materia=i.Materia.Nombre,
                Dia=i.Dia,
                Modulo=i.Modulo.FechaInicio+" a "+i.Modulo.FechaFinal

            }).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MateriaAsignada(int? maestro,int? programa,int? trim)
        {
            var materiasMaestro = _dt.PerfilesDocentes.Include(i=>i.Materia).Where(i => i.MaestroId == maestro).Select(i => new { Id = i.Materia.Id,Nombre=i.Materia.Nombre }).ToList();
            var materiasPrograma = _dt.ProgramasEducativosDetalles.Include(i=>i.Materia).Where(i => i.ProgamaEducativoId == programa && i.TrimestreId == trim).Select(i=>new {Id=i.Materia.Id, Nombre = i.Materia.Nombre }).ToList();
            var res = materiasMaestro.Intersect(materiasPrograma).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Grupos(int? id, int? trimestre)
        {

                return Json(_dt.Grupos.Include(i => i.ProgramaEducativo).Include(i => i.Trimestre).Include(i => i.Turno).Where(i => i.ProgramaEducativoId == (int)id && i.TrimestreId == (int)trimestre).Select(i => new
                {
                    i.Id,
                    Nombre = i.Nombre + "-" + i.ProgramaEducativo.Nombre + "-" + i.Trimestre.Nombre + "-" + i.Turno.Nombre
                }).ToList(), JsonRequestBehavior.AllowGet) ;
            
            
        }
    }
}