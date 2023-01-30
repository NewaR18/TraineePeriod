using Functions.Data_Link_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Business_Logic_Layer
{
    public class BLL
    {
        private readonly DLL _dll;
        public BLL()
        {
            _dll = new DLL();
        }
        public string QuickMessage(string Name, string Email, string Subject, string Message)
        {
            return _dll.InsertMessage(Name, Email, Subject, Message);
        }
    }
}
