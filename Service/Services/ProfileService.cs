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

namespace Service.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            this.profileRepository = profileRepository;
        }

        public async Task<bool> Create(Profile profile)
        {
            Skills skills = new Skills();
            skills.Name = profile.Skills;
            int id = profile.Id;
            await profileRepository.CreateProfile(profile);
            List<string> data = await profileRepository.SkillsGetter();
            Skills skillData = new Skills();
            skillData.Name = data;

            foreach (string skill in skills.Name)
            {
                if (!skillData.Name.Contains(skill))
                {
                    await profileRepository.CreateSkills(skill, id);
                } else if (skillData.Name.Contains(skill))
                {
                    await profileRepository.CreateProfileSkills(skill, id);
                }
            }
            return true;
        }

        public async Task<List<GetProfile>> Get(int page)
        {
            List<GetProfile> result = await profileRepository.GetAll(page);
            return result;
        }
        public async Task<List<GetProfile>> GetFilter(string skill)
        {
            List<GetProfile> result = await profileRepository.GetSkills(skill);
            return result;
        }
        public async Task<bool> Update(Profile profile)
        {
            await profileRepository.UpdateProfile(profile);
            Skills skills = new Skills();
            skills.Name = profile.Skills;
            List<string> data = await profileRepository.SkillsGetter();
            Skills skillData = new Skills();
            skillData.Name = data;
            await profileRepository.DeletePS(profile.Id);
            foreach (string skill in skills.Name)
            {
                if (!skillData.Name.Contains(skill))
                {
                    await profileRepository.CreateSkills(skill, profile.Id);
                }
                else if (skillData.Name.Contains(skill))
                {
                    await profileRepository.UpdateProfileSkills(skill, profile.Id);
                }
            }
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var result = await profileRepository.Delete(id);
            return result;
        }
    }
}
