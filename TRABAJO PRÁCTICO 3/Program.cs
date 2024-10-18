using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

class TrabajoPractico3
{
    static int[][] asientos; 

    static bool vueloCreado = false;
    static bool asientoReservado = false;

    static int opcion = 0;
    static int opcionVuelo = 0;
    static int contadorAsientos = 0;
    static void Main()
    {
        Inicio();
        Menú();
    }

    static void Inicio() // Función correspondiente a la pantalla de bienvenida.
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("|¡Bienvenido a Aerolíneas Argentinas!|");
        Console.WriteLine("--------------------------------------");
        Bandera();
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ResetColor();
        Console.ReadKey();
    }

    static void Bandera()
    {
        ConsoleColor colorCeleste = ConsoleColor.Cyan;
        ConsoleColor colorBlanco = ConsoleColor.White;
        int ancho = 40;
        int alto = 9;

        for (int i = 0; i < alto; i++)
        {

            if (i < 3)
            {
                Console.BackgroundColor = colorCeleste;
            }
            else if (i >= 3 && i < 6)
            {
                Console.BackgroundColor = colorBlanco;
            }
            else
            {
                Console.BackgroundColor = colorCeleste;
            }


            Console.WriteLine(new string(' ', ancho));
        }
        Console.ResetColor();
    }

    static void Menú() //Función correspondiente al menu principal del programa.
    {
        ConsoleKeyInfo Flecha;
        Console.CursorVisible = false;


        do
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("----------");
            Console.WriteLine("|| MENÚ ||");
            Console.WriteLine("----------\n");
            Console.ResetColor();


            for (int i = 0; i <= 6; i++)
            {
                if (opcion == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(MenuNumeros(i));
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(MenuNumeros(i));
                    Console.ResetColor();
                }
            }


            Flecha = Console.ReadKey(true);
            if (Flecha.Key == ConsoleKey.UpArrow && opcion > 0)
                opcion--;
            if (Flecha.Key == ConsoleKey.DownArrow && opcion < 7)
                opcion++;


        } while (Flecha.Key != ConsoleKey.Enter);

        switch (opcion)
        {
            case 0:
                Console.Clear();
                Vuelo();
                EsperarYVolverAlMenu();
                break;
            case 1:
                Console.Clear();
                ReservarAsiento();
                EsperarYVolverAlMenu();
                break;
            case 2:
                Console.Clear();
                CancelarReserva();
                EsperarYVolverAlMenu();
                break;
            case 3:
                Console.Clear();
                MostrarEstadoVuelo();
                Thread.Sleep(1500);
                EsperarYVolverAlMenu();
                break;
            case 4:
                Console.Clear();
                CantidadAsientosDisponibles();
                EsperarYVolverAlMenu();
                break;
            case 5:
                BuscarAsientoDisponible();
                EsperarYVolverAlMenu();
                break;
            case 6:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Saliendo del sistema...");
                Thread.Sleep(1500);
                Console.ResetColor();
                break;
        }
    }

    static string MenuNumeros(int indice) // Devuelve el texto de las opciones del menú según el índice.
    {
        switch (indice)
        {
            case 0:
                return "------------------------------------------------------------------\n" +
                      " > Crear vuelo.                                                   |" +
                      "\n ------------------------------------------------------------------";
            case 1:
                return "------------------------------------------------------------------\n" +
                    " > Reservar un asiento.                                           |" +
                    "\n ------------------------------------------------------------------";
            case 2:
                return "------------------------------------------------------------------\n" +
                    " > Cancelar una reserva.                                          |" +
                    "\n ------------------------------------------------------------------";
            case 3:
                return "------------------------------------------------------------------\n" +
                    " > Mostrar tabla del estado actual del vuelo.                     |" +
                    "\n ------------------------------------------------------------------";
            case 4:
                return "------------------------------------------------------------------\n" +
                    " > Mostrar cantidad de asientos disponibles y ocupados del vuelo. |" +
                    "\n ------------------------------------------------------------------";
            case 5:
                return "------------------------------------------------------------------\n" +
                    " > Buscar un asiento en particular y mostrar si esta disponible.  |" +
                    "\n ------------------------------------------------------------------";
            case 6:
                return "------------------------------------------------------------------\n" +
                    " > Salir del sistema.                                             |" +
                    "\n ------------------------------------------------------------------";
            default:
                return "";
        }
    }

    static void EsperarYVolverAlMenu() // Espera que el usuario presione 'M' para volver al menú.
    {
        ConsoleKeyInfo volverMenu;
        bool volverValido = false;
        while (volverValido != true)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nPresiona 'M' para volver al menú.");

            volverMenu = Console.ReadKey(true);
            Console.ResetColor();

            if (volverMenu.Key == ConsoleKey.M)
            {
                volverValido = true;
            }
        }
        Menú(); // Volver al menú principal
    }

    static void Vuelo()
    {
        if (!vueloCreado)
        {
            while (opcionVuelo < 1 || opcionVuelo > 5)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("A donde desea viajar: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n1. París \n2. Nueva York \n3. Tokio \n4. Sídney \n5. Roma");
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\nIngresa el número de la opción: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    opcionVuelo = int.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Green;
                    switch (opcionVuelo)
                    {
                        case 1:
                            Console.WriteLine("\nEl vuelo a París ha sido creado. Su vuelo cuenta con 10 filas, con 6 asientos cada una.");
                            break;
                        case 2:
                            Console.WriteLine("\nEl viaje a Nueva York ha sido creado. Su vuelo cuenta con 10 filas, con 6 asientos cada una.");
                            break;
                        case 3:
                            Console.WriteLine("\nEl viaje a Tokio ha sido creado. Su vuelo cuenta con 10 filas, con 6 asientos cada una.");
                            break;
                        case 4:
                            Console.WriteLine("\nEl viaje a Sídney ha sido creado. Su vuelo cuenta con 10 filas, con 6 asientos cada una.");
                            break;
                        case 5:
                            Console.WriteLine("\nEl viaje a Roma ha sido creado. Su vuelo cuenta con 10 filas, con 6 asientos cada una.");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Clear();
                            Console.WriteLine("\nOpción no válida. Elija otra opción.");
                            Thread.Sleep(2500);

                            break;
                    }
                }
                asientos = FuncionCrearVuelo();

                vueloCreado = true;

            }
        }
        else
        {
            int opcionCrearVuelo = -1;
            while (opcionCrearVuelo != 1 && opcionCrearVuelo != 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("¿Quiere borrar el vuelo existente para poder crear otro vuelo?");
                Console.Write("\nSi es así escriba 1, si no escriba 0: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                opcionCrearVuelo = int.Parse(Console.ReadLine());
                if (opcionCrearVuelo == 1 || opcionCrearVuelo == 0)
                {
                    if (opcionCrearVuelo == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nVuelo borrado correctamente.");
                        vueloCreado = false;
                        asientoReservado = false;
                        opcionVuelo = 0;
                        contadorAsientos = 0;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida. Por favor, escriba 1 o 0.");
                    Thread.Sleep(2500);
                }
            }


        }




    }

    static int[][] FuncionCrearVuelo()
    {

        int[][] asientos = new int[10][];
        for (int i = 0; i < asientos.Length; i++)
        {
            asientos[i] = new int[6];
        }
        for (int i = 0; i < asientos.Length; i++)
        {
            for (int j = 0; j < asientos[i].Length; j++)
            {
                asientos[i][j] = 0;
            }

        }

        return asientos;
    }

    static void ReservarAsiento()
    {
        if (vueloCreado)
        {
            if (contadorAsientos < 60)
            {
                int opcionAsiento;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("¿Usted quiere reservar un asiento?");
                Console.Write("Escriba 1 si es así o 0 si no lo es: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                opcionAsiento = int.Parse(Console.ReadLine());
                if (opcionAsiento == 1)
                {
                    asientoReservado = false;
                    while (asientoReservado == false)
                    {
                        int fila = -1;
                        int asiento = -1;
                        while (fila > 9 || fila < 0)
                        {

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("Su vuelo cuenta con 10 filas, con 6 asientos cada una.");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write($"\nEscriba fila en la que desea viajar: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            fila = int.Parse(Console.ReadLine()) - 1;
                            if (fila > 9 || fila < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("\nElija una fila válida, recuerde que el avión cuenta con 10 filas de asientos.");
                                Thread.Sleep(2500);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("\nEscriba en el asiento en el que desea viajar: ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                asiento = int.Parse(Console.ReadLine()) - 1;

                                if (asiento > 5 || asiento < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Clear();
                                    Console.WriteLine("\nElija un asiento valido, recuerde que cada fila cuenta con 6 asientos.");
                                    Thread.Sleep(2500);
                                    fila = -1;

                                }
                                else
                                {
                                    if (asientos[fila][asiento] == 1)  // Si el asiento ya está reservado
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\nEl asiento elegido ya está reservado. Por favor, elija otro.");
                                        Thread.Sleep(2500);
                                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                        Console.ReadKey();  // Esperar a que el usuario presione una tecla para continuar

                                    }
                                    else
                                    {
                                        if (fila == 9)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            asientos[fila][asiento] = 1;
                                            Console.WriteLine($"\nSu asiento ha sido reservado. Su asiento es el F{fila + 1}A{asiento + 1}.");
                                            asientoReservado = true;
                                            contadorAsientos++;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            asientos[fila][asiento] = 1;
                                            Console.WriteLine($"\nSu asiento ha sido reservado. Su asiento es el F0{fila + 1}A{asiento + 1}.");
                                            asientoReservado = true;
                                            contadorAsientos++;
                                        }
                                        break;

                                    }
                                }




                            }
                        }
                    }

                }
                else
                {
                    EsperarYVolverAlMenu();
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ya no puedo seguir reservando asientos ya que su vuelo esta lleno. Si quiere reservar otro, cancele una reserva o cree otro vuelo.");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPrimero debe crear un vuelo para reservar un asiento.");
            Thread.Sleep(1500);
        }


    }

    static void CancelarReserva()
    {
        int opcionReserva;
        if (contadorAsientos > 0)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("¿Usted quiere cancelar su reserva?");
            Console.Write("Escriba 1 si es así o 0 si no lo es: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            opcionReserva = int.Parse(Console.ReadLine());
            if (opcionReserva == 1)
            {
                bool reservaCancelada = false;
                while (reservaCancelada != true)
                {
                    int fila = -1;
                    int asiento = -1;

                    while (fila > 9 || fila < 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($"\nEscriba fila del asiento reservado: ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        fila = int.Parse(Console.ReadLine()) - 1;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        if (fila > 9 || fila < 0)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nElija una fila válida, recuerde que el avión cuenta con 10 filas de asientos.");
                            Thread.Sleep(2500);
                        }
                        else
                        {
                            Console.Write("\nEscriba la columna del asiento reservado: ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            asiento = int.Parse(Console.ReadLine()) - 1;

                            if (asiento > 5 || asiento < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine("\nElija una columna válida, recuerde que cada fila cuenta con 6 asientos.");
                                Thread.Sleep(2500);
                                fila = -1;
                            }
                            else
                            {
                                if (asientos[fila][asiento] == 0)  // Si el asiento ya está reservado
                                {

                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Clear();
                                    Console.WriteLine("\nEl asiento elegido no está reservado. Por favor, intente de nuevo.");
                                    Thread.Sleep(1500);
                                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                                    Console.ReadKey();  // Esperar a que el usuario presione una tecla para continuar
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    asientos[fila][asiento] = 0;
                                    Console.WriteLine($"\nSu reserva ha sido cancelada.");
                                    contadorAsientos--;
                                    reservaCancelada = true;
                                    if (contadorAsientos == 0)
                                    {
                                        asientoReservado = false;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                EsperarYVolverAlMenu();
            }


        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPrimero debe reservar un asiento.");
            Thread.Sleep(1500);
        }
    }

    static void MostrarEstadoVuelo()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        if (vueloCreado)
        {
            Console.WriteLine("|-----------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|                                           ESTADO DEL VUELO                                          |");
            Console.WriteLine("|-----------------------------------------------------------------------------------------------------|");
            Console.WriteLine("|----ASIENTO1----|----ASIENTO2----|----ASIENTO3----|----ASIENTO4----|----ASIENTO5----|----ASIENTO6----|");
            Console.ResetColor();
            for (int i = 0; i < asientos.Length; i++)
            {

                for (int j = 0; j < asientos[i].Length; j++)
                {
                    string fila = (i + 1).ToString("D2");
                    string asiento = (j + 1).ToString();
                    if (asientos[i][j] == 1)
                    {
                        if (asiento == "1")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"F{fila}A{asiento}:RESERVADO".PadRight(16)); // Alinear
                            Console.ResetColor();

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("|");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"F{fila}A{asiento}:RESERVADO".PadRight(16)); // Alinear
                            Console.ResetColor();
                        }


                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"F{fila}A{asiento}:LIBRE".PadRight(16)); // Alinear
                        Console.ResetColor();


                    }
                }

                // Separador de final de fila
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|");
                Console.ResetColor();
            }

            // Línea final de la tabla
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("|----------------|----------------|----------------|----------------|----------------|----------------|");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPrimero debe crear un vuelo para poder acceder a la tabla.");
            Thread.Sleep(1500);
        }

    }

    static void CantidadAsientosDisponibles()
    {
        if (vueloCreado)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            switch (opcionVuelo)
            {
                case 1:
                    Console.WriteLine($"\nEn el viaje elegido a: París.");
                    break;
                case 2:
                    Console.WriteLine($"\nEn el viaje elegido a: Nueva York");
                    break;
                case 3:
                    Console.WriteLine($"\nEn el viaje elegido a: Tokio");
                    break;
                case 4:
                    Console.WriteLine($"\nEn el viaje elegido a: Sídney");
                    break;
                case 5:
                    Console.WriteLine($"\nEn el viaje elegido a: Roma");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"La cantidad de asientos libres en el vuelo son: {60 - contadorAsientos} asientos.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"La cantidad de asientos reservados en el vuelo son: {contadorAsientos} asientos.\n");

            MostrarEstadoVuelo();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPrimero debe crear un vuelo para poder acceder a cantidad de asientos reservados y disponibles.");
            Thread.Sleep(1500);
        }


    }

    static void BuscarAsientoDisponible()
    {
        int fila = -1;
        int asiento = -1;
        if (vueloCreado == true)
        {
            while (fila > 9 || fila < 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"\nEscriba la fila del asiento: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                fila = int.Parse(Console.ReadLine()) - 1;
                Console.ForegroundColor = ConsoleColor.Blue;
                if (fila > 9 || fila < 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nElija una fila válida, recuerde que el avión cuenta con 10 filas de asientos.");
                    Thread.Sleep(2500);
                }
                else
                {
                    Console.Write("\nEscriba la columna del asiento: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    asiento = int.Parse(Console.ReadLine()) - 1;

                    if (asiento > 5 || asiento < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("\nElija una columna válida, recuerde que cada fila cuenta con 6 asientos.");
                        Thread.Sleep(2500);
                        fila = -1;
                    }
                    else
                    {
                        if (asientos[fila][asiento] == 0)
                        {
                            if (fila < 9)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Clear();
                                Console.WriteLine($"\nEl asiento F0{fila + 1}A{asiento + 1} elegido esta disponible.");
                                Thread.Sleep(1500);

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Clear();
                                Console.WriteLine($"\nEl asiento F{fila + 1}A{asiento + 1} elegido esta disponible.");
                                Thread.Sleep(1500);

                            }

                        }
                        else
                        {
                            if (fila < 9)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine($"\nEl asiento F0{fila + 1}A{asiento + 1} elegido no esta disponible.");
                                Thread.Sleep(1500);

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Clear();
                                Console.WriteLine($"\nEl asiento F{fila + 1}A{asiento + 1} elegido no esta disponible.");
                                Thread.Sleep(1500);
                            }

                        }
                    }
                }
            }
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Primero crear un vuelo para saber si un asiento esta disponible o no.");
        }
    }
}
