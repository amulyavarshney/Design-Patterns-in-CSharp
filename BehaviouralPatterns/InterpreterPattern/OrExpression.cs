namespace InterpreterPattern
{
    // Non-terminal expression — true if at least one sub-expression is true
    public class OrExpression : IExpression
    {
        // Left-hand side of the OR
        private IExpression _left;

        // Right-hand side of the OR
        private IExpression _right;

        // Constructor to set the two sub-expressions
        public OrExpression(IExpression left, IExpression right)
        {
            _left  = left;
            _right = right;
        }

        // Evaluate both sides and return their logical OR
        public bool Interpret(Context context)
        {
            return _left.Interpret(context) || _right.Interpret(context);
        }
    }
}
