using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTest.Models;

namespace FinalTest.Services
{
    public class SQLitePhoneContactService
    {
        private PhoneContactModel phoneContactModel;

        public SQLitePhoneContactService()
        {
            phoneContactModel = new PhoneContactModel();
        }

        public bool Create(PhoneContact phoneContact)
        {
           return phoneContactModel.Save(phoneContact);
        }

        public PhoneContact Search(string name)
        {
            return phoneContactModel.GetDetail(name);
        }

        public ObservableCollection<PhoneContact> ListContacts()
        {
            return phoneContactModel.GetList();
        }

        public bool Delete(int id)
        {
            return phoneContactModel.Delete(id);
        }

        public PhoneContact Update(PhoneContact newContact)
        {
            return phoneContactModel.Update(newContact);
        }
    }
}
