using Dapper;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Repositories;

public class UserInfoDapperRepository : IUserInfoRepository
{

    private readonly SqlConnection _sqlConnection;

    public UserInfoDapperRepository()
    {
        this._sqlConnection = new SqlConnection("Server=localhost;Database=FitnessDb; TrustServerCertificate=True; Trusted_Connection=True;");
        this._sqlConnection.Open();
    }

    public UserInfo? GetById(int id)
    {
        return _sqlConnection.QueryFirst<UserInfo>(
            sql: "select * from UsersInfo u where u.Id = @Id",
            param: new { Id = id });
    }
}
