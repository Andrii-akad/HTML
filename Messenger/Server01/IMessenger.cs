using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server01
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IMessenger
    {
        [OperationContract]
        void Registrate(string email, string login, string password, string name, byte[] image);
        [OperationContract]
        ChatDTO[] GetAllMessagesInChats(AccountDTO account);
        [OperationContract]
        AccountDTO[] GetContacts(AccountDTO account);
        [OperationContract]
        void AddContact(AccountDTO owner, AccountDTO contact);
        [OperationContract]
        void DeleteContact(AccountDTO owner, AccountDTO contact);
        [OperationContract]
        bool IsContactAlreadyExist(AccountDTO owner, AccountDTO contact);
        [OperationContract]
        AccountDTO[] GetUsersBySearch(string search);
        [OperationContract]
        ChatDTO[] GetChats(AccountDTO account);
        [OperationContract]
        AccountDTO Login(string login, string password);
        [OperationContract]
        AccountDTO GetUserById(int id);
        [OperationContract]
        MessageDTO GetMessageById(int id);
        [OperationContract]
        ContactsDTO GetContactById(int id);
        [OperationContract]
        void AddMessage(string message, DateTime date, int deliverId);
        [OperationContract]
        ChatImagesDTO GetImageByContent(byte[] image);
        [OperationContract]
        MessageDTO GetMessageByContent(string content, DateTime date);
        [OperationContract]
        void AddImage(byte[] image);
        [OperationContract]
        void AddChat(string participants, MessageDTO message, string name, ChatImagesDTO image = null);
        [OperationContract]
        bool IsLoginUnique(string login);
    }
    [DataContract]
    public class AccountDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public byte[] Image { get; set; }
    }

    [DataContract]
    public class ContactsDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int? OwnerId { get; set; }

        [DataMember]
        public int? ContactId { get; set; }
    }
    [DataContract]
    public class ChatDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Participants { get; set; }

        [DataMember]
        public int? MessageId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int? ImageId { get; set; }
    }

    [DataContract]
    public class MessageDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int? DeliverId { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public DateTime Data { get; set; }
    }
    [DataContract]
    public class ChatImagesDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public byte[] Image { get; set; }
    }
}
