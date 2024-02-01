using DCR.ViewModel.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCR.ViewModel
{
    public interface IReposWrapper
    {
        IAccountRepos Account { get; }
    }
}
