using RentABag.Models;
using RentABag.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentABag.Web.Services.Contracts
{
    public interface IMessagesService
    {
        Task<int> CreateMessageAsync(CreateMessageViewModel vm);
        Message GetMessageById(int id);
        void DeleteMessageAsync(Message message);
        IQueryable<MessageViewModel> GetAllMessages();
    }
}
