using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess
{
    public class LitmusRepository
    {
        private SugarLabEntities db;

        public LitmusRepository()
        {
            db = new SugarLabEntities();
        }

        #region Methods

        public MasterUser ValidateUser(string code, string password)
        {
            MasterUser masterUser = null;

            masterUser = db.MasterUsers
                .Where(v => v.Code == code && v.Password == password).FirstOrDefault();

            return masterUser;
        }

        public MasterUnit GetUnit(int code)
        {
            return db.MasterUnits.Where(i => i.Code == code).FirstOrDefault();
        }

        public MasterUser GetMasterUser(int id)
        {
            return db.MasterUsers.Where(i => i.Id == id).FirstOrDefault();
        }


        public List<MasterUser> GetMasterUsers()
        {
            return db.MasterUsers.ToList();
        }

        public bool AddMasterUser(MasterUser userInfo)
        {
            db.MasterUsers.Add(userInfo);
            db.SaveChanges();

            return true;
        }

        public bool UpdateMasterUser(MasterUser userInfo)
        {
            if (userInfo == null)
            {
                return false;
            }

            db.Entry(userInfo).State = EntityState.Modified;

            db.SaveChanges();

            return true;
        }

        public bool DeleteMasterUser(int id)
        {
            try
            {
                MasterUser masterUser = db.MasterUsers.Where(i => i.Id == id).FirstOrDefault();

                if (masterUser != null)
                {
                    db.MasterUsers.Remove(masterUser);
                    db.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

    }
}
