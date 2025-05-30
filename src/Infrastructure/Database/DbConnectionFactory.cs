﻿using System.Data;
using Application.Abstractions.Data;
using Npgsql;

namespace Infrastructure.Database;

public sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public IDbConnection GetOpenConnection()
    {
        NpgsqlConnection connection = dataSource.OpenConnection();

        return connection;
    }
}
