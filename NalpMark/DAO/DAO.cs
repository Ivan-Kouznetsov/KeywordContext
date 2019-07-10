using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace NalpMark
{
    public static class DAO
    {
        const string SelectQuery = @"select InternationalCode, GoodsAndServices, FilingDate, RegistrationDate from CaseFileClass
join CaseFiles on CaseFiles.CaseFileId = CaseFileClass.CaseFileId
where GoodsAndServices like @keyword and InternationalCode in (@classes) and FilingDate >= @from and FilingDate <= @to limit @limit";

        public static string GetText(string filepath, DateTime from, DateTime to, List<int> classes, string keyword, int limit, bool useFilingDate)
        {
            string result = string.Empty;
            string query = SelectQuery.Replace("@classes", IntListToString(classes));

            if (!useFilingDate)
            {
                query = query.Replace("FilingDate", "RegistrationDate");
            }

            using (SqliteConnection sqliteConnection = new SqliteConnection(@"Data Source=" + filepath))
            {
                sqliteConnection.Open();
                using (SqliteCommand sqliteCommand = new SqliteCommand(query, sqliteConnection))
                {

                    sqliteCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    sqliteCommand.Parameters.AddWithValue("@from", from.ToString("yyyy-mm-dd"));
                    sqliteCommand.Parameters.AddWithValue("@to", to.ToString("yyyy-mm-dd"));
                    sqliteCommand.Parameters.AddWithValue("@limit", limit);

                    SqliteDataReader reader = sqliteCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        result += " " + (string)reader["GoodsAndServices"];
                    }
                }
            }

            return result.Trim();
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
