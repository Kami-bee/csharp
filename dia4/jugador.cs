
//pelea de jugadores
using System;

Jugador j1 = new Jugador("Fiorelia", 50);
Jugador j2 = new Jugador("Maria", 40);

j1.RecibirAtaques(26);
j2.RecibirAtaques(15);
j1.Mostrar();
j2.Mostrar();
Console.WriteLine("15 minutos de descanso");
j1.Curar(5);
j2.Curar(15);
j1.Mostrar();
j2.Mostrar();

class Jugador {
    //atributos
    public string Nombre;
    public int Vida;

    //constructor
    public Jugador(string nombre, int vida) {
        Nombre = nombre;
        Vida = vida;
    }
    //metodos
    public void RecibirAtaques(int puntos) {
        Vida = Vida + puntos;
    }
    public void Curar(int puntos) {
        Vida += puntos;
    }
    public void Mostrar() {
        Console.WriteLine($" { Nombre} tiene { Vida} decimal Vida"); 
    }
}
