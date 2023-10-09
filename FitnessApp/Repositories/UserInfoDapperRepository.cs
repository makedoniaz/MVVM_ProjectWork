using Dapper;
using FitnessApp.Models;
using FitnessApp.Repositories.Interfaces;
using FitnessApp.Utilities.DatabaseInfo;
using System;
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

    public UserInfo? GetByUserId(int userId)
    {
        return _sqlConnection.QueryFirst<UserInfo>(
            sql: @"select * from UsersInfo ui
                   where ui.UserId = @UserId",
            param: new { UserId = userId });
    }

    public void Create(UserInfo userInfo)
    {
        var affectedRowsCount = _sqlConnection.Execute(
           sql: $@"insert into UsersInfo([CurrentWeight], [TargetWeight], [CaloriesToConsume], [UserId])
                    values(@CurrentWeight, @TargetWeight, @CaloriesToConsume, @UserId)",
           param: new
           {
               CurrentWeight = userInfo.CurrentWeight,
               TargetWeight = userInfo.TargetWeight,
               CaloriesToConsume = userInfo.CaloriesToConsume,
               UserId = userInfo.UserId,
           });

        if (affectedRowsCount <= 0)
            throw new Exception("Insert error!");
    }
}
