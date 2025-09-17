namespace EmpresaSoftware
{
    class Departamento
    {
        public int Id { get; }
        public string Nombre { get; }
        public string Descripcion { get; }

        public Departamento(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
