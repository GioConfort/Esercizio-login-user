using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Esercizio_login_user.Models.ViewModels;

namespace Esercizio_login_user.Models.Services.Application
{
    public interface IHomeService
    {
        List<UtentiViewModel> GetUtenti();
        void AddUtente(string username, string nome, string email);
        void RemoveUtente(int id);
    }
}