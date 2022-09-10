using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface.Services
{
    public interface IDbService
    {
        Task<int> Insert(string command, object param);
        Task<List<T>> GetData<T>(string command, object param);
        Task<int> DeleteProfileSkills(string command, object param);
        Task<int> DeleteProfile(string command, object param);
    }
}
