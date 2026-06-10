/*Almacenar 10 registros de estudiantes, su nombre, carrera y promedio*/

Estudiante[] estudiante = new Estudiante[10];
int i = 0;

int menu()
{
    Console.WriteLine("1. Agregar");
    Console.WriteLine("2. Mostrar");
    Console.WriteLine("3. Guardar");
    Console.WriteLine("4. Eliminar registro");
    Console.WriteLine("5. Salir");

    Console.WriteLine("Digita tu opcion: ");
    return int.Parse(Console.ReadLine());
}

void pedirDatos()
{
    if (i < 10)
    {
        Console.WriteLine($"Registro #{i + 1} de 10");
        Console.Write("Nombre: ");
        estudiante[i].nombre = Console.ReadLine();
        Console.Write("Carrera: ");
        estudiante[i].carrera = Console.ReadLine();
        Console.Write("Promedio: ");
        estudiante[i].promedio = double.Parse(Console.ReadLine());
        i++;
    }
    else
    {
        Console.WriteLine("No hay espacio");
    }
}


void mostrarDatos()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Nombre: {estudiante[i].nombre}");
        Console.WriteLine($"Carrera: {estudiante[i].carrera}");
        Console.WriteLine($"Promedio: {estudiante[i].promedio}");
        Console.WriteLine();
    }
}

void guardarArchivo()
{
    StreamWriter archivo = new StreamWriter("C:\\xe\\registro.csv");
    for (int i = 0; i < 10; i++)
    {
        archivo.WriteLine(estudiante[i].nombre + ";" + estudiante[i].carrera + ";" + estudiante[i].promedio);
    }
    archivo.Close();
    Console.WriteLine("Registro guardado");
}

int buscarRegistro(string nombre)
{
    return Array.FindIndex(estudiante, e => e.nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
}

void eliminarRegistro(string nombre)
{
    int pos = buscarRegistro(nombre);

    if (pos == -1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Estudiante no existe");
        Console.ResetColor();
        Console.ReadKey();
        return;
    }

    for(int i = pos; i < estudiante.Length-1; i++)
    {
        estudiante[i] = estudiante[i + 1];
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Registro eliminado");
    i--;
    Console.ResetColor();
}


void leerArchivo()
{
    StreamReader archivo = new StreamReader("C:\\xe\\registro.csv");
    String linea;
    while((linea = Console.ReadLine()) != null && i < 10)
    {
        String[] dato = linea.Split(';');
        estudiante[i].nombre = dato[0];
        estudiante[i].carrera = dato[1];
        estudiante[i].promedio = double.Parse(dato[2]);
        i++;
    }
}
void main()
{
    int op;
    do
    {
        op = menu();
        switch (op)
        {
            case 1:
                pedirDatos();
                break;
            case 2:
                mostrarDatos();
                break;
            case 3:
                guardarArchivo();
                break;
            case 4:
                Console.WriteLine("Que estudiante deseas eliminar: ");
                nombre = Console.ReadLine();
                eliminarRegistro(nombre);
                break;
            case 0:
                Console.WriteLine("Adios...");
                break;
            default:
                Console.WriteLine("Opcion invalida");
                break;

        }
    } while (op != 0);
}

main();

struct Estudiante
{
    public string nombre;
    public string carrera;
    public double promedio;
}
