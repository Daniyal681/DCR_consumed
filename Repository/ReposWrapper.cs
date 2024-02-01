using DAL.EntityModels;
using DCR.ViewModel;
using DCR.ViewModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReposWrapper : IReposWrapper
    {
        private readonly EMS_ITCContext _context;
        public ReposWrapper(EMS_ITCContext context)
        {
            _context = context;
        }

        public IAccountRepos Account => throw new NotImplementedException();
    }
}
