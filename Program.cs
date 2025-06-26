// Estructura de la dirección de un paciente
public struct Direccion
{
    public string Calle;
    public string Ciudad;
    public string Provincia;

    public Direccion(string calle, string ciudad, string provincia)
    {
        Calle = calle;
        Ciudad = ciudad;
        Provincia = provincia;
    }
}

// Variables para la información básica de un paciente
public record Paciente(
    int HistorialClinico,
    string Nombres,
    string Apellidos,
    Direccion Direccion,
    string Telefono
);

// Clase para la Agenda de Turnos
public class AgendaTurnos
{
    private Paciente[] pacientes;
    private string[,] turnos;
    private int contador;

    public AgendaTurnos(Paciente[] datosIniciales, string[,] turnosIniciales)
    {
        pacientes = datosIniciales;
        turnos = turnosIniciales;
        contador = datosIniciales.Length;
    }

    // Muestra todos los turnos registrados
    public void MostrarTurnos()
    {
        Console.WriteLine("AGENDA DE TURNOS");
        Console.WriteLine("===================\n");

        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine($"Paciente #{i + 1}");
            Console.WriteLine($"Historial Clínico: {pacientes[i].HistorialClinico}");
            Console.WriteLine($"Nombre: {pacientes[i].Nombres} {pacientes[i].Apellidos}");

            // Se muestra la dirección directamente
            Console.WriteLine("Dirección: " +
                pacientes[i].Direccion.Calle + ", " +
                pacientes[i].Direccion.Ciudad + ", " +
                pacientes[i].Direccion.Provincia);

            Console.WriteLine($"Teléfono: {pacientes[i].Telefono}");
            Console.WriteLine($"Fecha: {turnos[i, 0]}, Hora: {turnos[i, 1]}");
            Console.WriteLine("-----------------------------");
        }
    }
}

class Programa
{
    static void Main()
    {
        // Datos de Pacientes
        var datosPaciente = new Paciente[]
        {
            new Paciente(1001, "Yelena", "Alvarado", new Direccion("Av. El Triunfo","Puyo","Pastaza"), "0981112233"),
            new Paciente(1002, "Gustavo", "Rodríguez", new Direccion("Calle Juan Montalvo","Tena","Napo"), "0982223344"),
            new Paciente(1003, "María", "Yumbo", new Direccion("Calle Bolívar","Macas","Morona"), "0983334455")
        };

        var turnos = new string[,]
        {
            { "2025-06-20", "09:00" },
            { "2025-06-20", "10:00" },
            { "2025-06-20", "11:00" }
        };

        var agenda = new AgendaTurnos(datosPaciente, turnos);
        agenda.MostrarTurnos();
    }
}
