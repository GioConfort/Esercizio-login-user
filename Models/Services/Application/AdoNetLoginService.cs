using System;
using System.Collections.Generic;
using System.Linq;
using Esercizio_login_user.Models.Services.Infrastructures;
using System.Data;
using Microsoft.Data.Sqlite;

using Esercizio_login_user.Models.ViewModels;

namespace Esercizio_login_user.Models.Services.Application
{
    public class AdoNetLoginService : ILoginService 
    {
        private readonly IDatabaseAccessor db;

        public AdoNetLoginService(IDatabaseAccessor db)
        {
            this.db=db;
        }
        public bool CheckUtente(string username, string password)
        {
            bool isTrovato = false;
            using(SqliteConnection conn = new SqliteConnection("Data Source=Data/utenti.db"))
            {
                conn.Open();
                string query = @"SELECT utenti.IdUtente 
                                            FROM utenti 
                                            WHERE utenti.Username == @username AND utenti.Password == @password";
                SqliteCommand cmd = new SqliteCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using(var reader = cmd.ExecuteReader())
                {
                    var dataSet = new DataSet();
                    dataSet.EnforceConstraints = false;
                    do
                    {
                        var dataTable = new DataTable();
                        dataSet.Tables.Add(dataTable);
                        dataTable.Load(reader);
                    }while (!reader.IsClosed);
                    
                    if (dataSet.Tables[0].Rows.Count == 1)
                    {
                        isTrovato = true;
                    }
                }
            }
            return isTrovato;
        }
    }
}
