


using DCR.Helper.ViewModel;

namespace DCR.ViewModel.IRepos
{ 
    public interface IContactPersonRepos
    {
        Task<IEnumerable<object>> GetPersons();
        Task<object> GetPerson(int ContactPersonId);
        Task<ContactPersonViewModel> AddPerson(ContactPersonViewModel model);
        Task<ContactPersonViewModel> UpdatePerson(int ContactPersonId, ContactPersonViewModel model);
        Task<object> DeletePerson(int ContactPersonId);
    }
}
