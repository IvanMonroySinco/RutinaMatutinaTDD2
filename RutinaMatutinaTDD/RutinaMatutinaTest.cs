using AwesomeAssertions;

namespace RutinaMatutinaTDD;

public class RutinaMatutinaTest
{
    [Fact]
    public void Dada_HoraActual6_00_Cuando_ConsultoQueDeboEstarHaciendoAhora_Debe_Retornar_HacerEjercicio()
    {
        var rutinaMatutina = new RutinaMatutina();
        rutinaMatutina.HoraActual = new TimeSpan(6, 0, 0);

        var actividad = rutinaMatutina.QueDeboEstarHaciendoAhora();

        actividad.Should().Be("Hacer ejercicio");
    }
    
    [Fact]
    public void Dada_HoraActual7_00_Cuando_ConsultoQueDeboEstarHaciendoAhora_Debe_Retornar_LeerYEstudiar()
    {
        var rutinaMatutina = new RutinaMatutina();
        rutinaMatutina.HoraActual = new TimeSpan(7, 0, 0);

        var actividad = rutinaMatutina.QueDeboEstarHaciendoAhora();

        actividad.Should().Be("Estudiar y leer");
    }
}

public class RutinaMatutina
{
    public TimeSpan HoraActual { get; set; }

    public string QueDeboEstarHaciendoAhora()
    {
        if (HoraActual.Hours == 7)
            return "Estudiar y leer";   
        
        return "Hacer ejercicio";
    }
}
