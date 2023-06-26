using System.Text.Json;
using System.IO;
using funciones;

namespace jsonFunc{
    public class funcionesJson{
        public void guardarPersonajes(List<personaje>Personajes,string archivo){
            string json=JsonSerializer.Serialize(Personajes);
            File.WriteAllText(archivo,json);
        }
        public void leerPersonajes(string archivo){
            int aux=1;
            List<personaje>? entidades=JsonSerializer.Deserialize<List<personaje>>(archivo);
            if(entidades!=null){
                foreach (personaje entidad in entidades){
                    Console.WriteLine($"\n===Personaje {aux.ToString()}===");
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
                    aux++;
                }
            }
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