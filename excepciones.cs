namespace Excepciones {
    public class Excepciones {
        public void TomarException(Exception e) {
            Console.WriteLine("ERROR: " + e.Message);
            System.Environment.Exit(1);
        }
    }
}