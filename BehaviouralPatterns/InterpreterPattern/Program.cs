namespace InterpreterPattern
{
    // Program class to demonstrate the Interpreter pattern
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set up the context with variable values
            var context = new Context();
            context.Set("A", true);
            context.Set("B", false);
            context.Set("C", true);

            // Build expression tree: (A AND B) OR C
            IExpression expression = new OrExpression(
                new AndExpression(
                    new TerminalExpression("A"),
                    new TerminalExpression("B")
                ),
                new TerminalExpression("C")
            );

            // Evaluate — (true AND false) OR true = false OR true = true
            bool result = expression.Interpret(context);
            Console.WriteLine($"(A AND B) OR C = {result}"); // True

            // Change B to true and re-evaluate — (true AND true) OR true = true
            context.Set("B", true);
            result = expression.Interpret(context);
            Console.WriteLine($"(A AND B) OR C with B=true = {result}"); // True

            // Build a stricter expression: A AND B AND C
            IExpression strict = new AndExpression(
                new AndExpression(
                    new TerminalExpression("A"),
                    new TerminalExpression("B")
                ),
                new TerminalExpression("C")
            );

            result = strict.Interpret(context);
            Console.WriteLine($"A AND B AND C = {result}"); // True

            // Set C to false — A AND B AND C = false
            context.Set("C", false);
            result = strict.Interpret(context);
            Console.WriteLine($"A AND B AND C with C=false = {result}"); // False
        }
    }
}
