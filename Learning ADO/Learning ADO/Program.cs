using Microsoft.Data.SqlClient;
using System;

namespace Learning_ADO
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(
                "Server=.;Database=SoftUni;Integrated Security=true;TrustServerCertificate=True"))
            {

                sqlConnection.Open();

                string sqlString = "SELECT COUNT(*) FROM Employees";

                SqlCommand sqlCommand = new SqlCommand(sqlString,sqlConnection);

                var result = sqlCommand.ExecuteScalar();

                Console.WriteLine(result);

                string sqlRead = "SELECT FirstName,LastName,Salary FROM Employees WHERE FirstName Like 'N%'";

                sqlCommand = new SqlCommand(sqlRead, sqlConnection);

                var reader = sqlCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string firstName = (string)reader[0];
                        string lastName = (string)reader[1];
                        decimal salary = (decimal)reader[2];

                        Console.WriteLine(firstName + " " + lastName + " => " + salary);

                    }
                }

                sqlCommand = new SqlCommand("UPDATE Employees SET Salary = Salary * 2", sqlConnection);

                var number = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"Number of updated rows {number}");

                sqlCommand = new SqlCommand(sqlRead, sqlConnection);

                var reader2 = sqlCommand.ExecuteReader();
                using (reader2)
                {
                    while (reader2.Read())
                    {
                        string firstName = (string)reader2[0];
                        string lastName = (string)reader2[1];
                        decimal salary = (decimal)reader2[2];

                        Console.WriteLine(firstName + " " + lastName + " => " + salary);

                    }
                }


            }
        }
    }
}
