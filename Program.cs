using funciones;
using jsonFunc;

int n=4;

personaje pj;
fabricaDePersonajes generar=new fabricaDePersonajes();
funcionesJson Jason=new funcionesJson();
funcionesSecundarias Secun=new funcionesSecundarias();

var Personajes=new List<personaje>();

for (int i = 0; i < n; i++){
    pj=generar.GeneraPersonajes();
    Personajes.Add(pj);
}

Secun.mostrarPersonajes(Personajes);
Jason.guardarPersonajes(Personajes,"personajes.json");
Jason.leerPersonajes("personajes.json");
