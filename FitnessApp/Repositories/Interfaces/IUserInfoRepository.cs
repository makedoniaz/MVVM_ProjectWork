using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Repositories.Interfaces;

public interface IUserInfoRepository
{
    UserInfo? GetById(int id);
}
