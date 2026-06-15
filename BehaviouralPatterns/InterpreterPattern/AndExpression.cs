namespace InterpreterPattern
{
    // Non-terminal expression — true only if both sub-expressions are true
    public class AndExpression : IExpression
    {
        // Left-hand side of the AND
        private IExpression _left;

        // Right-hand side of the AND
        private IExpression _right;

        // Constructor to set the two sub-expressions
        public AndExpression(IExpression left, IExpression right)
        {
            _left  = left;
            _right = right;
        }

        // Evaluate both sides and return their logical AND
        public bool Interpret(Context context)
        {
            return _left.Interpret(context) && _right.Interpret(context);
        }
    }
}
