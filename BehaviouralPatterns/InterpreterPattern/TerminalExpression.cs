namespace InterpreterPattern
{
    // Terminal expression — looks up a single variable in the context
    public class TerminalExpression : IExpression
    {
        // The variable name this expression refers to
        private string _variable;

        // Constructor to set the variable name
        public TerminalExpression(string variable)
        {
            _variable = variable;
        }

        // Return the value of the variable from the context
        public bool Interpret(Context context)
        {
            return context.Get(_variable);
        }
    }
}
