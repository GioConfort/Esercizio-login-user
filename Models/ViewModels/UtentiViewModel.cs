using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Esercizio_login_user.Models.ViewModels
{
    public class UtentiViewModel
    {
        public int IdUtente {get; set;}
        public string Nome {get; set;}
        public string Email {get; set;}
        public string Username {get; set;}

        public static UtentiViewModel FromDataRow(DataRow utentiRow)
        {
            var utentiViewModel = new UtentiViewModel
            {
                IdUtente = Convert.ToInt32(utentiRow["IdUtente"]),
                Nome = Convert.ToString(utentiRow["Nome"]),
                Email = Convert.ToString(utentiRow["Email"]),
                Username = Convert.ToString(utentiRow["Username"])
            };

            return utentiViewModel;
        }
    }
}