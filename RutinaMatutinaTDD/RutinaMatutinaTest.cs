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

    [Fact]
    public void Dada_HoraActual7_30_Cuando_AgregoActividadEstudiarDe7_30A7_59YConsultoQueDeboEstarHaciendoAhora_Debe_RetornarEstudiar()
    {
        var rutinaMatutina = new RutinaMatutina();
        rutinaMatutina.HoraActual = new TimeSpan(7, 30, 0);
        rutinaMatutina.AgregarActividad("Estudiar", new TimeSpan(7, 30, 0), new TimeSpan(7, 59, 0));
        
        var actividad = rutinaMatutina.QueDeboEstarHaciendoAhora();

        actividad.Should().Be("Estudiar");
    }
    
    [Theory]
    [InlineData("06:00:00", "06:00:00", "06:59:00", "Hacer ejercicio")]
    [InlineData("07:00:00", "07:00:00", "07:29:00", "Leer")]
    [InlineData("07:30:59", "07:30:00", "07:59:00", "Estudiar")]
    [InlineData("06:00:00", "06:00:00", "06:44:00", "Desayunar")]
    [InlineData("06:45:00", "06:45:00", "06:59:00", "Ducharse")]
    [InlineData("07:30:00", "07:59:00", "07:29:00", "Estudiar")]
    [InlineData("08:00:00", "08:00:00", "09:00:00", "Desayunar")]
    public void Dada_CualquierHoraActual_CuandoAgregoUnaActividadALaHoraActualYConsultoQueDeboHacerAhora_Debe_RetornarLaActividad(
        string horaActualStr, 
        string horaInicialStr, 
        string horaFinalStr, 
        string nombreActividad)
    {
        // Convertir strings a TimeSpan
        var horaActual = TimeSpan.Parse(horaActualStr);
        var horaInicial = TimeSpan.Parse(horaInicialStr);
        var horaFinal = TimeSpan.Parse(horaFinalStr);

        var rutinaMatutina = new RutinaMatutina();
        rutinaMatutina.HoraActual = new TimeSpan(horaActual.Hours, horaActual.Minutes, horaActual.Seconds);
        rutinaMatutina.AgregarActividad(nombreActividad, horaInicial, horaFinal);
        
        var actividad = rutinaMatutina.QueDeboEstarHaciendoAhora();

        actividad.Should().Be(nombreActividad);
    }

    [Fact]
    public void Dada_HoraActual6_00_CuandoAgrego2ActividadesDesayunarDe6_00A6_44YDucharseDe6_45A6_59YConsultoQueDeboHacerAhora_Debe_RetornarLaActividad()
    {
        var rutinaMatutina = new RutinaMatutina();
        rutinaMatutina.HoraActual = new TimeSpan(6, 44, 0);
        rutinaMatutina.AgregarActividad("Desayunar", new TimeSpan(6,00,0), new TimeSpan(6,44,0));
        rutinaMatutina.AgregarActividad("Ducharse", new TimeSpan(6,45,0), new TimeSpan(6,59,0));
        
        var actividad = rutinaMatutina.QueDeboEstarHaciendoAhora();

        actividad.Should().Be("Desayunar");
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

    public void AgregarActividad(string nombre, TimeSpan horaInicio, TimeSpan horaFinal)
    {
        _actividades.Add((nombre, horaInicio, horaFinal));
        
    }
}
