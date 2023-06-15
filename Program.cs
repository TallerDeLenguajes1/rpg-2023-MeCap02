using funciones;

Random rnd=new Random();
int n=rnd.Next(5,11);

personaje pj;
fabricaDePersonajes generar=new fabricaDePersonajes();
funcionesJson Jason=new funcionesJson();

var Personajes=new List<personaje>();

for (int i = 0; i < n; i++){
    pj=generar.GeneraPersonajes();
    Personajes.Add(pj);
}

Jason.guardarPersonajes(Personajes,"personajes.json");