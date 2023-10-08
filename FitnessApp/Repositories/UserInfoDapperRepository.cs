using Dapper;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.Utilities.DatabaseInfo;
using System.Data.SqlClient;

namespace FitnessApp.Repositories;

public class UserInfoDapperRepository : IUserInfoRepository
{

    private readonly SqlConnection _sqlConnection;

    public UserInfoDapperRepository()
    {
        this._sqlConnection = new SqlConnection(DbOptions.ConnectionString);
        this._sqlConnection.Open();
    }

    public UserInfo? GetById(int id)
    {
        return _sqlConnection.QueryFirst<UserInfo>(
            sql: "select * from UsersInfo u where u.Id = @Id",
            param: new { Id = id });
    }
}
