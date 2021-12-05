﻿using BackyardDndApi.Model;

namespace Repository.Interface
{
    public interface ICreateUserInterface
    {
        public void AddUser(User user);
        public User GetUser(string Username);
    }
}