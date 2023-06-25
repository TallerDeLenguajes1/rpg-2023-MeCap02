using System.Text.Json;
namespace funciones{
    public class personaje{
        private int velocidad; //1 a 10
        private int destreza; // 1 a 5
        private int fuerza; // 1 a 10
        private int nivel; //1 a 10
        private int armadura; //1 a 10
        private int salud; //100
        private string? tipo;
        private string? nombre;
        private string? apodo;
        private DateTime fechaNac;
        private int edad; //0 a 300

        public int Velocidad{get=>velocidad;set=>velocidad=value;}
        public int Destreza{get=>destreza;set=>destreza=value;}
        public int Fuerza{get=>fuerza;set=>fuerza=value;}
        public int Nivel{get=>nivel;set=>nivel=value;}
        public int Armadura{get=>armadura;set=>armadura=value;}
        public int Salud{get=>salud;set=>salud=value;}
        public string Tipo{get=>tipo;set=>tipo=value;}
        public string Nombre{get=>nombre;set=>nombre=value;}
        public string Apodo{get=>apodo;set=>apodo=value;}
        public DateTime Fechanac{get=>fechaNac;set=>fechaNac=value;}
        public int Edad{get=>edad;set=>edad=value;}
    }
    public class fabricaDePersonajes{
        public personaje GeneraPersonajes(){
            personaje pj =new personaje();
            Random Aleatorio=new Random();
            string[] raza={"Humano","Elfo","Enano","Ogro","Demonio"};
            string[] nombres={"Jose","Hector","Pedro","Ricardo","Mauro"};
            string[] apodos={"El Borracho","El Lider","El Loco","El Amable","El Criminal"};
            pj.Velocidad=Aleatorio.Next(1,11);
            pj.Destreza=Aleatorio.Next(1,6);
            pj.Fuerza=Aleatorio.Next(1,11);
            pj.Nivel=Aleatorio.Next(1,11);
            pj.Armadura=Aleatorio.Next(1,11);
            pj.Salud=100;
            pj.Tipo=raza[Aleatorio.Next(1,6)];
            pj.Nombre=nombres[Aleatorio.Next(1,6)];
            pj.Apodo=apodos[Aleatorio.Next(1,6)];
            pj.Fechanac=new DateTime(Aleatorio.Next(1,31),Aleatorio.Next(1,13),Aleatorio.Next(1723,2024));
            pj.Edad=definirEdad(pj.Fechanac);
            return pj;
        }
        private int definirEdad(DateTime fecha){
            return DateTime.Now.Year-fecha.Year;
        }
    }
    
    public class funcionesSecundarias{
        public void mostrarPersonajes(List<personaje>Personajes){
            int aux=1;
            foreach (personaje character in Personajes){
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
        }
    }

    public class funcionesJson{
        public void guardarPersonajes(List<personaje>Personajes,string archivo){
            string json=JsonSerializer.Serialize(Personajes);
            File.WriteAllText(archivo,json);
        }
        public int leerPersonajes(string archivo){
            int aux=1;
            List<personaje> entidades=JsonSerializer.Deserialize<List<personaje>>(archivo);
            if(entidades!=null){
                foreach (personaje entidad in entidades){
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
            }
        }
        public int Existe(){

        }
    }
}