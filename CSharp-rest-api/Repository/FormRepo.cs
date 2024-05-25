using DAL;
using Microsoft.SqlServer.Server;
using Model;
using System.Data;
using Types;

namespace Repository
{
    public class FormRepo
    {
        #region Fields
        private readonly DataAccess db = new();
        #endregion

        #region Methods

        public async Task<Form> RetreiveById(int? id = null)
        {
            List<ParmStruct> parms = new()
            {
                new ParmStruct("@FormId", SqlDbType.Int, id)
            };

            DataTable dt = await db.ExecuteAsync("spRetrieveFormAsync", parms);

            return await PopulateFormRecord(dt.Rows[0]);
        }

        public async Task<List<Form>> RetreiveAll()
        {
            DataTable dt = await db.ExecuteAsync("spRetrieveFormsAsync");

            return dt.AsEnumerable().Select(row => new Form
            {
                FormId = Convert.ToInt32(row["FormId"]),
                Name = row["Name"].ToString(),
                Owned = Convert.ToInt32(row["Owned"]),
                GoodPet = (bool)(row["GoodPet"])
            }).ToList();
        }

        public async Task<Form> InsertForm(Form form)
        {
            List<ParmStruct> parms = new()
            {
                new ParmStruct("@Name", SqlDbType.VarChar, form.Name, 255),
                new ParmStruct("@Owned", SqlDbType.Int, form.Owned),
                new ParmStruct("@GoodPet", SqlDbType.Bit, form.GoodPet),
                new ParmStruct("@FormId", SqlDbType.Int, form.FormId, 0, ParameterDirection.Output)
            };
            int returnedValue = await db.ExecuteNonQueryAsync("spCreateFormAsync", parms);
            if (returnedValue > 0)
            {
                form.FormId = parms.Where(p => p.Name == "@FormId").FirstOrDefault().Value as int? ?? 0;
                return form;
            }
            else
            {
                throw new DataException("There was an issue adding the record to the database.");
            }
        }

        #endregion

        #region Private Methods
        private async Task<Form> PopulateFormRecord(DataRow row)
        {
            return new Form()
            {
                FormId = Convert.ToInt32(row["FormId"]),
                Name = row["Name"].ToString(),
                Owned = Convert.ToInt32(row["Owned"]),
                GoodPet = (bool)(row["GoodPet"])
            };
        }
        #endregion
    }
}