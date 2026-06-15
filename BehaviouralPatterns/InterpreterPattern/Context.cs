namespace InterpreterPattern
{
    // Holds the values of variables used in expressions
    public class Context
    {
        // Maps variable names to their boolean values
        private Dictionary<string, bool> _variables = new Dictionary<string, bool>();

        // Assign a boolean value to a variable name
        public void Set(string variable, bool value)
        {
            _variables[variable] = value;
        }

        // Look up the value of a variable by name
        public bool Get(string variable)
        {
            return _variables[variable];
        }
    }
}
