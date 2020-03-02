using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerProyectoIP
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0, op = 0;
            do //el do representa un bloque de código que se ejecutará por lo menos una vez 
            {
                
                Console.BackgroundColor = ConsoleColor.Black; //se establece el color de fondo de la consola 
                Console.Clear(); //se borra todo lo que tiene la consola
                Console.ForegroundColor = ConsoleColor.White; //se establece el color de la letra en la consola
                Console.WriteLine("--------------------------------------SISTEMA DE ORIENTACIÓN UNIVERSITARIA----------------------------------");
                Console.WriteLine("Ingrese su opción: \n 1. ESTUDIANTE \n 2. ADMIN \n 3. SALIR"); //se le pregunta al usuario qué gestión desea hacer
                try //se pone el try catch por si tenemos un error no manejado
                {
                    opcion = Convert.ToInt32(Console.ReadLine()); //se lee la opcion que desea el usuario
                    switch (opcion) //se hace un switch de la opción que el usuario escogió
                    {
                        case 1: //en caso de que sea 1 (ESTUDIANTE) 
                            Console.BackgroundColor = ConsoleColor.Blue; 
                            Console.Clear(); 
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            string usuarioest, contra, nombreest, apellidoest, cuiest, jornada, carrera; //variables string
                            int xclase = 0, xlab = 0, xsemestre = 0, xmatricula = 0, largo = 0; //variables enteras
                            double xmes = 0; //variable double
                            do //se repetirá el bloque de ingreso de usuario y contrasena hasta que no cumpla todas las condiciones
                            {
                                Console.WriteLine("Ingrese su usuario");
                                usuarioest = Console.ReadLine();
                                Console.WriteLine("Ingrese su contraseña");
                                contra = Console.ReadLine();
                                largo = usuarioest.Length;
                            } while (contra != "12345" || usuarioest.Substring(0, 3) != "EST" || largo != 10);
                            int cursos, labs;

                            if (contra == "12345" && usuarioest.Substring(0, 3) == "EST" && largo == 10) //si cumple con todas las condiciones, tanto el usuario como el password, entra al ingreso de datos
                            {
                                Console.WriteLine("Ingrese su nombre(s)");
                                nombreest = Console.ReadLine();
                                Console.WriteLine("Ingrese su apellido(s)");
                                apellidoest = Console.ReadLine();
                                do //si el cui no cumple con los 13 caracteres, lo solicitará de nuevo
                                {
                                    Console.WriteLine("Ingrese su CUI");
                                    cuiest = Console.ReadLine();
                                } while (cuiest.Length != 13);
                                Console.WriteLine("Ingrese el número de cursos");
                                cursos = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Ingrese el número de laboratorios");
                                labs = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Ingrese su jornada (AM o PM)");
                                jornada = Console.ReadLine();
                                Console.WriteLine("Presione ENTER para visualizar los datos"); //se imprimen los datos
                                Console.ReadKey();
                                Console.WriteLine("Nombre: " + nombreest + " " + apellidoest);
                                Console.WriteLine("Departamento: " + Departamento(cuiest)); //se llama la función departamento para determinar de cuál departamento viene la persona
                                Console.WriteLine("Carné: " + usuarioest.Substring(3, 7)); //se usa un substring para recortar cierto fragmento de un texto
                                Console.WriteLine("Año: " + Anio(usuarioest)); //se llama a la función anio para determinar el anio de inscripción de la persona
                                Console.WriteLine("Carrera: " + Carrera(usuarioest)); //basándose en la posición 4 y 5 del carné, se determina cuál es su carrera
                                carrera = Carrera(usuarioest); //se guarda en una variable para determinar las mensualiddes por clase, lab, semestre, matrícula, entre otros
                                switch (carrera)
                                {
                                    //se asignan los valores de precio por clases, por labs, por matrícula, por semestre y por mensualidad
                                    case "Ingeniería Mecánica":
                                        xclase = cursos * 1500;
                                        xlab = labs * 900;
                                        xmatricula = 2500;
                                        xsemestre = xclase + xlab + xmatricula;
                                        xmes = xsemestre / 4;

                                        break;
                                    case "Ingeniería Industrial":
                                        xclase = cursos * 1500;
                                        xlab = labs * 700;
                                        xmatricula = 3000;
                                        xsemestre = xclase + xlab + xmatricula;
                                        xmes = xsemestre / 4;

                                        break;
                                    case "Ingeniería en Alimentos":
                                        xclase = cursos * 1800;
                                        xlab = labs * 500;
                                        xmatricula = 3000;
                                        xsemestre = xclase + xlab + xmatricula;
                                        xmes = xsemestre / 4;

                                        break;
                                    case "Ingeniería Electrónica":
                                        xclase = cursos * 1700;
                                        xlab = labs * 600;
                                        xmatricula = 2000;
                                        xsemestre = xclase + xlab + xmatricula;
                                        xmes = xsemestre / 4;

                                        break;
                                    default: 
                                        Console.WriteLine("Datos ingresados no válidos");
                                        break;
                                }
                                //impresión de los valores previamente calculados
                                Console.WriteLine("Monto a pagar por cursos: Q" + Convert.ToString(xclase));
                                Console.WriteLine("Monto a pagar por laboratorios: Q" + Convert.ToString(xlab));
                                Console.WriteLine("Monto a pagar por matrícula: Q" + Convert.ToString(xmatricula));
                                Console.WriteLine("Monto a pagar por ciclo: Q" + Convert.ToString(xsemestre));
                                Console.WriteLine("Monto a pagar por mensualidad: Q" + Convert.ToString(xmes));
                                //validación de la jornada en la que está el alummno y su horario
                                if (jornada == "AM" || jornada == "am")
                                {
                                    Console.WriteLine("Horario de clases: 8:00 am a 13:00 pm");
                                }
                                if (jornada == "PM" || jornada == "pm")
                                {
                                    Console.WriteLine("Horario de clases: 5:30 pm a 9:00 pm ");
                                }
                                //se le pregunta al usuario qué desea hacer con los datos
                                Console.WriteLine("\n DESEA: \n 1. EXPORTAR DATOS EN ARCHIVO .TXT \n 2. MENÚ \n 3. SALIR");
                                op = Convert.ToInt32(Console.ReadLine());//se lee la variable
                                if (op == 1) //si el usuario desea exportar los datos en archivo .txt
                                {
                                    string datos = "Nombre: " + nombreest + " " + apellidoest + "\nDepartamento: " + Departamento(cuiest) + "\nCarné: " + usuarioest.Substring(3, 7)
                                        + "\nAño: " + Anio(usuarioest) + "\nCarrera: " + Carrera(usuarioest) + "\nMonto a pagar por cursos: Q" + Convert.ToString(xclase) +
                                        "\nMonto a pagar por laboratorios: Q" + Convert.ToString(xlab) + "\nMonto a pagar por matrícula: Q" + Convert.ToString(xmatricula) +
                                        "\nMonto a pagar por ciclo: Q" + Convert.ToString(xsemestre) + "\nMonto a pagar por mensualidad: Q" + Convert.ToString(xmes); //se crea un string con
                                    //todos los datos que se exportarán en el archivo .txt
                                    System.IO.File.WriteAllText(@"C:\Users\luis\Desktop\PRIMER CICLO 2020\EDI\PrimerProyectoIP\ESTUDIANTE.txt", datos); //se escribe el archivo en la ruta especificada
                                    Console.WriteLine("Datos Exportados Correctamente");
                                    Console.WriteLine("\n DESEA: \n 1. SALIR \n 2. MENÚ"); //se le vuelve a dar la opción de ir al menú o salir
                                    op = Convert.ToInt32(Console.ReadLine());
                                }
                                if (op == 3)
                                {
                                    Environment.Exit(0); //si el usuario desea salir del programa
                                }
                            } 
                            break;
                        case 2:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            double secciones; //variables double
                            double num = 0, laboclase = 0;
                            string jornadaadm, usuarioadmin, contraadmin; //variables string
                            int largoadm = 0; //variable entera
                            do //se repetirá el bloque de ingreso de usuario y contrasena hasta que no cumpla todas las condiciones
                            {
                                Console.WriteLine("Ingrese su usuario");
                                usuarioadmin = Console.ReadLine();
                                Console.WriteLine("Ingrese su contraseña");
                                contraadmin = Console.ReadLine();
                                largoadm = usuarioadmin.Length;
                            } while (usuarioadmin.Substring(0, 3) != "ADM" || contraadmin != "54321" || largoadm != 8);

                            if (usuarioadmin.Substring(0, 3) == "ADM" && contraadmin == "54321" && largoadm == 8)//si cumple con todas las condiciones, tanto el usuario como el password, entra al ingreso de datos
                            {
                                Console.WriteLine("Ingrese la cantidad de alumnos");
                                num = Convert.ToDouble(Console.ReadLine());
                                do  //si el usuario no pone 1 o 2, lo solicitará de nuevo
                                {
                                    Console.WriteLine("Ingrese 1 si es laboratorio y 2 si es clase teórica");
                                    laboclase = Convert.ToDouble(Console.ReadLine());
                                } while (laboclase != 1 && laboclase != 2);
                                Console.WriteLine("Ingrese la jornada (AM o PM)");
                                jornadaadm = Console.ReadLine();
                                Console.WriteLine("Presione ENTER para visualizar los datos"); //se imprimen los datos
                                Console.ReadKey();
                                Console.WriteLine("Código de Usuario: " + usuarioadmin.Substring(3, 5)); //se usa un substring para recortar cierto fragmento de un texto
                                Console.WriteLine("Secciones asignadas: " + Secciones(num, laboclase)); //se llama a la función secciones mandándole como parámetro el número de estudiantes y si es lab o clase
                                if (laboclase == 1) //se determina la cantidad de secciones y se le asigna a una variable
                                {
                                    if (num > 8)

                                    {
                                        if (num % 15 > 0.5)
                                        {
                                            secciones = Math.Ceiling(num / 15);
                                        }
                                        else
                                        {
                                            secciones = Math.Floor(num / 15);
                                        }
                                    }
                                    else
                                    {
                                        secciones = 0;
                                    }
                                }
                                else
                                {
                                    if (num > 18)
                                    {
                                        if (num % 35 > 0.5)
                                        {
                                            secciones = Math.Ceiling(num / 35);
                                        }
                                        else
                                        {
                                            secciones = Math.Floor(num / 35);
                                        }

                                    }
                                    else
                                    {
                                        secciones = 0;
                                    }
                                }
                                Console.WriteLine("Distribución de salones: " + Aulas(secciones)); //se llama a la función aulas que determina en qué edificio estará
                                //validación de la jornada en la que están los salones y su horario
                                if (jornadaadm == "AM" || jornadaadm == "am")
                                {
                                    Console.WriteLine("Horario de clases: 8:00 am a 13:00 pm");
                                }
                                if (jornadaadm == "PM" || jornadaadm == "pm")
                                {
                                    Console.WriteLine("Horario de clases: 5:30 pm a 9:00 pm ");
                                }
                                //se le pregunta al usuario qué desea hacer con los datos
                                Console.WriteLine("\n DESEA: \n 1. EXPORTAR DATOS EN ARCHIVO .TXT \n 2. INGRESAR NUEVO USUARIO \n 3. SALIR");
                                op = Convert.ToInt32(Console.ReadLine());
                                if (op == 1)
                                //si el usuario desea exportar los datos en archivo .txt 
                                {
                                    string datos = "Código de usuario " + usuarioadmin.Substring(3, 5) + "\nNúmero de Secciones: " + Secciones(num, laboclase) + "\nAsignación de Salones: " + Aulas(secciones);
                                    System.IO.File.WriteAllText(@"C:\Users\luis\Desktop\PRIMER CICLO 2020\EDI\PrimerProyectoIP\GESTOR.txt", datos); //se crea un string con
                                    //todos los datos que se exportarán en el archivo .txt y se escribe el archivo en la ruta especificada
                                    Console.WriteLine("Datos Exportados Correctamente");
                                    Console.WriteLine("\n DESEA: \n 1. SALIR \n 2. MENÚ"); //se le vuelve a dar la opción de ir al menú o salir
                                    op = Convert.ToInt32(Console.ReadLine());
                                }
                                   if (op==3)
                                {
                                    Environment.Exit(0);
                                }
                            }
                            break;
                        case 3:
                            Environment.Exit(0); //en caso de que el usuario desee salir 
                            break;
                        default:
                            Console.WriteLine("Dato no válido"); 
                            break;

                    }

                    string Departamento(string dpi)
                    {//switch de los dígitos del cui que determinan el departamento
                        switch (dpi.Substring(9, 2))
                        {
                            case "01":
                                return "Guatemala";
                            case "02":
                                return "El Progreso";
                            case "03":
                                return "Sacatepéquez";
                            case "04":
                                return "Chimaltenango";
                            case "05":
                                return "Escuintla";
                            case "06":
                                return "Santa Rosa";
                            case "07":
                                return "Sololá";
                            case "08":
                                return "Totonicapán";
                            case "09":
                                return "Quetzaltenango";
                            case "10":
                                return "Suchitepéquez";
                            case "11":
                                return "Retalhuleu";
                            case "12":
                                return "San Marcos";
                            case "13":
                                return "Huehuetenango";
                            case "14":
                                return "Quiché";
                            case "15":
                                return "Baja Verapaz";
                            case "16":
                                return "Alta Verapaz";
                            case "17":
                                return "Petén";
                            case "18":
                                return "Izabal";
                            case "19":
                                return "Zacapa";
                            case "20":
                                return "Chiquimula";
                            case "21":
                                return "Jalapa";
                            case "22":
                                return "Jutiapa";
                            default:
                                return "No válido";
                        }
                    }
                    string Anio(string carne) //función para determinar de que anio es la persona, recibiendo el carné como parámetro
                    {
                        int dig = Convert.ToInt32(carne.Substring(8, 2)); //se cortan los últimos dígitos del carné con un substring
                        if (dig > 81)
                        {
                            return "19" + dig;
                        }
                        else if (dig <= 20 && dig >= 00)            //se realiza la lógica para determinar el anio
                        {
                            return "20" + dig;
                        }
                        else
                        {
                            return "No válido";
                        }
                    }
                    string Carrera(string carne)
                    {
                        int dig = Convert.ToInt32(carne.Substring(6, 2)); //se recortan los dígitos que indican a qué carrera pertenece el estudiante
                        if (dig == 0 && dig % 11 == 0)
                        {
                            return "Ingeniería Mecánica";
                        } //tomando en cuenta las condiciones se realizan las comparaciones
                        else if (dig % 13 == 0)
                        {
                            return "Ingeniería Industrial";
                        }
                        else if (dig % 15 == 0)
                        {
                            return "Ingeniería en Almientos"; //se retorna el resultado
                        }
                        else
                        {
                            return "Ingeniería Electrónica";
                        }
                    }
                    string Secciones(double alumnos, double tipo)
                    {
                        if (tipo == 1) //si se trata de una sección de laboratorio
                        {
                            if (alumnos > 8) // si es una sección mayor a 8 

                            {
                                if (alumnos % 15 > 0.5) //si los restantes superan el 50% de la sección
                                {
                                    return "Cantidad de secciones de laboratorio: " + Math.Ceiling(alumnos / 15); //se aproxima al número mayor
                                }
                                else
                                {
                                    return "Cantidad de secciones de laboratorio: " + Math.Floor(alumnos / 15) + //se aproxima al número menor
                                        "\n El resto de alumnos no cumplen el 50% del cupo, " +
                                        Math.Ceiling((alumnos % 15) * 15) + " deben de ser asignados a otra sección";
                                }
                            }
                            else
                            {
                                return "Cantidad mínima de alumnos no alcanzada, ninguna sección asignada"; //si no es una sección mayor a 8
                            }
                        } 
                        else //si es una sección teórica
                        {
                            if (alumnos > 18)
                            {
                                if (alumnos % 35 > 0.5) //si lo que resta de las secciones supera el 50%
                                {
                                    return "Cantidad de secciones de laboratorio: " + Math.Ceiling(alumnos / 35); 
                                }
                                else
                                {
                                    return "Cantidad de secciones de laboratorio: " + Math.Floor(alumnos / 35) +
                                        "\n El resto de alumnos no cumplen el 50% del cupo, " +
                                        Math.Ceiling((alumnos % 35) * 35) + " deben de ser asignados a otra sección";
                                }

                            }
                            else
                            {
                                return "Cantidad mínima de alumnos no alcanzada, ninguna sección asignada"; //si no cumple con el mínimo para una sección
                            }
                        }
                    }
                    string Aulas(double secciones)
                    {
                        if (secciones <= 36)
                        {
                            if (secciones <= 12)
                            {
                                return "Las secciones se ubicarán en el edificio L (en el/los primer/os " + Math.Ceiling(secciones / 4) + " nivel/es)"; 
                            }
                            else if (secciones > 12 && secciones <= 24)
                            {
                                return "Las secciones se ubicarán en el edificio L y en el/los primer/os " + Math.Ceiling((secciones - 12) / 4) + " nivel/es del edificio M";
                            }
                            else
                            {
                                return "Las secciones se ubicarán en los edificios L, M y en el/los primer/os " + Math.Ceiling((secciones - 24) / 4) + " nivel/es del edificio H";
                            }
                        }
                        else
                        {
                            return "Cantidad de salones insuficientes para las secciones \nCantidad de secciones a reubicar en otros edificios: " + (secciones - 36);
                        }
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Dato ingresado no válido");
                    Console.ReadKey();
                }

            } while (op==2); //mientras el usuario desee regresar al menú, se va a hacer un bucle
        }
    }
    }
