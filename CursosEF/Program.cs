using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursosEF.Modelo;

namespace CursosEF
{
    class Program
    {
        static DatosEntities db = new DatosEntities();
        
        static void Main(string[] args)
        {

           

            //var cur = new Curso()
            //{
            //    duracion = 200,
            //    inicio = DateTime.Now,
            //    nombre = "Costura",
            //    profesor = 2

            //};

            //db.Curso.Add(cur);
            //db.SaveChanges();


            //foreach (var curso in db.Curso)
            //{
            //    Console.WriteLine("curso: {0} empieza el {1:d} y lo imparte {2}",
            //        curso.nombre,curso.inicio,
            //        curso.Profesor1!=null?curso.Profesor1.nombre:"Sin profesor");

            //    //curso.profesor = 3;

            //    db.Curso.Remove(curso);

            //}
            //db.SaveChanges();



            var curso = db.Curso.Find(8);
           
            Console.WriteLine("curso: {0} empieza el {1:d} y lo imparte {2}",
                    curso.nombre,curso.inicio,
                    curso.Profesor1!=null?curso.Profesor1.nombre:"Sin profesor");

            var cursos = GetByIdProfesor(3);
            var cursos2 = GetByIdProfesorDinamico(3);

            foreach (var o in cursos2)
            {
                    Console.WriteLine(o.curso);
            }


            Console.ReadLine();
        }

        public bool xxxxx(Curso o)
        {
            return o.profesor == 22;
        }

        public static IEnumerable<Curso> GetByIdProfesor(int id)
        {

            var datos = db.Curso.Where(o => o.profesor == id).OrderBy(o => o.nombre);

            /*var datos = from o in db.Curso
                where o.profesor == id
                orderby o.nombre
                select o;
            */
            return datos;


        }
        public static IEnumerable<dynamic> GetByIdProfesorDinamico(int id)
        {

           // var datos = db.Curso.Where(o => o.profesor == id).OrderBy(o => o.nombre);

            var datos = from o in db.Curso
                where o.profesor == id
                orderby o.nombre
                select new 
                {
                    curso=o.nombre,
                    duracion = o.duracion

                };
            
            return datos;


        }


    }
}
