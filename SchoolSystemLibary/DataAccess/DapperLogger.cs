using Dapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class DapperLogger
{
    private readonly IDbConnection connection;

    public DapperLogger(string connectionString)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();
    }

    public IEnumerable<T> Query<T>(string sql, object param = null)
    {
        Log.Information("Dapper SQL Query: {Sql}", sql);
        return connection.Query<T>(sql, param);
    }

    public IEnumerable<T> ExecuteCustomQuery<T>(string sql, object param = null)
    {
        Log.Information("Custom SQL Query: {Sql} with parameters: {@Parameters}", sql, param);
        return connection.Query<T>(sql, param);
    }

    // Define other Dapper methods (Execute, QueryMultiple, etc.) similarly

    public void Dispose()
    {
        connection.Close();
        connection.Dispose();
    }
}