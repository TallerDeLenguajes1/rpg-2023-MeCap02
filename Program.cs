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
        pj=generar.GeneraPersonajes(i++);
        Personajes.Add(pj);
    }
    Jason.guardarPersonajes(Personajes,"personajes.json");
}

int[] idSaver=new int[10];
int[] idSaverPC=new int[2];
int[,] estadisticas=new int[2,6]; // 1=Destreza, 2=Fuerza, 3=Nivel, 4=Armadura, 5=Velocidad, 6=Vida
int aux4=1,aux5,aux6=2,newAux2=2,aux9=2;
Random dado=new Random();

for (int i = 0; i < 8; i++){
    for (int newAux = 0; newAux < newAux2; newAux++){
        pjElegido=Jason.elegirPersonajes("personajes.json");
        while(!Secun.checkID(idSaver,pjElegido.IDPj)){
            pjElegido=Jason.elegirPersonajes("personajes.json");
        }
        PersonajesElegidos.Add(pjElegido);
        idSaver[i]=pjElegido.IDPj;
        // Poner if idSaverPC
        switch (aux9){
            case 0:
                estadisticas[1,0]=pjElegido.Destreza;
                estadisticas[1,1]=pjElegido.Fuerza;
                estadisticas[1,2]=pjElegido.Nivel;
                estadisticas[1,3]=pjElegido.Armadura;
                estadisticas[1,4]=pjElegido.Velocidad;
                estadisticas[1,5]=pjElegido.Salud;
                idSaverPC[1]=pjElegido.IDPj;
                Secun.mostrarPersonajes(idSaverPC[1],pjElegido);
                break;
            case 1:
                estadisticas[0,0]=pjElegido.Destreza;
                estadisticas[0,1]=pjElegido.Fuerza;
                estadisticas[0,2]=pjElegido.Nivel;
                estadisticas[0,3]=pjElegido.Armadura;
                estadisticas[0,4]=pjElegido.Velocidad;
                estadisticas[0,5]=pjElegido.Salud;
                idSaverPC[0]=pjElegido.IDPj;
                Secun.mostrarPersonajes(idSaverPC[0],pjElegido);
                break;
            case 2:
                estadisticas[newAux,0]=pjElegido.Destreza;
                estadisticas[newAux,1]=pjElegido.Fuerza;
                estadisticas[newAux,2]=pjElegido.Nivel;
                estadisticas[newAux,3]=pjElegido.Armadura;
                estadisticas[newAux,4]=pjElegido.Velocidad;
                estadisticas[newAux,5]=pjElegido.Salud;
                idSaverPC[newAux]=pjElegido.IDPj;
                Secun.mostrarPersonajes(idSaverPC[newAux],pjElegido);
                break;
            default:
                break;
        }
    }
    Jason.guardarPersonajes(PersonajesElegidos,"personajesElegidos.json");

    /*foreach (personaje pjDefinido in PersonajesElegidos){ Vestigios de un codigo que ya no es
        if(aux3<=1){
            
            aux3++;
        }else{
            break;
        }
    }*/

    Console.WriteLine("\n=====COMIENZO DEL JUEGO=====\n");
    aux5=dado.Next(0,2);

    do{
        Console.WriteLine($"===Turno {aux4.ToString()}===");
        if(aux5==0){
            estadisticas[aux5,5]=Secun.mostrar(estadisticas,aux5);
            aux5=1;
        }else{
            estadisticas[aux5,5]=Secun.mostrar(estadisticas,aux5);
            aux5=0;
        }
        aux4++;
        if(estadisticas[0,5]<=0){
            Console.WriteLine("\n-Personaje 1 se ha quedado sin salud, gana el Personaje 2");
            Console.WriteLine("-Recompensa por haber ganado: +10 Salud, +5 Defensa\n");
            estadisticas[1,5]=estadisticas[1,5]+10;
            estadisticas[1,3]=estadisticas[1,3]+5;
            aux9=0;
            break;
        }
        if(estadisticas[1,5]<=0){
            Console.WriteLine("\n-Personaje 2 se ha quedado sin salud, gana el Personaje 1");
            Console.WriteLine("-Recompensa por haber ganado: +10 Salud, +5 Defensa");
            estadisticas[0,5]=estadisticas[0,5]+10;
            estadisticas[0,3]=estadisticas[0,3]+5;
            aux9=1;
            break;
        }
    } while(aux6!=10);
    newAux2=1;
}

Console.WriteLine("\n===Fin del Juego===");
switch (aux9){
    case 0:
        Secun.mostrarGanador(idSaverPC[1],estadisticas,1);
        break;
    case 1:
        Secun.mostrarGanador(idSaverPC[0],estadisticas,0);
        break;
    default:
        break;
}

//Implementar mensaje de victoria, fin de juego

/*Salud,Armadura,Nivel,Fuerza,Destreza,Velocidad
    int[] destreza=new int[2]; //manda del atacante
    int[] fuerza=new int[2]; //manda del atacante
    int[] nivel=new int[2]; //manda del atacante
    int[] armadura=new int[2]; //manda del defensor
    int[] velocidad=new int[2]; //manda del defensor
    int[] vida=new int[2]; //manda del defensor*/

//Jason.guardarPersonajes(PersonajesElegidos,"personajesElegidos.json");

//Mostrar con JSON
//Console.WriteLine("\nPersonajes elegidos: ");
//Jason.leerPersonajes("personajesElegidos.json");


//Mostrar desde memoria
/*Console.WriteLine("\nPersonajes elegidos: ");
foreach (personaje item in PersonajesElegidos){
    Secun.mostrarPersonajes(item);
}*/