// Ejercicio 1: Jerarquía de clases para la escuela en C#
using System;
using System.Collections.Generic;

// Clase base
public class Persona
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}

// Clase Estudiante
public class Estudiante : Persona
{
    public int NumeroUnico { get; set; }

    public Estudiante(string nombre, int numeroUnico) : base(nombre)
    {
        NumeroUnico = numeroUnico;
    }
}

// Clase Profesor
public class Profesor : Persona
{
    public List<Curso> Cursos { get; set; }

    public Profesor(string nombre) : base(nombre)
    {
        Cursos = new List<Curso>();
    }

    public void AgregarCurso(Curso curso)
    {
        Cursos.Add(curso);
    }
}

// Clase Curso
public class Curso
{
    public string Nombre { get; set; }
    public int RecuentoClases { get; set; }
    public int RecuentoEjercicios { get; set; }

    public Curso(string nombre, int recuentoClases, int recuentoEjercicios)
    {
        Nombre = nombre;
        RecuentoClases = recuentoClases;
        RecuentoEjercicios = recuentoEjercicios;
    }
}

// Clase ClaseEstudiantes
public class ClaseEstudiantes
{
    public string Identificador { get; set; }
    public List<Estudiante> Estudiantes { get; set; }
    public List<Profesor> Profesores { get; set; }

    public ClaseEstudiantes(string identificador)
    {
        Identificador = identificador;
        Estudiantes = new List<Estudiante>();
        Profesores = new List<Profesor>();
    }

    public void AgregarEstudiante(Estudiante estudiante)
    {
        Estudiantes.Add(estudiante);
    }

    public void AgregarProfesor(Profesor profesor)
    {
        Profesores.Add(profesor);
    }
}

// Clase Escuela
public class Escuela
{
    public List<ClaseEstudiantes> Clases { get; set; }

    public Escuela()
    {
        Clases = new List<ClaseEstudiantes>();
    }

    public void AgregarClase(ClaseEstudiantes clase)
    {
        Clases.Add(clase);
    }
}

// Ejemplo de uso
public class Program
{
    public static void Main()
    {
        var escuela = new Escuela();
        var clase1 = new ClaseEstudiantes("2-2A");
        var estudiante1 = new Estudiante("PEPITO MARTE", 1);
        var profesor1 = new Profesor("JUANITA");
        var curso1 = new Curso("Matemáticas", 30, 10);

        profesor1.AgregarCurso(curso1);
        clase1.AgregarEstudiante(estudiante1);
        clase1.AgregarProfesor(profesor1);
        escuela.AgregarClase(clase1);

        Console.WriteLine("Clases en la escuela: " + string.Join(", ", escuela.Clases.ConvertAll(c => c.Identificador)));
        Console.WriteLine("Estudiantes en la clase " + clase1.Identificador + ": " + string.Join(", ", clase1.Estudiantes.ConvertAll(e => e.Nombre)));
        Console.WriteLine("Profesores en la clase " + clase1.Identificador + ": " + string.Join(", ", clase1.Profesores.ConvertAll(p => p.Nombre)));
    }
}

// Ejercicio 2: Clase Abstracta y Subclases para Formas Geométricas en C#
using System;
using System.Collections.Generic;

// Clase abstracta Shape
public abstract class Shape
{
    public double Ancho { get; set; }
    public double Alto { get; set; }

    protected Shape(double ancho, double alto)
    {
        Ancho = ancho;
        Alto = alto;
    }

    public abstract double CalcularArea();
}

// Clase Rectángulo
public class Rectangulo : Shape
{
    public Rectangulo(double ancho, double alto) : base(ancho, alto) { }

    public override double CalcularArea()
    {
        return Ancho * Alto;
    }
}

// Clase Triángulo
public class Triangulo : Shape
{
    public Triangulo(double ancho, double alto) : base(ancho, alto) { }

    public override double CalcularArea()
    {
        return (Ancho * Alto) / 2;
    }
}

// Clase Círculo
public class Circulo : Shape
{
    public Circulo(double radio) : base(radio, radio) { }

    public override double CalcularArea()
    {
        return Math.PI * Math.Pow(Ancho, 2);
    }
}

// Ejemplo de uso
public class ProgramShapes
{
    public static void Main()
    {
        var formas = new List<Shape>
        {
            new Rectangulo(10, 20),
            new Triangulo(10, 20),
            new Circulo(10)
        };

        var areas = formas.ConvertAll(f => f.CalcularArea());
        Console.WriteLine("Áreas calculadas: " + string.Join(", ", areas));
    }
}
