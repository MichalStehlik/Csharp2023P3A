namespace CS04Events
{
    public delegate void ExampleEventHandler(object sender, ExampleEventArgs e);

    public class ExampleEventArgs
    {
        public ExampleEventArgs(int value, int previous)
        {
            Value = value;
            PreviousValue = previous;
        }

        public int Value { get; set; }
        public int PreviousValue { get; set; }
    }
}