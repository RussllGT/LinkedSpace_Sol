namespace LinkedSpace.Model.Create
{
    public abstract class SpaceCreator
    {
        private readonly string _description;
        public string Description => _description;
        public CreationArgs Args { get; set; }

        public SpaceCreator(string description) { _description = description; }
    }
}