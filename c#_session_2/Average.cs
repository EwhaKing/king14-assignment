using System;

namespace MyCompiler {
    
    public delegate void AveragePerformedHandler(float result);

    public class Average{
        public event AveragePerformedHandler AveragePerformed;
        
        public void Avg(int a, int b){
            float result = (a+b)/2.0f;
            OnAveragePerformed(result);
        }

        protected virtual void OnAveragePerformed(float result){
            AveragePerformed?.Invoke(result);
        }
    }
    
    class Program {
        public static void Main(string[] args) {
            Average avg = new Average();
            avg.AveragePerformed+=OnAveragePerformed;
            
            avg.Avg(10,20);
        }

        public static void OnAveragePerformed(float result){
            Console.WriteLine($"result of average: {result}");
        }
    }
}
