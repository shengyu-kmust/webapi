using System.Data.Entity;

namespace webapi.Entities
{
    public class DB : DbContext
    {
        /// <summary>
        /// name=DBConnection，DBConnection为数据库连接的名字，即web.config配置文件节点connectionStrings，name值为DBConnection的数据库连接字符串
        /// </summary>
        public DB()
            : base("name=DBConnection")
        {
            // 默认策略为CreateDatabaseIfNotExists，即如果数据库不存在则创建，用migrations时改成MigrateDatabaseToLatestVersion，即每次第一次访问数据库时同步最新的数据库结构
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB, webapi.Migrations.Configuration>("DBConnection"));
        }


        #region 配置所有的数据库表

        public DbSet<User> Users { set; get; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<Resource> Resources { set; get; }
        public DbSet<URM> URMs { set; get; }
        public DbSet<Permission> Permissions { set; get; }
        public DbSet<TestTable> TestTables { set; get; }
        #endregion

    }
}