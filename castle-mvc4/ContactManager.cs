using System;

namespace castle_mvc4
{
    public class ContactManager : IContactManager
    {
        public string GetMessage()
        {
            return "Hola Mundo";
        }
    }
}