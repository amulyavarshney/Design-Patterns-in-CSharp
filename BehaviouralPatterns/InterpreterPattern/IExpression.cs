namespace InterpreterPattern
{
    // Interface that all expression nodes must implement
    public interface IExpression
    {
        // Evaluate the expression given the current context
        bool Interpret(Context context);
    }
}
