using Dapper;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FitnessApp.Repositories;

public class UserDapperRepository : IUserRepository
{
    private readonly SqlConnection _sqlConnection;

    public UserDapperRepository()
    {
        this._sqlConnection = new SqlConnection("Server=localhost;Database=FitnessDb; TrustServerCertificate=True; User Id=admin;Password=admin");
        this._sqlConnection.Open();
    }

    public User GetById(int id)
    {
        return _sqlConnection.QueryFirst<User>(
            sql: "select * from Users u where u.Id = @Id",
            param: new { Id = id });
    }

    public IEnumerable<User> GetAll()
    {
        return _sqlConnection.Query<User>(
            sql: "select * from Users");
    }

    public void Create(User user)
    {
        var affectedRowsCount = _sqlConnection.Execute(
           sql: $@"insert into Users([Username], [Password])
                    values(@Username, @Password)",
           param: new { Username = user.Username,
                        Password = user.Password});

        if (affectedRowsCount <= 0)
            throw new Exception("Insert error!");
    }
}
