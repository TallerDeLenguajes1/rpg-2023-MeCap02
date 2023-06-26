using funciones;

namespace secundarias{
    public class funcionesSecundarias{
        public void mostrarPersonajes(personaje character){
            int aux=1;
                Console.WriteLine($"\n===Personaje {aux.ToString()}===");
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
                aux++;
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
    }
}