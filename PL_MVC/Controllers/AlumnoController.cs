using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        [HttpGet] //ACTION VERB : Define la accion que realizará el método 
        public ActionResult GetAll() // ActionMethod: Métodos que  tenemos en el controlador
        {
            ML.Alumno alumno = new ML.Alumno();

            ML.Result result = BL.Alumno.GetAllEF();

            if(result.Correct)
            {
                alumno.Alumnos = result.Objects;
            }
            else
            {
                //Error
            }
            return View(alumno); //ACTION RESULT: Tipos de retorno EJEMPLO: ActionResult -> Vista en HTML
        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.Semestre = new ML.Semestre();
            return View(alumno);
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.AddEF(alumno);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Registro existoso";
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error";
            }
            return View("Modal");
        }
    }
}