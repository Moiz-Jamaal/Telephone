using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ITelephoneData
    {
        Task<List<TelMaster>> GetTelMasterList();
        Task<string> UpdateData(TelMaster telMaster);
    }
}