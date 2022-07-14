using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        public static void Add()
        {
            ML.Alumno alumno = new ML.Alumno();  //INSTANCIA PARA CREAR OBJETOS QUE ME PERMITAN INTERACTUAR CON LOS MÉTODOS Y ATRIBUTOS DE LA CLASE

            Console.WriteLine("Ingrese el nombre");
            alumno.Nombre = Console.ReadLine();


            Console.WriteLine("Ingrese el ApellidoPaterno");
            alumno.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el ApellidoMaterno");
            alumno.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el Email");
            alumno.Email = Console.ReadLine();

            alumno.Semestre = new ML.Semestre(); //instacia de clase de semestre

            Console.WriteLine("Ingrese el id del semestre: ");
            alumno.Semestre.IdSemestre = int.Parse(Console.ReadLine());


            //ML.Result result = BL.Alumno.Add(alumno);
            //ML.Result result = BL.Alumno.AddSP(alumno);
            //ML.Result result = BL.Alumno.AddEF(alumno);
            ML.Result result = BL.Alumno.AddLINQ(alumno);

            if (result.Correct)
            {
                Console.WriteLine("Registro exitoso");

            }
            else
            {
                Console.WriteLine("Ocurrio un error al realizar la insercion");
            }
        }

        public static void Update()
        {
            ML.Alumno alumno = new ML.Alumno();

            Console.WriteLine("Ingresa el Id");
            alumno.IdAlumno = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el Nombre");
            alumno.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el ApellidoPaterno");
            alumno.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el ApellidoMaterno");
            alumno.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el email");
            alumno.Email = Console.ReadLine();

            ML.Result result = BL.Alumno.Update(alumno);

            if (result.Correct)
            {
                Console.WriteLine("El registro se actualizó correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error");
            }


        }

        public static void Delete()
        {
            ML.Alumno alumno = new ML.Alumno();

            Console.WriteLine("Ingrese el Id del registro a eliminar");
            alumno.IdAlumno = int.Parse(Console.ReadLine());

            ML.Result result = BL.Alumno.Delete(alumno);

            if (result.Correct)
            {
                Console.WriteLine("El registro se elimino correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al eliminar el registro");
            }
        }

        public static void GetAll()
        {
            //ML.Result result = BL.Alumno.GetAllSP();
            //ML.Result result = BL.Alumno.GetAllEF();
            ML.Result result = BL.Alumno.GetAllLINQ();

            if(result.Correct)
            {
                foreach(ML.Alumno alumno in result.Objects)
                {
                    Console.WriteLine("IdAlumno: " + alumno.IdAlumno);
                    Console.WriteLine("Nombre: " + alumno.Nombre);
                    Console.WriteLine("ApellidoPaterno: " + alumno.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno: " + alumno.ApellidoMaterno);
                    Console.WriteLine("Email: " + alumno.Email);
                  
                    Console.WriteLine("IdSemestre: " + alumno.Semestre.IdSemestre);
                    Console.WriteLine("---------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un error al realizar la consulta ");
            }
        }

        public static void GetById()
        {
            Console.WriteLine("Ingrese el Id a consultar");
            ML.Result result = BL.Alumno.GetByIdEF(int.Parse(Console.ReadLine()));

            if(result.Correct)
            {
                ML.Alumno alumno = ((ML.Alumno)result.Object); //UNBOXING

                Console.WriteLine("IdAlumno: " + alumno.IdAlumno);
                Console.WriteLine("Nombre: " + alumno.Nombre);
                Console.WriteLine("ApellidoPaterno: " + alumno.ApellidoPaterno);
                Console.WriteLine("ApellidoMaterno: " + alumno.ApellidoMaterno);
                Console.WriteLine("Email: " + alumno.Email);
                Console.WriteLine("IdSemestre: " + alumno.Semestre.IdSemestre);

                
            }
            else
            {
                Console.WriteLine("Ocurrio un error al realizar la consulta" + result.ErrorMessage);
            }
        }
        
        


    }


        
}
