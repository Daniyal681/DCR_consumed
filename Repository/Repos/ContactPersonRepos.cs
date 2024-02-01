using DAL.EntityModels;
using DCR.Helper.ViewModel;
using DCR.ViewModel.IRepos;
using Microsoft.EntityFrameworkCore;


namespace Repository.Repos
{
    public class ContactPersonRepos : IContactPersonRepos
    {

        private readonly EMS_ITCContext _context;


        public ContactPersonRepos(EMS_ITCContext context)
        {
            _context = context;
        }

        public async Task<ContactPersonViewModel> AddPerson(ContactPersonViewModel model)
        {
            try
            {
                // Create a new User entity
                var newPerson = new ContactPerson
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Title = model.Title,
                    Contact=model.Contact,
                    CreatedBy = "Admin"

                };

                _context.ContactPeople.Add(newPerson);
                await _context.SaveChangesAsync();

                var personid = new Vendor
                {
                    ContactPersonId = newPerson.ContactPersonId,
                };

                _context.Vendors.Add(personid);
                await _context.SaveChangesAsync();


                var persondistributorid = new Distributor
                {
                    ContactPersonId = newPerson.ContactPersonId,
                };

                _context.Distributors.Add(persondistributorid);
                await _context.SaveChangesAsync();






                var contactPersonViewModel = new ContactPersonViewModel
                {
                    FirstName = newPerson.FirstName,
                    LastName = newPerson.LastName,
                    Title = newPerson.Title,
                    Contact = newPerson.Contact,
                };



                return contactPersonViewModel;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<object> DeletePerson(int ContactPersonId)
        {
            var result = await _context.ContactPeople.Where(a => a.ContactPersonId == ContactPersonId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.IsActive = false; // Mark the customer as inactive
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<object> GetPerson(int ContactPersonId)
        {
            return await _context.ContactPeople.FirstOrDefaultAsync(a => a.ContactPersonId == ContactPersonId && a.IsActive == true);
        }

        public async Task<IEnumerable<object>> GetPersons()
        {
            return await _context.ContactPeople.Where(x => x.IsActive == true).ToListAsync();
        }

        public async Task<ContactPersonViewModel> UpdatePerson(int ContactPersonId, ContactPersonViewModel model)
        {

            var result = await _context.ContactPeople.FirstOrDefaultAsync(a => a.ContactPersonId == ContactPersonId);
            if (result != null)
            {

                result.FirstName = model.FirstName;
                result.LastName = model.LastName;
                result.Title = model.Title;
                result.Contact = model.Contact;


                // Update other fields if needed, e.g., UpdatedBy and UpdatedOn
                //result.UpdatedBy = model.CustomerName; // Set the appropriate value
                result.UpdatedOn = DateTime.Now; // Set the appropriate value
                // Save changes to the database
                await _context.SaveChangesAsync();


                return model;


            }
            else
            {
                // User not found
                return null;
            }
        }
    }
}
