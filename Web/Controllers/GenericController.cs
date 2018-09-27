using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Business;
using Business.Repositorios;
using DataAccess;
using Web.Models;

namespace Web.Controllers
{
    public class GenericController<T,TContext> : Controller where T:class where TContext:DbContext,new()
    {
        // GET: Generic
        protected GenericRepository<T, TContext> _rep;
        protected TContext _dt;
        public GenericController()
        {
            _rep = new GenericRepository<T, TContext>();
            _dt = new TContext();
        }
        public virtual ActionResult Index()
        {
            return (ActionResult)this.View();
        }
        public virtual ActionResult List()
        {
            return (ActionResult)this.View();
        }
        public virtual ActionResult Create()
        {
            return (ActionResult)this.View();
        }
        public virtual ActionResult GetRows()
        {
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public virtual ActionResult Create(T entidad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _rep.Add(entidad);
                    _rep.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new BusinessException("Error :" + e.Message);
                }
            }
            return RedirectToAction("Index");
        }
        public virtual ActionResult Delete(int? id)
        {
            return (ActionResult)this.View();
        }
        [HttpPost]
        public virtual ActionResult Delete(T entidad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _rep.Delete(entidad);
                    _rep.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new BusinessException("Error :" + e.Message);
                }
            }
            return RedirectToAction("Index");
        }
        public virtual ActionResult GetEntidad(int? id)
        {
            try
            {
                return Json(_rep.Find((int)id), JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new BusinessException("Error :" + e.Message);
            }
        }
        public virtual ActionResult Details()
        {
            return (ActionResult)this.View();
        }

        public virtual ActionResult Edit(int? id)
        {
            return (ActionResult)this.View();
        }
        [HttpPost]
        public virtual ActionResult Edit(T entidad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _rep.Update(entidad);
                    _rep.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new BusinessException("Error :" + e.Message);
                }
            }
            return RedirectToAction("Index");
        }
        public virtual JsonResult GetList(int? page,int? total)
        {
            try
            {
                var res = _rep.AsQueryable().OrderBy(i => true).Skip(((int)page - 1) * 13).Take(13).ToList();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new BusinessException("Error :" + e.Message);
            }
        }
        public virtual JsonResult GetEditEntidad(int id)
        {
            try
            {
                return Json(_rep.Find(id), JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                throw new BusinessException("Error :" + e.Message);
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            this.Response.StatusCode = 500;
            filterContext.Result = Json(new { Message = filterContext.Exception.Message }, JsonRequestBehavior.AllowGet);
        }
    }

}