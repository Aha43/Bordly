namespace Bordly.Business.ViewModel
{
    public class PlayerViewModel
    {
        public required string Email { get; init; }
        public required string Name { get; init; }
        public override string ToString() => $"{Name} ({Email})";
        public string AvatarString => "" + Name[0];
    }
}
