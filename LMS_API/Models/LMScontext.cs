using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AD_LMS.Models.zmm;
using AD_LMS.Models.Cxy;
using Microsoft.EntityFrameworkCore;
using AD_LMS.Models.WzbModels;
using LMS_API.Models.WzbModels;
using LMS_API.Models;

namespace AD_LMS.Models
{
    public class LMScontext:DbContext 
    {
        public LMScontext() { }
        public LMScontext(DbContextOptions<LMScontext> options) : base(options) { }
        public DbSet<RepaymentSchedule> RepaymentSchedule { get; set; }
        public DbSet<UpdateRecord> UpdateRecord { get; set; }
        public DbSet<AuthorityJurisdiction> AuthorityJurisdiction { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<MenuJurisdiction> MenuJurisdiction { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<RaInfo> RaInfo  { get; set; }
        public DbSet<RoleInfo> RoleInfo { get; set; }
        public DbSet<UrInfo> UrInfo { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<LMS_Apply> LMS_Apply { get; set; }
        public DbSet<LMS_Client> LMS_Client { get; set; }
        public DbSet<LMS_DState> LMS_DState { get; set; }
        public DbSet<Lms_Education> Lms_Education { get; set; }
        public DbSet<LMS_ShouJi> LMS_ShouJi { get; set; }
        public DbSet<LMS_State> LMS_State { get; set; }
        public DbSet<Collection> Collection { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<LMS_Ding> LMS_Ding { get; set; }
        public DbSet<LMS_Nation> LMS_Nation { get; set; }
        public DbSet<UserInfos> UserInfos { get; set; }
        internal object Query<T>(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
