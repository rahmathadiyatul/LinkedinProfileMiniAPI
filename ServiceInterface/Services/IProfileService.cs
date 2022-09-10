using Model.Entities;
using Model.Entities.SubModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface.Services
{
    public interface IProfileService
    {
        public Task<bool> Create(Profile profile);
        public Task<List<GetProfile>> Get(int page);
        public Task<List<GetProfile>> GetFilter(string filter);
        public Task<bool> Update(Profile profile);
        public Task<bool> Delete(int id);
    }
}
