using RentABag.Models;
using RentABag.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services.Common
{
    public interface IMessagesService
    {
        Task<int> CreateMessageAsync(CreateMessageViewModel vm);
        Message GetMessageById(int id);
        void DeleteMessageAsync(Message message);
        IQueryable<MessageViewModel> GetAllMessages();
    }
}
