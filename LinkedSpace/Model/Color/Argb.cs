namespace LinkedSpace.Model.Color
{
    public readonly struct Argb
    {
        public static readonly Argb TRANSPARENT = new Argb(0, 0, 0, 0);
        public static readonly Argb WHITE = new Argb(255,255, 255);
        public static readonly Argb BLACK = new Argb(0, 0,0);

        public static readonly Argb RED = new Argb(255, 0, 0);
        public static readonly Argb GREEN = new Argb(0, 255, 255);
        public static readonly Argb BLUE = new Argb(0, 0,255);

        public readonly byte Red;
        public readonly byte Green;
        public readonly byte Blue;
        public readonly byte Alpha;

        public Argb(byte red, byte green, byte blue, byte alpha = 255)
        { 
            Red = red; 
            Green = green; 
            Blue = blue;
            Alpha = alpha;
        }
    }
}