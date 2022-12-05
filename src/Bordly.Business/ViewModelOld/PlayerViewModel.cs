namespace Bordly.Business.ViewModelOld
{
    public sealed class PlayerViewModel
    {
        public string Name { get; }
        public string Email { get; }

        public PlayerViewModel(string name, string email)
        {
            Name = name;
            Email = email;
        }

    }

}
