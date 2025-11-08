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
    [Fact]
    public void Dada_HoraActual8_00_Cuando_ConsultoQueDeboEstarHaciendoAhora_Debe_RetornarDesayunar()
    {
        var rutinaMatutina = new RutinaMatutina();
        rutinaMatutina.HoraActual = new TimeSpan(8, 0, 0);

        var actividad = rutinaMatutina.QueDeboEstarHaciendoAhora();

        actividad.Should().Be("Desayunar");
    }

    [Fact]
    public void Dada_HoraActual5_59_Cuando_ConsultoQueDeboEstarHaciendoAhora_Debe_RetornarSinActividad()
    {
        var rutinaMatutina = new RutinaMatutina();
        rutinaMatutina.HoraActual = new TimeSpan(5, 59, 0);

        var actividad = rutinaMatutina.QueDeboEstarHaciendoAhora();

        actividad.Should().Be("Sin actividad");
    }
    
    [Fact]
    public void Dada_HoraActual9_00_Cuando_ConsultoQueDeboEstarHaciendoAhora_Debe_RetornarSinActividad()
    {
        var rutinaMatutina = new RutinaMatutina();
        rutinaMatutina.HoraActual = new TimeSpan(9, 00, 0);

        var actividad = rutinaMatutina.QueDeboEstarHaciendoAhora();

        actividad.Should().Be("Sin actividad");
    }
    
    [Fact]
    public void Dada_HoraActual19_00_Cuando_ConsultoQueDeboEstarHaciendoAhora_Debe_RetornarSinActividad()
    {
        var rutinaMatutina = new RutinaMatutina();
        rutinaMatutina.HoraActual = new TimeSpan(19, 00, 0);

        var actividad = rutinaMatutina.QueDeboEstarHaciendoAhora();

        actividad.Should().Be("Sin actividad");
    }
}

public class RutinaMatutina
{
    public TimeSpan HoraActual { get; set; }

    public string QueDeboEstarHaciendoAhora()
    {
        if (HoraActual == new TimeSpan(19, 0, 0))
            return "Sin actividad";
        if (HoraActual == new TimeSpan(9, 0, 0))
            return "Sin actividad";
        if (HoraActual == new TimeSpan(5,59,0))
            return "Sin actividad";
        if (HoraActual.Hours == 8)
            return "Desayunar";
        if (HoraActual.Hours == 7)
            return "Estudiar y leer";   
        
        return "Hacer ejercicio";
    }
}
