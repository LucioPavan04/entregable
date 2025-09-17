namespace EmpresaSoftware
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>();
            List<Departamento> departamentos = new List<Departamento>();
            int opcion;

            do
            {
                Console.WriteLine("\n---=== SISTEMA EMPRESA SOFTWARE ===---");
                Console.WriteLine("1) Registrar nuevo empleado");
                Console.WriteLine("2) Actualizar salario de empleado");
                Console.WriteLine("3) Eliminar empleado");
                Console.WriteLine("4) Registrar nuevo departamento");
                Console.WriteLine("5) Estadísticas de empleados");
                Console.WriteLine("6) Salir");
                Console.Write("Seleccione una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

                if (opcion == 1) RegistrarEmpleado(empleados, departamentos);
                else if (opcion == 2) ActualizarSalario(empleados);
                else if (opcion == 3) EliminarEmpleado(empleados);
                else if (opcion == 4) RegistrarDepartamento(departamentos);
                else if (opcion == 5) Estadisticas(empleados, departamentos);

            } while (opcion != 6);
        }

        static void RegistrarEmpleado(List<Empleado> empleados, List<Departamento> departamentos)
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();
            if (empleados.Exists(e => e.Email == email))
            {
                Console.WriteLine("Ya existe un empleado con ese email.");
                return;
            }

            if (departamentos.Count == 0)
            {
                Console.WriteLine("Debe registrar al menos un departamento antes.");
                return;
            }

            Console.WriteLine("Departamentos:");
            foreach (var d in departamentos)
                Console.WriteLine($"{d.Id}) {d.Nombre}");

            Console.Write("Seleccione Id departamento: ");
            int idDepto = int.Parse(Console.ReadLine());
            if (!departamentos.Exists(d => d.Id == idDepto))
            {
                Console.WriteLine("Departamento inválido.");
                return;
            }

            Console.Write("Salario: ");
            decimal salario = decimal.Parse(Console.ReadLine());

            int nuevoId = empleados.Count > 0 ? empleados.Max(e => e.Id) + 1 : 1;
            empleados.Add(new Empleado(nuevoId, nombre, email, idDepto, salario));

            Console.WriteLine("Empleado registrado.");
        }

        static void ActualizarSalario(List<Empleado> empleados)
        {
            Console.Write("Email del empleado: ");
            string email = Console.ReadLine();
            var emp = empleados.Find(e => e.Email == email);
            if (emp == null)
            {
                Console.WriteLine("No existe empleado con ese email.");
                return;
            }

            Console.Write("Nuevo salario: ");
            emp.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Salario actualizado.");
        }

        static void EliminarEmpleado(List<Empleado> empleados)
        {
            Console.Write("Email del empleado: ");
            string email = Console.ReadLine();
            var emp = empleados.Find(e => e.Email == email);
            if (emp == null)
            {
                Console.WriteLine("No existe empleado con ese email.");
                return;
            }

            empleados.Remove(emp);
            Console.WriteLine("Empleado eliminado.");
        }

        static void RegistrarDepartamento(List<Departamento> departamentos)
        {
            Console.Write("Nombre del departamento: ");
            string nombre = Console.ReadLine();
            if (departamentos.Exists(d => d.Nombre == nombre))
            {
                Console.WriteLine("Ya existe un departamento con ese nombre.");
                return;
            }

            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            int nuevoId = departamentos.Count > 0 ? departamentos.Max(d => d.Id) + 1 : 1;
            departamentos.Add(new Departamento(nuevoId, nombre, descripcion));

            Console.WriteLine("Departamento registrado.");
        }

        static void Estadisticas(List<Empleado> empleados, List<Departamento> departamentos)
        {
            Console.WriteLine("\n---=== Estadísticas ===---");
            Console.WriteLine($"Total empleados: {empleados.Count}");

            if (empleados.Count > 0)
            {
                decimal promedio = empleados.Average(e => e.Salario);
                decimal max = empleados.Max(e => e.Salario);
                decimal min = empleados.Min(e => e.Salario);

                Console.WriteLine($"Salario promedio: {promedio}");
                Console.WriteLine($"Salario máximo: {max}");
                Console.WriteLine($"Salario mínimo: {min}");

                foreach (var d in departamentos)
                {
                    int count = empleados.Count(e => e.IdDepartamento == d.Id);
                    Console.WriteLine($"{d.Nombre}: {count} empleados");
                }
            }
        }
    }
}
