using System;

namespace RectangularSpaceDisplay
{
    [Serializable]
    public class AddIn
    {
        public string AddInId { get;set; }
        public string Name { get;set;}
        public string Assembly { get; set; }
        public string FullClassName { get; set; }
        public string Author { get; set; }
        public string Description { get;set; }
    }
}