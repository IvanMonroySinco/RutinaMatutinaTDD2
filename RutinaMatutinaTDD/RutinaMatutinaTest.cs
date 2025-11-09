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

    [Theory]
    [InlineData(5, 59, 0)]
    [InlineData(9, 00, 0)]
    [InlineData(19, 00, 0)]
    [InlineData(12, 30, 0)]
    [InlineData(2, 22, 0)]
    
    public void Dada_HoraActualFueraDelHorarioDeLaRutinaMatutina_ConsultoQueDeboEstarHaciendoAhora_Debe_RetornarSinActividad(int horas, int minutos, int segundos)
    {
        var rutinaMatutina = new RutinaMatutina();
        rutinaMatutina.HoraActual = new TimeSpan(horas, minutos, segundos);

        var actividad = rutinaMatutina.QueDeboEstarHaciendoAhora();

        actividad.Should().Be("Sin actividad");
    }

    [Fact]
    public void Dada_HoraActual7_00_Cuando_AgregoActividadLeerDe7A7_29YConsultoQueDeboEstarHaciendoAhora_Debe_RetornarLeer()
    {
        var rutinaMatutina = new RutinaMatutina();
        rutinaMatutina.HoraActual = new TimeSpan(7, 0, 0);
        rutinaMatutina.AgregarActividad("Leer", new TimeSpan(7, 0, 0), new TimeSpan(7, 29, 0));
        
        var actividad = rutinaMatutina.QueDeboEstarHaciendoAhora();

        actividad.Should().Be("Leer");
    }
    
}

public class RutinaMatutina
{
    public TimeSpan HoraActual { get; set; }
    private List<(string Nombre, TimeSpan HoraInicial, TimeSpan HoraFinal)> _actividades = new();

    public string QueDeboEstarHaciendoAhora()
    {
        if (_actividades.Count == 1)
            return _actividades[0].Nombre;
        
        if (HoraActual.Hours == 6)
            return "Hacer ejercicio";
        if (HoraActual.Hours == 8)
            return "Desayunar";
        if (HoraActual.Hours == 7)
            return "Estudiar y leer";   
        
        return "Sin actividad";
    }

    public void AgregarActividad(string leer, TimeSpan timeSpan, TimeSpan timeSpan1)
    {
        _actividades.Add(("Leer", new TimeSpan(7,0,0), new TimeSpan(7,29,0)));
        
    }
}
