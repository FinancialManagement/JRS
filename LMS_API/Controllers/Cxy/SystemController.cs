using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AD_LMS.Models;
using AD_LMS.Models.Cxy;
using LMS_API.Models.Cxy;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http.Extensions;

namespace LMS_API.Controllers.Cxy
{
    [Produces("application/json", "application/xml")]
    [Route("api/[controller]")]
    [EnableCors("cors")]
    [ApiController]

    public class SystemController : ControllerBase
    {
        public LMScontext db;
        public SystemController(LMScontext db) { this.db = db; }

        private static string conn = "Data Source=10.3.158.43;Initial Catalog=LMS_Finance;User ID=sa; Password=123456;";

        LogHelper log = new LogHelper();

        /// <summary>
        /// 账户登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPwd"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpGet]
        public async Task<ActionResult<int>> Login(string UserName, string UserPwd)
        {
            
            var list = db.UserInfo.Where(s => s.UserName.Equals(UserName) && s.UserPwd.Equals(UserPwd)).CountAsync();
            string OperateUser = UserName;
            string RequestMethod= HttpContext.Request.GetDisplayUrl();
            string IPAddress = Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString();
            log.Add(OperateUser,"登录",RequestMethod,IPAddress);
            return await list;
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PositionName"></param>
        /// <param name="States"></param>
        /// <returns></returns>
        [Route("GetUser")]
        [HttpGet]
        public UserPage GetUser(string UserName, string PositionName, int States, int PageSize = 5, int CurrentPage = 1)
        {
            var list = from a in db.Position
                       from b in db.UserInfo
                       from c in db.UrInfo
                       from d in db.RoleInfo
                       where a.Id == b.PId && b.Id == c.UId && c.RId == d.Id
                       select new VirtualUser { Id = b.Id, UserName = b.UserName, UserPwd = b.UserPwd, RoleName = d.RoleName, States = b.States, PositionName = a.PName, Phone = b.Phone, CreateTime = b.CreateTime };

            if (!string.IsNullOrEmpty(UserName))
            {
                list = list.Where(s => s.UserName.Contains(UserName));
            }
            if (!string.IsNullOrEmpty(PositionName))
            {
                list = list.Where(s => s.PositionName.Contains(PositionName));
            }
            if (States != -1)
            {
                list = list.Where(s => s.States.Equals(States));
            }
                if (CurrentPage < 1)
                {
                    CurrentPage = 1;
                }
                var count = list.Count();
                var index = 0;
                if (count % PageSize == 0)
                {
                    index = count / PageSize;
                }
                else
                {
                    index = count / PageSize + 1;
                }
                if (CurrentPage > index)
                {
                    CurrentPage = index;
                }

                UserPage p = new UserPage();
                p.PageIndex = index;
                p.CurrentPage = CurrentPage;
                p.TotalCount = count;
                p.VirtualUsers = list.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

                return p;
            }

        /// <summary>
            /// 获取角色名称
            /// </summary>
            /// <returns></returns>
        [Route("GetRole")]
        [HttpGet]
        public List<RoleInfo> GetRole(string name)
            {
                using (IDbConnection db = new SqlConnection(conn))
                {
                    string sql = $"select * from UserInfo a join UrInfo b on a.Id=b.UId join RoleInfo c on b.RId=c.Id where a.UserName='{name}'";
                    return db.Query<RoleInfo>(sql).ToList();
                }
            }

        /// <summary>
            /// 下拉绑定职位
            /// </summary>
            /// <returns></returns>
        [Route("BindPosition")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> BindPosition()
            {
                var list = db.Position.ToListAsync();
                return await list;
            }

        /// <summary>
            /// 下拉绑定角色
            /// </summary>
            /// <returns></returns>
        [Route("BindRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleInfo>>> BindRole()
            {
                var list = db.RoleInfo.ToListAsync();
                return await list;
            }

        /// <summary>
            /// 新增账户
            /// </summary>
            /// <param name="User"></param>
            /// <param name="rid"></param>
            /// <returns></returns>
        [Route("AddUser")]
        [HttpPost]
        public int AddUser(string User, int rid)
            {
                UserInfo model = JsonConvert.DeserializeObject<UserInfo>(User);

                if (model == null)
                {
                    return 0;
                }
                else
                {
                    using (IDbConnection db = new SqlConnection(conn))
                    {
                        string sql = $"select top 1 * from UserInfo order by Id desc";
                        var a = db.Query<UserInfo>(sql).FirstOrDefault();
                        a.Id += 1;
                        string sql1 = $"insert into UrInfo values('{a.Id}','{rid}')";
                        db.Execute(sql1);
                        string sql2 = $"insert into UserInfo values('{model.UserName}','{model.UserPwd}','{model.PId}','{model.States}','{model.Phone}','{model.CreateTime}')";
                        return db.Execute(sql2);
                    }
                }
            }

        /// <summary>
            /// 绑定菜单权限
            /// </summary>
            /// <param name="rid"></param>
            /// <returns></returns>
        [Route("GetMenu")]
        [HttpGet]
        public List<MenuJurisdiction> GetMenu(int rid)
            {
                using (IDbConnection db = new SqlConnection(conn))
                {
                    string sql = $"select * from RoleInfo a join RaInfo b on a.Id=b.RId join MenuJurisdiction c on b.MId=c.Id where a.Id={rid}";
                    return db.Query<MenuJurisdiction>(sql).ToList();
                }
            }

        /// <summary>
            /// 绑定子菜单权限
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        [Route("GetMenuSon")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuJurisdiction>>> GetMenuSon(int id)
            {
                return await db.MenuJurisdiction.Where(s => s.PId == id).ToListAsync();
            }

        /// <summary>
            /// 修改账户状态 启用|禁用
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        [Route("UptStates")]
        [HttpPut]
        public async Task<ActionResult<int>> UptStates(int id)
            {
                var obj = db.UserInfo.Find(id);
                db.Entry(obj).State = EntityState.Modified;
                if (obj.States == 0)
                {
                    obj.States = 1;
                }
                else
                {
                    obj.States = 0;
                }
                return await db.SaveChangesAsync();
            }

        /// <summary>
            /// 编辑账户信息
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        [Route("UptUser")]
        [HttpPut]
        public async Task<ActionResult<int>> UptUser(string user, int uid, int rid)
            {
                UserInfo model = JsonConvert.DeserializeObject<UserInfo>(user);
                if (model == null)
                {
                    return 0;
                }
                else
                {
                    UrInfo a = db.UrInfo.Where(s => s.UId == uid).FirstOrDefault();
                    db.Entry(a).State = EntityState.Modified;
                    a.UId = uid;
                    a.RId = rid;
                    db.Entry(model).State = EntityState.Modified;
                    return await db.SaveChangesAsync();
                }
            }

        /// <summary>
            /// 账户反填
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        [Route("EditUser")]
        [HttpGet]
        public UserInfo EditUser(int id)
            {
                return db.UserInfo.Where(s => s.Id == id).FirstOrDefault();
            }

        /// <summary>
            /// 角色反填
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        [Route("EditRole")]
        [HttpGet]
        public UrInfo EditRole(int id)
            {
                return db.UrInfo.Where(s => s.UId == id).FirstOrDefault();
            }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PositionName"></param>
        /// <param name="States"></param>
        /// <returns></returns>
        [Route("GetRoleInfo")]
        [HttpGet]
        public RolePage GetRoleInfo(string RoleName,int States, int PageSize = 5, int CurrentPage = 1)
        {
            var list = db.RoleInfo.ToList();

            if (!string.IsNullOrEmpty(RoleName))
            {
                list = list.Where(s => s.RoleName.Contains(RoleName)).ToList();
            }
            if (States != -1)
            {
                list = list.Where(s => s.States.Equals(States)).ToList();
            }
            if (CurrentPage < 1)
            {
                CurrentPage = 1;
            }
            var count = list.Count();
            var index = 0;
            if (count % PageSize == 0)
            {
                index = count / PageSize;
            }
            else
            {
                index = count / PageSize + 1;
            }
            if (CurrentPage > index)
            {
                CurrentPage = index;
            }

            RolePage p = new RolePage();
            p.PageIndex = index;
            p.CurrentPage = CurrentPage;
            p.TotalCount = count;
            p.RoleInfos = list.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

            return p;
        }

        /// <summary>
        /// 修改角色状态 启用|禁用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("UptRoleState")]
        [HttpPut]
        public async Task<ActionResult<int>> UptRoleState(int id)
        {
            var obj = db.RoleInfo.Find(id);
            db.Entry(obj).State = EntityState.Modified;
            if (obj.States == 0)
            {
                obj.States = 1;
            }
            else
            {
                obj.States = 0;
            }
            return await db.SaveChangesAsync();
        }

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [Route("AddRole")]
        [HttpPost]
        public async Task<ActionResult<int>> AddRole(string role)
        {
            RoleInfo model = JsonConvert.DeserializeObject<RoleInfo>(role);
            if (model==null)
            {
                return 0;
            }
            else
            {
                db.RoleInfo.Add(model);
                return await db.SaveChangesAsync();
            }
        }

        [Route("GetLog")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> GetLog()
        {
            return await db.Log.ToListAsync();
        }
    }
}
