using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FormService
    {
        #region Fields
        private readonly FormRepo repo = new();
        #endregion

        #region Public Methods
        public async Task<Form> GetForm(int? id = null)
        {
            return await repo.RetreiveById(id);
        }

        public async Task<List<Form>> GetForms()
        {
            return await repo.RetreiveAll();
        }

        public async Task<Form> CreateForm(Form form)
        {
            return await repo.InsertForm(form);
        }
        #endregion
    }
}
