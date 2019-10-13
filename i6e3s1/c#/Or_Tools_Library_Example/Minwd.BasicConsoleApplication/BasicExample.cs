using System;
using Google.OrTools.LinearSolver;


namespace Minwd.BasicConsoleApplication
{
    public class BasicExample
    {
        /// <summary>
        /// This function is solving example of the basic linear optimalization task.
        /// We are using Or-Tools Library to find the answer.
        /// Example: 
        /// Maximize -> 4x1 + 2x2
        /// While: 
        /// 1 <= x1 <= 3
        /// 0 <= x2 <= 6
        /// 2x1 + x2 <= 5
        /// While all factors are greater or equal zero.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var solver = Solver.CreateSolver("BasicExample", "GLOP_LINEAR_PROGRAMMING");
            
            //Solver creates variables x1 and x2, and sets first two constraints 1 <= x1 <= 3 and 0 <= x2 <=6
            var x1 = solver.MakeNumVar(1.0, 3.0, "x1");
            var x2 = solver.MakeNumVar(0.0, 6.0, "x2");

            // Then we create linear constraint 2x1 + x2 <=5
            var linearConstraint = solver.MakeConstraint(0.0, 5.0, "linearConstraint");
            linearConstraint.SetCoefficient(x1, 2);
            linearConstraint.SetCoefficient(x2, 1);

            // And then we precise the objective for input.
            var objective = solver.Objective();
            objective.SetCoefficient(x1, 4);
            objective.SetCoefficient(x2, 2);
            objective.SetMaximization();

            solver.Solve();

            Console.WriteLine("*****ROZWIAZANIE*****");
            Console.WriteLine("x1 = " + x1.SolutionValue());
            Console.WriteLine("x2 = " + x2.SolutionValue());
            Console.WriteLine("Zmaksymalizowana wartosc funkcji celu: " + solver.Objective().Value());

            Console.ReadKey();
        }
    }
}
