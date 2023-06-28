using funciones;

namespace secundarias{
    public class funcionesSecundarias{
        public void mostrarPersonajes(int idSaved,personaje character){
            if(idSaved==character.IDPj){
                Console.WriteLine($"\n===Personaje {(character.IDPj).ToString()}===");
                Console.WriteLine("ID del personaje: "+character.IDPj);
                Console.WriteLine("Nombre del Personaje: "+character.Nombre);
                Console.WriteLine("Apodo del Personaje: "+character.Apodo);
                Console.WriteLine("Raza del Personaje: "+character.Tipo);
                Console.WriteLine("Edad del Personaje: "+character.Edad);
                Console.WriteLine("Fecha de Nacimiento del Personaje: "+character.Fechanac);
                Console.WriteLine("Nivel del Personaje: "+character.Nivel);
                Console.WriteLine("Armadura del Personaje: "+character.Armadura);
                Console.WriteLine("Salud del Personaje: "+character.Salud);
                Console.WriteLine("Velocidad del Personaje: "+character.Velocidad);
                Console.WriteLine("Destreza del Personaje: "+character.Destreza);
                Console.WriteLine("Fuerza del Personaje: "+character.Fuerza);
            }
        }

        public int calcularDanio(int Des,int Fue,int Lvl,int Armd,int Vel,int Sal){
            const int ajuste=500;
            int Danio=Des*Fue*Lvl; //del atacantee
            Random Aleatorio=new Random();
            int Efec=Aleatorio.Next(1,101);
            int Def=Armd*Vel; //del defensor
            int danioProvocado=((Danio*Efec)-Def)/ajuste;
            Console.WriteLine($"-Se provoca {danioProvocado.ToString()} puntos de danio");
            Sal=Sal-danioProvocado; //Salud del defensor
            return Sal;
        }

        public bool checkID(int[] idSaver,int id){
            for (int i = 0; i < 10; i++){
                if(idSaver[i]==id){
                    return false;
                }
            }
            return true;
        }

        public int mostrar(int[,] estadisticas,int aux8){
            Console.WriteLine($"-Empieza el personaje 1");
            estadisticas[aux8,5]=calcularDanio(estadisticas[aux8,0],estadisticas[aux8,1],estadisticas[aux8,2],estadisticas[aux8,3],estadisticas[aux8,4],estadisticas[aux8,5]);
            Console.WriteLine($"-Le quedan {estadisticas[aux8,5].ToString()} puntos de salud al Personaje 2\n");
            return estadisticas[aux8,5];
        }
    }
}