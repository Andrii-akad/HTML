using Server01.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server01
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Messenger : IMessenger
    {
        Model1 context = new Model1();

        public void AddContact(AccountDTO owner, AccountDTO contact)
        {
            context.Contacts.Add(new Contacts { OwnerId = owner.Id, ContactId = contact.Id });
            context.SaveChanges();
        }
        public void DeleteContact(AccountDTO owner, AccountDTO contact)
        {
            context.Contacts.Remove(context.Contacts.Where(x => x.OwnerId == owner.Id & x.ContactId == contact.Id).FirstOrDefault());
            context.SaveChanges();
        }
        public bool IsContactAlreadyExist(AccountDTO owner, AccountDTO contact)
        {
            return context.Contacts.ToList().Contains(context.Contacts.ToList().Where(x => x.OwnerId == owner.Id & x.ContactId == contact.Id).FirstOrDefault());
        }
        public MessageDTO GetMessageById(int id)
        {
            List<Message> messages = context.Message.ToList();
            var message = messages.Where(x => x.Id == id).FirstOrDefault();
            return new MessageDTO
            {
                Id = message.Id,
                Content = message.Content,
                Data = message.Data,
                DeliverId = message.DeliverId
            };
        }
        public ContactsDTO GetContactById(int id)
        {
            List<Contacts> contacts = context.Contacts.ToList();
            var contact = contacts.Where(x => x.Id == id).FirstOrDefault();
            return new ContactsDTO
            {
                Id = contact.Id,
                ContactId = contact.ContactId,
                OwnerId = contact.OwnerId
            };
        }
        public ChatDTO[] GetAllMessagesInChats(AccountDTO account)
        {
            List<Chat> chats = new List<Chat>();
            List<ChatDTO> chatsRes = new List<ChatDTO>();
            foreach (var item in context.Chat.ToList().Where(x => x.Participants.Split(' ').Contains(account.Id.ToString())))
            {

                chatsRes.Add(new ChatDTO
                {
                    Id = item.Id,
                    MessageId = item.MessageId,
                    Participants = item.Participants,
                    Name = item.Name,
                    ImageId = item.ImageId
                });
            }
            return chatsRes.ToArray();
        }

        public ChatDTO[] GetChats(AccountDTO account)
        {
            List<Chat> chats = new List<Chat>();
            List<ChatDTO> chatsRes = new List<ChatDTO>();
            foreach (var item in context.Chat.ToList().Where(x => x.Participants.Split(' ').Contains(account.Id.ToString())))
            {
                if (chats.ToList().Exists(x => x.Name == item.Name))
                {
                    Chat current = chats.Where(x => x.Name == item.Name).FirstOrDefault();
                    if (item.MessageId > current.MessageId)
                    {
                        chats.Remove(current);
                        chats.Add(item);
                    }
                }
                else
                    chats.Add(item);
            }
            foreach (var item in chats)
            {
                chatsRes.Add(new ChatDTO
                {
                    Id = item.Id,
                    MessageId = item.MessageId,
                    Participants = item.Participants,
                    Name = item.Name,
                    ImageId = item.ImageId
                });
            }
            return chatsRes.ToArray();
        }

        public AccountDTO[] GetContacts(AccountDTO account)
        {
            List<Account> contacts = new List<Account>();
            List<AccountDTO> contactsRes = new List<AccountDTO>();
            foreach (var item in context.Contacts.ToList().Where(x => x.OwnerId == account.Id))
            {
                contacts.Add(context.Account.ToList().Where(x => x.Id == item.ContactId).FirstOrDefault());
            }
            foreach (var item in contacts)
            {
                contactsRes.Add(new AccountDTO
                {
                    Login = item.Login,
                    Password = item.Password,
                    Email = item.Email,
                    Image = item.Image,
                    Name = item.Name,
                    Id = item.Id
                });
            }
            return contactsRes.ToArray();
        }

        public AccountDTO[] GetUsersBySearch(string search)
        {
            List<Account> users = new List<Account>();
            List<AccountDTO> usersRes = new List<AccountDTO>();
            foreach (var item in context.Account.ToList().Where(x => x.Name.Contains(search)))
            {
                usersRes.Add(new AccountDTO
                {
                    Login = item.Login,
                    Password = item.Password,
                    Email = item.Email,
                    Image = item.Image,
                    Name = item.Name,
                    Id = item.Id
                });
            }
            return usersRes.ToArray();
        }

        public AccountDTO Login(string login, string password)
        {
            List<Account> accounts = context.Account.ToList();
            var account = accounts.Where(x => x.Login == login & x.Password == password).FirstOrDefault();
            if (account == null)
            {
                return null;
            }
            else
            {
                return new AccountDTO
                {
                    Login = account.Login,
                    Password = account.Password,
                    Email = account.Email,
                    Image = account.Image,
                    Name = account.Name,
                    Id = account.Id
                };
            }
        }

        public bool IsLoginUnique(string login)
        {
            return !context.Account.ToList().Contains(context.Account.ToList().Where(x => x.Login == login).FirstOrDefault());
        }

        public AccountDTO GetUserById(int id)
        {
            List<Account> accounts = context.Account.ToList();
            var account = accounts.Where(x => x.Id == id).FirstOrDefault();
            return new AccountDTO
            {
                Login = account.Login,
                Password = account.Password,
                Email = account.Email,
                Image = account.Image,
                Name = account.Name,
                Id = account.Id
            };
        }

        public void AddMessage(string message, DateTime date, int deliverId)
        {
            context.Message.Add(new Message
            {
                DeliverId = deliverId,
                Content = message,
                Data = date
            });
            try
            {
                context.SaveChanges();
            }
            catch
            {
            }
        }

        public ChatImagesDTO GetImageByContent(byte[] image)
        {
            List<ChatImages> images = context.ChatImages.ToList();
            var img = images.Where(x => x.Image == image).FirstOrDefault();
            return new ChatImagesDTO
            {
                Image = img.Image,
                Id = img.Id
            };
        }

        public MessageDTO GetMessageByContent(string content, DateTime date)
        {
            List<Message> messages = context.Message.ToList();
            var message = messages.Where(x => x.Content == content & x.Data == date).FirstOrDefault();
            return new MessageDTO
            {
                Id = message.Id,
                Content = message.Content,
                DeliverId = message.DeliverId,
                Data = message.Data
            };
        }

        public void AddImage(byte[] image)
        {
            context.ChatImages.Add(new ChatImages { Image = image });
            context.SaveChanges();
        }

        public void AddChat(string participants, MessageDTO msg, string name, ChatImagesDTO image = null)
        {
            MessageDTO message = GetMessageByContent(msg.Content, msg.Data);
            if (image == null)
            {
                context.Chat.Add(new Chat
                {
                    Participants = participants,
                    MessageId = message.Id,
                    Name = name,
                });
            }
            else
            {
                context.Chat.Add(new Chat
                {
                    Participants = participants,
                    MessageId = message.Id,
                    Name = name,
                    ImageId = image.Id
                });
            }
            context.SaveChanges();
        }

        public void Registrate(string email, string login, string password, string name, byte[] image)
        {
            context.Account.Add(new Account { Email = email, Login = login, Password = password, Name = name, Image = image });
            context.SaveChanges();
        }
    }
}
