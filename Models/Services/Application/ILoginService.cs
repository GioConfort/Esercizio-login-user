using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Esercizio_login_user.Models.ViewModels;

namespace Esercizio_login_user.Models.Services.Application
{
    public interface ILoginService
    {
        bool CheckUtente(string username, string password);
    }
}