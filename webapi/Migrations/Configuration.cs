using System.Configuration;

namespace webapi.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<webapi.Entities.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//自动更新数据库
            AutomaticMigrationDataLossAllowed = true;//重命名和删除表字段时会丢失数据，设置成允许，否则此情况下同步数据库会出错
            var providerName = ConfigurationManager.ConnectionStrings["DBConnection"].ProviderName;
            if (providerName == "MySql.Data.MySqlClient")
            {
                SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());//如果数据库用mysql，加上这一句
            }
        }

        protected override void Seed(webapi.Entities.DB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
