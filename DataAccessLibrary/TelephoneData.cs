using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public class TelephoneData : ITelephoneData
    {
        private readonly ISqlDataAccess db;

        public TelephoneData(ISqlDataAccess db)
        {
            this.db = db;
        }

        public Task<List<TelMaster>> GetTelMasterList()
        {
            string sql = "select * from dbo.TelMaster";
            return db.LoadData<TelMaster, dynamic>(sql, new { });
        }

        public Task<string> UpdateData(TelMaster telMaster)
        {
            string sql = @" UPDATE TelMaster
                                        SET
                                            Itsid = @ItsId,
                                            Fname = @FName,
                                            Ctgry = @Ctgry,
                                            Dept = @Dept,
                                            Company = @Company,
                                            AddA = @AddA,
                                            CityA = @CityA,
                                            PinA = @PinA,
                                            StateA = @StateA,
                                            CntryA = @CntryA,
                                            FaxA = @FaxA,
                                            FaxB = @FaxB,
                                            MobA = @MobA,
                                            MobB = @MobB,
                                            MobC = @MobC,
                                            ResA = @ResA,
                                            ResB = @ResB,
                                            ResC = @ResC,
                                            OffA = @OffA,
                                            OffB = @OffB,
                                            OffC = @OffC,
                                            ExtA = @ExtA,
                                            ExtB = @ExtB,
                                            ExtC = @ExtC,
                                            EmailA = @EmailA,
                                            EmailB = @EmailB,
                                            EmailC = @EmailC                                           
                                                 WHERE SrNo = @SrNo";
            return (Task<string>)db.SaveData(sql, telMaster);
        }

    }
}
