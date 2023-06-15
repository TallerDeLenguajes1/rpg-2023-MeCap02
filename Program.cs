using funciones;
using System.Text.Json;

Random rnd=new Random();
int n=rnd.Next(5,11);

personaje pj;
fabricaDePersonajes generar=new fabricaDePersonajes();

var Personajes=new List<personaje>();

for (int i = 0; i < n; i++){
    pj=generar.GeneraPersonajes();
    Personajes.Add(pj);
    string json=JsonSerializer.Serialize(pj);
    File.WriteAllText("personajes.json",json);
}