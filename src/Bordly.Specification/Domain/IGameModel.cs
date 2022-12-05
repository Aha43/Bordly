namespace Bordly.Specification.Domain
{
    public interface IGameModel
    {
        public string Id { get; }
        public string UserEmailAddress { get; }
        public string Name { get; }
        public int Attempts { get; }
    }

}
