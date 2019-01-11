using AutoMapper;
using RentABag.Models;
using RentABag.Services.Common;
using RentABag.Services.Mapping;
using RentABag.ViewModels;
using RentABag.Web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly RentABagDbContext context;

        public MessagesService(RentABagDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateMessageAsync(CreateMessageViewModel vm)
        {
            var message = Mapper.Map<CreateMessageViewModel, Message>(vm);

            await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();

            int messageId = message.Id;

            return messageId;
        }

        public async void DeleteMessageAsync(Message message)
        {
            context.Remove(message);
            await context.SaveChangesAsync();
        }

        public IQueryable<MessageViewModel> GetAllMessages()
        {
            var messages = context.Messages
                .To<MessageViewModel>();

            return messages;
        }

        public Message GetMessageById(int id)
        {
            var message = context.Messages.FirstOrDefault(d => d.Id == id);

            return message;
        }
    }
}
