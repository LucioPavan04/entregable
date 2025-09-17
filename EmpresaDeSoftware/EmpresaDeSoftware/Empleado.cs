namespace EmpresaSoftware
{
    class Empleado
    {
        public int Id { get; }
        public string Nombre { get; }
        public string Email { get; }
        public int IdDepartamento { get; }
        public decimal Salario { get; set; }

        public Empleado(int id, string nombre, string email, int idDepto, decimal salario)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            IdDepartamento = idDepto;
            Salario = salario;
        }
    }
}
