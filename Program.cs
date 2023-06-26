using funciones;
using jsonFunc;
using secundarias;

int n=10;

personaje pj;
personaje pjElegido;
fabricaDePersonajes generar=new fabricaDePersonajes();
funcionesJson Jason=new funcionesJson();
funcionesSecundarias Secun=new funcionesSecundarias();

var Personajes=new List<personaje>();
var PersonajesElegidos=new List<personaje>();

/*Secun.mostrarPersonajes(Personajes);
Jason.guardarPersonajes(Personajes,"personajes.json"); Funciones para recordar
Jason.leerPersonajes("personajes.json");*/

if(Jason.Existe("personajes.json")){
    Console.WriteLine("\nEl archivo existe y tiene texto dentro del mismo");
    //Jason.leerPersonajes("personajes.json"); 
}else{
    Console.WriteLine("\nEl archivo no existe o no tiene texto dentro del mismo");
    File.Create("personajes.json");
    for (int i = 0; i < n; i++){
        pj=generar.GeneraPersonajes();
        Personajes.Add(pj);
    }
    Jason.guardarPersonajes(Personajes,"personajes.json");
}

for (int newAux = 0; newAux < 2; newAux++){
    pjElegido=Jason.elegirPersonajes("personajes.json");
    PersonajesElegidos.Add(pjElegido);
}
//Jason.guardarPersonajes(PersonajesElegidos,"personajesElegidos.json");

//Mostrar con JSON
//Console.WriteLine("\nPersonajes elegidos: ");
//Jason.leerPersonajes("personajesElegidos.json");


//Mostrar desde memoria
Console.WriteLine("\nPersonajes elegidos: ");
Secun.mostrarPersonajes(PersonajesElegidos);

//Salud,Armadura,Nivel,Fuerza,Destreza,Velocidad
int[] destreza=new int[2]; //manda del atacante
int[] fuerza=new int[2]; //manda del atacante
int[] nivel=new int[2]; //manda del atacante
int[] armadura=new int[2]; //manda del defensor
int[] velocidad=new int[2]; //manda del defensor
int[] vida=new int[2]; //manda del defensor

int aux3=0;
int aux4=1;
int aux5;
Random dado=new Random();

foreach (personaje pjDefinido in PersonajesElegidos){
    if(aux3<=1){
        vida[aux3]=pjDefinido.Salud;
        armadura[aux3]=pjDefinido.Armadura;
        fuerza[aux3]=pjDefinido.Fuerza;
        destreza[aux3]=pjDefinido.Destreza;
        nivel[aux3]=pjDefinido.Nivel;
        velocidad[aux3]=pjDefinido.Velocidad;
        aux3++;
    }else{
        break;
    }
}

Console.WriteLine("\n=====COMIENZO DEL JUEGO=====\n");
aux5=dado.Next(1,3);

do{
    Console.WriteLine($"===Turno {aux4.ToString()}===");
    //Console.WriteLine("\n-Empieza el personaje...");
    if(aux5==1){
        Console.WriteLine("-Empieza el personaje 1");
        vida[1]=Secun.calcularDanio(destreza[0],fuerza[0],nivel[0],armadura[1],velocidad[1],vida[1]);
        Console.WriteLine($"-Le quedan {vida[0].ToString()} puntos de salud al Personaje 2\n");
        aux5=0;
    }else{
        Console.WriteLine("-Empieza el personaje 2");
        vida[0]=Secun.calcularDanio(destreza[1],fuerza[1],nivel[1],armadura[0],velocidad[0],vida[0]);
        Console.WriteLine($"-Le quedan {vida[0].ToString()} puntos de salud al Personaje 1\n");
        aux5=1;
    }
    aux4++;
    if(vida[0]<=0){
        Console.WriteLine("\n-Personaje 1 se ha quedado sin salud, gana el Personaje 2");
        Console.WriteLine("-Recompensa por haber ganado: +10 Salud, +5 Defensa\n");
        vida[1]=vida[1]+10;
        armadura[1]=armadura[1]+5;
        break;
    }
    if(vida[1]<=0){
        Console.WriteLine("\n-Personaje 2 se ha quedado sin salud, gana el Personaje 1");
        Console.WriteLine("-Recompensa por haber ganado: +10 Salud, +5 Defensa\n");
        vida[0]=vida[0]+10;
        armadura[0]=armadura[0]+5;
        break;
    }
} while(vida[0]>=0 || vida[1]>=0);