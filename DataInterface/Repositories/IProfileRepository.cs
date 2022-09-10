using Model.Entities;
using Model.Entities.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInterface.Repositories
{
    public interface IProfileRepository
    {
        public Task<bool> CreateProfile(Profile profile);
        public Task<bool> CreateSkills(string skill, int id);
        public Task<bool> CreateProfileSkills(string skill, int id);
        public Task<List<GetProfile>> GetAll(int page);
        public Task<List<int>> GetProfileId(int id);
        public Task<List<GetProfile>> GetSkills(string skill);
        public Task<List<string>> SkillsGetter();
        public Task<Profile> UpdateProfile(Profile profile);
        public Task<bool> UpdateProfileSkills(string skill, int id);
        public Task<bool> DeletePS(int id);
        public Task<bool> Delete(int id);
    }
}
