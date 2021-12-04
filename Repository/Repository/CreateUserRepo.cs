using System;
using BackyardDndApi.Model;
using Repository.Interface;

namespace Repository
{
    public class CreateUser : ICreateUserInterface
    {
        public string Test(User user)
        {
            string Output = "Toets!";
            return Output;
        }

        
    }
}