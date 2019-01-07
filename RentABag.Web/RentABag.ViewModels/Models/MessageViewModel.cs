using RentABag.Models;
using RentABag.Services.Mapping;

namespace RentABag.ViewModels
{
    public class MessageViewModel : IMapTo<Message>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }
    }
}