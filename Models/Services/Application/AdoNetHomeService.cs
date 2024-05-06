using System;
using System.Collections.Generic;
using System.Linq;
using Esercizio_login_user.Models.Services.Infrastructures;
using System.Data;
using Microsoft.Data.Sqlite;

using Esercizio_login_user.Models.ViewModels;

namespace Esercizio_login_user.Models.Services.Application
{
    public class AdoNetHomeService : IHomeService 
    {
        private readonly IDatabaseAccessor db;

        public AdoNetHomeService(IDatabaseAccessor db)
        {
            this.db=db;
        }
        public List<UtentiViewModel> GetUtenti()
        {
            FormattableString query = $"SELECT IdUtente, Nome, Email, Username FROM utenti";
            DataSet dataSet = db.Query(query);
            var dataTable = dataSet.Tables[0];
            var utentiList = new List<UtentiViewModel>();
            foreach (DataRow utentiRow in dataTable.Rows)
            {
                UtentiViewModel utente = UtentiViewModel.FromDataRow(utentiRow);
                utentiList.Add(utente);
            }

            return utentiList;
        }
        public void AddUtente(string username, string nome, string email, string password)
        {
            using(SqliteConnection conn = new SqliteConnection("Data Source=Data/utenti.db"))
            {
                conn.Open();
                string query = @"INSERT INTO utenti (Nome, Email, Username, Password)
                               VALUES (@Nome, @Email, @Username, @Password)";
                SqliteCommand cmd = new SqliteCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                cmd.ExecuteNonQuery();
            }
        }
        public void RemoveUtente(int id)
        {
            using(SqliteConnection conn = new SqliteConnection("Data Source=Data/utenti.db"))
            {
                conn.Open();
                string query = @"DELETE FROM utenti
                                WHERE utenti.IdUtente  == @id";
                SqliteCommand cmd = new SqliteCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

            }
        }
    }
}