using Dapper;
using Microsoft.Extensions.Configuration;
using Model.Entities;
using MySql.Data.MySqlClient;
using ServiceInterface.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _db;

        public DbService(IConfiguration configuration)
        {
            _db = new MySqlConnection(configuration.GetConnectionString("ConnectLinkedin"));
        }

        public async Task<int> Insert(string command, object param)
        {
            var result = await _db.ExecuteAsync(command, param);
            return result;
        }
        public async Task<List<T>> GetData<T>(string command, object param)
        {
            List<T> result = (await _db.QueryAsync<T>(command, param)).ToList();
            return result;
        }

        public async Task<int> DeleteProfileSkills(string command, object param)
        {
            var result = await _db.ExecuteAsync(command, param);
            return result;
        }

        public async Task<int> DeleteProfile(string command, object param)
        {
            var result = await _db.ExecuteAsync(command, param);
            return result;
        }

    }
}
