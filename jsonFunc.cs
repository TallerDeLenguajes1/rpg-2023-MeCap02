using System.Text.Json;
using System.IO;
using funciones;

namespace jsonFunc{
    public class funcionesJson{
        public void guardarPersonajes(List<personaje>Personajes,string archivo){
            string json=JsonSerializer.Serialize(Personajes);
            File.WriteAllText(archivo,json);
        }
        public void leerPersonajes(int idSaved,string archivo){
            string jsonString=File.ReadAllText(archivo);
            List<personaje>? entidades=JsonSerializer.Deserialize<List<personaje>>(jsonString)!;
            if(entidades!=null){
                foreach (personaje entidad in entidades){
                    if(idSaved==entidad.IDPj){
                        Console.WriteLine($"\n===Personaje Elegido {(entidad.IDPj).ToString()}===");
                        Console.WriteLine("ID del Personaje: "+entidad.IDPj);
                        Console.WriteLine("Nombre del Personaje: "+entidad.Nombre);
                        Console.WriteLine("Apodo del Personaje: "+entidad.Apodo);
                        Console.WriteLine("Raza del Personaje: "+entidad.Tipo);
                        Console.WriteLine("Edad del Personaje: "+entidad.Edad);
                        Console.WriteLine("Fecha de Nacimiento del Personaje: "+entidad.Fechanac);
                        Console.WriteLine("Nivel del Personaje: "+entidad.Nivel);
                        Console.WriteLine("Armadura del Personaje: "+entidad.Armadura);
                        Console.WriteLine("Salud del Personaje: "+entidad.Salud);
                        Console.WriteLine("Velocidad del Personaje: "+entidad.Velocidad);
                        Console.WriteLine("Destreza del Personaje: "+entidad.Destreza);
                        Console.WriteLine("Fuerza del Personaje: "+entidad.Fuerza);
                    }
                }
            }
        }

        public personaje elegirPersonajes(string archivo){
            int aux1=0;
            string jsonString=File.ReadAllText(archivo);
            List<personaje>? entidades=JsonSerializer.Deserialize<List<personaje>>(jsonString);
            personaje pjApartado=new personaje();
            Random Aleatorio=new Random();
            foreach (personaje entidad in entidades){
                int aux2=Aleatorio.Next(0,3);
                if(aux2==2 && aux1!=1){
                    pjApartado=entidad;
                }
            }
            return pjApartado;
        }
        public bool Existe(string archivo){
            string aux;
            if(File.Exists(archivo)){
                aux=File.ReadAllText(archivo);
                if(aux==null){
                    return false;
                }else{
                    return true;
                }
            }else{
                return false;
            }
        }
    }
}