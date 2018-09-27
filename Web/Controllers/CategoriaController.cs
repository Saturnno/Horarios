using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;

namespace Web.Controllers
{
    public class CategoriaController : BaseController<Categoria>
    {
        // GET: Categoria
        public override ActionResult GetRows()
        {
            return Json(_dt.Database.SqlQuery<int>("SELECT COUNT(*) FROM CATEGORIAS").FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
    }
}