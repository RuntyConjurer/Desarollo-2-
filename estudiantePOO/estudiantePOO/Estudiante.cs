using System;

namespace estudiantePOO
{
    public class Estudiante
    {
        public int ID { get; set; }
        public double[] calificaciones = new double[5];
        private int totalCalificaciones = 0;

        public void introducirId(int id)
        {
            ID = id;
        }

        public bool introducirCalificaciones(double nota)
        {
            if (totalCalificaciones < 5)
            {
                calificaciones[totalCalificaciones] = nota;
                totalCalificaciones++;
                return true; 
            }
            return false; 
        }

        public double calcularPromedio()
        {
            if (totalCalificaciones == 0) return 0; 

            double suma = 0;
            for (int i = 0; i < totalCalificaciones; i++)
            {
                suma += calificaciones[i];
            }

            return suma / totalCalificaciones;
        }

        public int cantidadCalificaciones()
        {
            return totalCalificaciones;
        }
    }
}