using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Tarea> lista_uno = new List<Tarea>();
            int opcion = 0;
            try
            {
                while (opcion != 5)
                {
                    Console.WriteLine("LISTA");
                    Console.WriteLine("__________________________________________________________________________");
                    Console.WriteLine("Elige una opción: ");
                    Console.WriteLine("1.Agregar nueva tarea: ");
                    Console.WriteLine("2.Listar todas las tareas: ");
                    Console.WriteLine("3.Marcar Tarea como completada: ");
                    Console.WriteLine("4.Eliminar tarea: ");
                    Console.WriteLine("5.Salir: ");
                    Console.WriteLine("__________________________________________________________________________");
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            Agregar(lista_uno);
                            break;
                        case 2:
                            Listar(lista_uno);
                            break;
                        case 3:
                            MarcarTarea(lista_uno);
                            break;
                        case 4:
                            EliminarTarea(lista_uno);
                            break;
                        case 5:
                            Console.WriteLine("__________________________________________________________________________");
                            Console.WriteLine("Gracias, vuelve pronto");
                            break;
                        default:
                            Console.WriteLine("Opción no válida, intentalo de nuevo");
                            break;
                    }

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("ingresa un número valido");
            }
        }



        static void Agregar(List<Tarea> lista_uno)
        {
            try
            {
                Console.WriteLine("__________________________________________________________________________");
                Console.WriteLine("Agregar Nueva Tarea");

                Console.WriteLine("Ingresa descripción");
                String Descripcion = Console.ReadLine();

               
                Console.WriteLine("Ingresa Fecha limite (formato yyyy-MM-dd)");
                DateTime FechaLimite = DateTime.Parse(Console.ReadLine());


                lista_uno.Add(new Tarea(Descripcion, FechaLimite));

                Console.WriteLine("Se agregó exitosamente la tarea");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar tarea: {ex.Message}");

            }


        }


        static void Listar(List<Tarea> lista_uno)
        {
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("Listar Tareas: ");
            if (lista_uno.Count == 0)
            {
                Console.WriteLine("No hay tareas");
            }
            else
            {
                for (global::System.Int32 i = 0; i < lista_uno.Count; i++)
                {
                    var tarea = lista_uno[i];
                    Console.WriteLine($"{i + 1}. Descripción: {tarea.GetDescripcion()}, Fecha limite: {tarea.GetFechaLimite()}, Completada: {(tarea.GetEstadoCompletado() ? "Si" : "No")}");
                }
            }
        }

        static void MarcarTarea(List<Tarea> lista_uno)
        {
            try
            {
                Listar(lista_uno);
                Console.WriteLine("__________________________________________________________________________");
                if (lista_uno.Count > 0)
                {
                    Console.WriteLine("Ingrese número de la tarea que desea completar");
                    int indice = int.Parse(Console.ReadLine());
                    indice -= 1;
                    if (indice >= 0 && indice < lista_uno.Count)
                    {
                        lista_uno[indice].SetEstadoCompletado(true);
                        Console.WriteLine("Tarea marcada como completa");
                    }
                    else
                    {
                        Console.WriteLine("Ingresa un número valido,que este dentro del rango de la lista");
                    }




                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar tarea: {ex.Message}");
            }
        }


        static void EliminarTarea(List<Tarea> lista_uno)
        {
            try
            {
                Console.WriteLine("Eliminar Tarea de Lista");
                Listar(lista_uno);
                Console.WriteLine("__________________________________________________________________________");

                Console.WriteLine("Ingrese número de la tarea que desea eliminar");
                int indice = int.Parse(Console.ReadLine());
                indice -= 1;
                if (indice >= 0 && indice < lista_uno.Count)
                {
                    lista_uno.RemoveAt(indice);
                    Console.WriteLine("Tarea eliminada correctamente");

                }
                else
                {
                    Console.WriteLine("Ingresa un número valido,que este dentro del rango de la lista");
                }

            }catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar tarea: {ex.Message}");

            }

        }


        class Tarea
        {
            private String Descripcion;
            private DateTime FechaLimite;
            private bool EstadoCompletado;


            public Tarea(string Descripcion, DateTime FechaLimite)
            {
                this.Descripcion = Descripcion;
                this.FechaLimite = FechaLimite;
                this.EstadoCompletado = false;
            }

            public string GetDescripcion()
            {
                return Descripcion;
            }

            public void SetDescripcion(string Descripcion)
            {
                this.Descripcion = Descripcion;
            }

            public DateTime GetFechaLimite()
            {
                return FechaLimite;
            }

            public void SetFechaLimite(DateTime FechaLimite)
            {
                this.FechaLimite = FechaLimite;
            }

            public bool GetEstadoCompletado()
            {
                return EstadoCompletado;
            }

            public void SetEstadoCompletado(bool EstadoCompletado)
            {
                this.EstadoCompletado = EstadoCompletado;
            }
        }
    }
}
