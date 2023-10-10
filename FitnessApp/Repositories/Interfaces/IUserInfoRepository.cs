using FitnessApp.Models;

namespace FitnessApp.Repositories.Interfaces;

public interface IUserInfoRepository
{
    UserInfo? GetById(int id);

    UserInfo? GetByUserId(int userId);

    void Create(UserInfo userInfo);

    void Update(UserInfo userInfo, int id);
}
