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


            //ML.Result result = BL.Alumno.Add(alumno);
            ML.Result result = BL.Alumno.AddSP(alumno);

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


    }


        
}
