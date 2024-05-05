namespace LinkedSpace.Model.Color
{
    public class StepResult<TColor>
    {
        public uint Number { get; set; }
        public TColor[] Colors { get; }

        public StepResult(uint number, TColor[] colors)
        {
            Number = number;
            Colors = colors;
        }
    }
}