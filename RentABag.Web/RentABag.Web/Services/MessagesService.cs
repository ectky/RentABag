using AutoMapper;
using RentABag.Models;
using RentABag.Services.Mapping;
using RentABag.Web.Data;
using RentABag.Web.Services.Contracts;
using RentABag.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services
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

            await this.context.Messages.AddAsync(message);
            await this.context.SaveChangesAsync();

            int messageId = message.Id;

            return messageId;
        }

        public async void DeleteMessageAsync(Message message)
        {
            this.context.Remove(message);
            await this.context.SaveChangesAsync();
        }

        public IQueryable<MessageViewModel> GetAllMessages()
        {
            var messages = this.context.Messages
                .To<MessageViewModel>();

            return messages;
        }

        public Message GetMessageById(int id)
        {
            var message = this.context.Messages.FirstOrDefault(d => d.Id == id);

            return message;
        }
    }
}
