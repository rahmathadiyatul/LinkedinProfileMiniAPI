using DataInterface.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entities;
using Model.Entities.SubModel;
using ServiceInterface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly IDbService _dbService;

        public ProfileRepository(IDbService dbService)
        {
            _dbService = dbService;
        }
        public async Task<bool> CreateProfile(Profile profile)
        {
            await _dbService.Insert(
                "INSERT INTO profile (id, name, university, lulus, sex, phone) " +
                "VALUES (@Id, @Name, @University, @Lulus, @Sex, @Phone);", profile);
            return true;
        }
        public async Task<bool> CreateSkills(string skill, int id)
        {
            await _dbService.Insert(
                "INSERT INTO skills (id,name) VALUES ((select s.id from skills s order by s.id desc limit 1)+1,@skill);" +
                "INSERT INTO profile_has_skills (profile_id,skills_id) " +
                "VALUES (@id,(select s.id from skills s order by s.id desc limit 1));",
                new {skill,id});
            return true;
        }
        public async Task<bool> CreateProfileSkills(string skill, int id)
        {
            await _dbService.Insert(
                "INSERT INTO profile_has_skills (profile_id,skills_id) " +
                "VALUES (@id,(select s.id from skills s where s.name = @skill));",
                new { skill, id });
            return true;
        }
        public async Task<List<GetProfile>> GetAll(int page)
        {
            var result = await _dbService.GetData<GetProfile>(
                "SELECT p.id, p.name, p.university, p.lulus, p.sex, p.phone, group_concat(s.name) skills " +
                "FROM profile p INNER JOIN profile_has_skills ps ON p.id = ps.profile_id " +
                "INNER JOIN skills s ON ps.skills_id = s.id WHERE p.id > (10*(@page-1)) and p.id<=(10*@page) GROUP BY p.id;", new { page });
            return result;
        }
        public async Task<List<int>> GetProfileId(int id)
        {
            var result = await _dbService.GetData<int>(
                "SELECT p.id FROM profile p where p.id = @id;", new { id });
            return result;
        }
        public async Task<List<GetProfile>> GetSkills(string skill)
        {
            var result = await _dbService.GetData<GetProfile>(
                "SELECT p.id, p.name, p.university, p.lulus, p.sex, p.phone, group_concat(s.name) skills " +
                "FROM profile p INNER JOIN profile_has_skills ps ON p.id = ps.profile_id " +
                "INNER JOIN skills s ON ps.skills_id = s.id WHERE s.name = @skill GROUP BY p.id;", new { skill });
            return result;
        }
        public async Task<List<string>> SkillsGetter()
        {
            List<string> result = await _dbService.GetData<string>(
                "SELECT s.name FROM skills s;", new {  });
            return result;
        }
        public async Task<Profile> UpdateProfile(Profile profile)
        {
            await _dbService.Insert("update profile" +
                " set name=@Name, university=@University, lulus=@Lulus, sex=@Sex, phone=@Phone " +
                "where id=@Id;", profile);
            return profile;
        }
        public async Task<bool> UpdateProfileSkills(string skill, int id)
        {
            await _dbService.Insert(
                "INSERT INTO profile_has_skills (profile_id,skills_id) " +
                "VALUES (@id,(select s.id from skills s where s.name = @skill));",
                new { skill, id });
            return true;
        }
        public async Task<bool> DeletePS(int id)
        {
            await _dbService.DeleteProfileSkills("delete from profile_has_skills ps " +
                "where ps.profile_id = @id;", new { id });
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _dbService.DeleteProfileSkills("delete from profile_has_skills ps " +
                "where ps.profile_id = @id;",new { id });
            await _dbService.DeleteProfile("delete from profile p " +
                "where p.id = @id;",new { id });
            return true;
        }
    }
}
