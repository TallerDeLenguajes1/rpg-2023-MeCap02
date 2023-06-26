using funciones;
using jsonFunc;

int n=10;

personaje pj;
fabricaDePersonajes generar=new fabricaDePersonajes();
funcionesJson Jason=new funcionesJson();
funcionesSecundarias Secun=new funcionesSecundarias();

var Personajes=new List<personaje>();

if(Jason.Existe("personajes.json")){
    Console.WriteLine("El archivo existe y tiene texto dentro del mismo\n");
    Jason.leerPersonajes("personajes.json");
}else{
    Console.WriteLine("\nEl archivo no existe o no tiene texto dentro del mismo");
    File.Create("personajes.json");
    for (int i = 0; i < n; i++){
        pj=generar.GeneraPersonajes();
        Personajes.Add(pj);
    }
    /*Secun.mostrarPersonajes(Personajes);
    Jason.guardarPersonajes(Personajes,"personajes.json");
    Jason.leerPersonajes("personajes.json");*/
}