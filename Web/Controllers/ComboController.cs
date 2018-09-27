using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using DataAccess;
using System.Web.Http.ExceptionHandling;
using System.Data.Entity;

namespace Web.Controllers
{
    [RoutePrefix("api/combo")]
    public class ComboController : ApiController
    {
        private DataContext dt;
        public ComboController()
        {
            dt = new DataContext();
        }
        [HttpGet]
        [Route("unidad")]
        public HttpResponseMessage unidad()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK,dt.Unidades.ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = e.Message });
            }
            
        }
        [HttpGet]
        [Route("departamento/{id:int}")]
        public HttpResponseMessage departamento(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.Departamentos.Where(i=>i.UnidadId==id).ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = e.Message });
            }
        }
        [HttpGet]
        [Route("programaeducativo/{id:int}")]
        public HttpResponseMessage programaeducativo(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.ProgramasEducativos.Where(i=>i.DepartamentoId==id).ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = e.Message });
            }
        }
        [HttpGet]
        [Route("mes")]
        public HttpResponseMessage mes()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.Meses.ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = e.Message });
            }
        }
        [HttpGet]
        [Route("nombramiento")]
        public HttpResponseMessage nombramiento()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.Nombramientos.ToList());
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new {Message=e.Message });
            }
        }
        [HttpGet]
        [Route("categoria")]
        public HttpResponseMessage categoria()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.Categorias.ToList());
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }
        [Route("maestro/{id:int}")]  
        [HttpGet]
        public HttpResponseMessage maestro(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.Maestros.Where(i => i.ProgramaEducativoId == id).Select(i => new
                {
                    i.Nombre,
                    i.Id
                }).ToList());
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }
        [HttpGet]
        [Route("materia")]
        public HttpResponseMessage materia()
        {
            try
            {
               
                return Request.CreateResponse(HttpStatusCode.OK, dt.Materias.ToList());
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }
        [HttpGet]
        [Route("perfildocente/{id:int}")]
        public HttpResponseMessage perfildocente(int? id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, dt.PerfilesDocentes.Where(i => i.MaestroId == (int)id).Include(i=>i.Materia).Select(i=>new {
                    Nombre=i.Materia.Nombre,
                    Id=i.Id
                }).ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }
        [HttpGet]
        [Route("trimestre")]
        public HttpResponseMessage trimestre()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.Trimestres.ToList());
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    Message=e.Message
                });
            }
        }
        [HttpGet]
        [Route("turno")]
        public HttpResponseMessage turno()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.Turnos.ToList());
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }
        [HttpGet]
        [Route("modulo")]
        public HttpResponseMessage modulo()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.Modulos.Select(i=>new { Id=i.Id,Nombre=i.FechaInicio+" - "+i.FechaFinal}).ToList());
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }
        [HttpPost]
        public HttpResponseMessage grupo(int? id,int? trimestre)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.Grupos.Include(i=>i.ProgramaEducativo).Include(i=>i.Trimestre).Include(i=>i.Turno).Where(i => i.ProgramaEducativoId == (int)id&&i.TrimestreId==(int)trimestre).Select(i=>new {
                    i.Id,
                    Nombre=i.Nombre+"-"+i.ProgramaEducativo.Nombre +"-"+i.Trimestre.Nombre+"-"+i.Turno.Nombre
                }).ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }
        [HttpGet]
        [Route("dia")]
        public HttpResponseMessage dia()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new[]
                {
                    new {Id=1,Nombre="Lunes"},
                    new {Id=2,Nombre="Martes"},
                    new {Id=3,Nombre="Miercoles"},
                    new {Id=4,Nombre="Jueves"},
                    new {Id=5,Nombre="Viernes"},
                    new {Id=6,Nombre="Sabado"}
                });
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }
        [HttpGet]
        [Route("materiaasignada/{id:int}")]
        public HttpResponseMessage materiaasignada(int? id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.PerfilesDocentes.Include(i=>i.Materia).Where(i => i.MaestroId == (int)id).Select(i=>new {Id=i.Materia.Id,Nombre=i.Materia.Nombre }).ToList());
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }
        [HttpGet]
        public HttpResponseMessage materiaprogramaeducativo(int? id,int?trimestre)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.ProgramasEducativosDetalles.Include(i => i.Materia).Where(i => i.ProgamaEducativoId == (int)id&&i.TrimestreId==trimestre).Select(i => new { Id = i.Materia.Id, Nombre = i.Materia.Nombre }).ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }
        [HttpGet]
        [Route("maestrodisponibilidad/{id:int}")]
        public HttpResponseMessage maestrodisponibilidad(int? id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, dt.Maestros.Where(i => i.Id == (int)id).Select(i => new {i.Disponibilidad }).FirstOrDefault());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = e.Message });
            }
        }

    }
}
