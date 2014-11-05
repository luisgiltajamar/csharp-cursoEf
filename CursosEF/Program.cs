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

        public static Curso GetById(int id)
        {
            var datos = db.Curso.Find(id);

            Curso datos2 = db.Curso.FirstOrDefault(o => o.idCurso == id);

            var datos3 = db.Curso.First(o => o.idCurso == id);

            return datos3;
        }

        public static int Contar()
        {
            var n = db.Curso.Count(o=>o.inicio>DateTime.Now);
            return n;
        }
        public static int Sumar()
        {
            var n = db.Curso.Sum(o => o.duracion);
            var n2 = db.Curso.Max(o => o.duracion);
            var n3 = db.Curso.Min(o => o.duracion);
            double n4 = db.Curso.Where(o=>o.profesor==1).Average(o => o.duracion);

            return n2;
        }

        public static IEnumerable<Curso> BuscarDentro()
        {
            String[] array = {"a", "c", "j", "m", "k"};
            


            var c = db.Curso.Where(o => o.nombre.StartsWith("c")  
                );
            var cc = db.Curso.Where(o => o.duracion > 100
                                         && o.nombre.Contains("c") 
                                         && o.profesor == 1);
            var c2 = db.Curso.Where(o => o.nombre.EndsWith("c"));
            var c3 = db.Curso.Where(o => o.nombre.Contains("c"));
            var c4 = db.Curso.Where(o => array.Contains(o.nombre));
            return c4;
        }

        public static int[] IdProfesores()
        {
            //int[] ids=new int[db.Profesor.Count()];

            //int n = 0;
            //foreach (var profesor in db.Profesor)
            //{
            //    ids[n++] = profesor.idProfesor;

            //}

            //return ids;

            var ids = db.Profesor.Select(o => o.idProfesor);
            return ids.ToArray();
        }

        public static IEnumerable<CursoProfe> GetCursoProfe()
        {
            var datos = db.Curso.Select(o => new CursoProfe()
            {
                Profesor = o.Profesor1.nombre,
                Curso = o.nombre

            });
            return datos;
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
