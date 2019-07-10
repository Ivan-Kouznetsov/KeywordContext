using KeywordContext.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace KeywordContext.DAO
{
    public class SqliteDAO
    { 
        const string SelectQuery = @"select InternationalCode, GoodsAndServices, FilingDate, RegistrationDate from CaseFileClass
join CaseFiles on CaseFiles.CaseFileId = CaseFileClass.CaseFileId
where GoodsAndServices like @keyword and FilingDate >= @from and FilingDate <= @to limit @limit";

        public static List<string> GetText(string filepath, DateTime from, DateTime to, string keyword, int limit)
        {
            List<string> result = new List<string>();
            
            using (SqliteConnection sqliteConnection = new SqliteConnection(@"Data Source=" + filepath))
            {
                sqliteConnection.Open();
                using (SqliteCommand sqliteCommand = new SqliteCommand(SelectQuery, sqliteConnection))
                {

                    sqliteCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    sqliteCommand.Parameters.AddWithValue("@from", from.ToString("yyyy-mm-dd"));
                    sqliteCommand.Parameters.AddWithValue("@to", to.ToString("yyyy-mm-dd"));
                    sqliteCommand.Parameters.AddWithValue("@limit", limit);

                    SqliteDataReader reader = sqliteCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add((string)reader["GoodsAndServices"]);
                    }
                }
            }

            return result;
        }
        
        private static string IntListToString(List<int> list)
        {
            List<string> strings = new List<string>();

            foreach (int i in list)
            {
                strings.Add(i.ToString());
            }

            return string.Join(",", strings);
        }
    }
}
