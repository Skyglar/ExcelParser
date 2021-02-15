using Dapper;
using ExcelParser.Domain.Entities;
using ExcelParser.Domain.Repository.Contracts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

namespace ExcelParser.Domain.Repository
{
    public class SpreadsheetRepository : ISpreadsheetRepository
    {
        private readonly SpreadsheetDbContext _context;
        private readonly IDbConnection _dbConnection;

        /// <summary>
        ///     ctor()
        /// </summary>
        /// <param name="connectionString">Db Connection String</param>
        public SpreadsheetRepository(SpreadsheetDbContext context)
        {
            _context = context;
            _dbConnection = new SqlConnection(_context.Database.GetConnectionString());
        }

        /// <summary>
        ///     Open new connection and return it for use
        /// </summary>
        /// <returns>IDbConnection</returns>
        private IDbConnection CreateConnection()
        {
            if (_dbConnection.State.ToString().Equals("Closed"))
            {
                _dbConnection.Open();
            }
            return _dbConnection;
        }

        public int AddRange(ICollection<Row> list)
        {
            using (IDbConnection connection = CreateConnection())
            {
                // Microsoft.Data.SqlClient.SqlException
                try
                {
                    return connection.Execute(
                    @"INSERT INTO [dbo].[Spreadsheet] 
                      VALUES (@Hie, @IDX, @Level, @Parent, @Node, @Description, 
                        @Method, @Contains_Att, @Contains_Val, @Between_Att, @Between_Lo, @Between_Hi)",
                    list);
                }
                catch (SqlException)
                {
                    return -2;
                }
            }
        }

        public IEnumerable<Row> GetAll()
        {
            using (IDbConnection connection = CreateConnection())
            {
                return connection.Query<Row>(
                    @"SELECT [Id]
                            ,[Hie]
                            ,[IDX]
                            ,[Level]
                            ,[Parent]
                            ,[Node]
                            ,[Description]
                            ,[Method]
                            ,[Contains_Att]
                            ,[Contains_Val]
                            ,[Between_Att]
                            ,[Between_Lo]
                            ,[Between_Hi]
                    FROM [dbo].[Spreadsheet]");
            }
        }

        public int Delete(int id)
        {
            using (IDbConnection connection = CreateConnection())
            {
                return connection.Execute(
                    @"DELETE FROM [dbo].[Spreadsheet] 
                      WHERE Id = @Id", 
                    new { Id = id });
            }
        }

        public int UpdateRange(ICollection<Row> entities)
        {
            using (IDbConnection connection = CreateConnection())
            {
                try
                {
                    return connection.Execute(
                    @"UPDATE [dbo].[Spreadsheet] 
                      SET Hie = @Hie, IDX = @IDX, Level = @Level, 
                        Parent = @Parent, Node = @Node, Description = @Description, 
                        Method = @Method, Contains_Att = @Contains_Att, Contains_Val = @Contains_Val, 
                        Between_Att = @Between_Att, Between_Lo = @Between_Lo, Between_Hi = @Between_Hi
                      WHERE IDX = @IDX",
                    entities);
                }
                catch (SqlException)
                {
                    return -2;
                }
            }
        }
    }
}
