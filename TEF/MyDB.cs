namespace TEF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyDB : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“MyDB”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“TEF.MyDB”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“MyDB”
        //连接字符串。
        public MyDB()
            : base("name=MyDB")
        {
        }


        public virtual DbSet<M1> M1shiti { get; set; }
        public virtual DbSet<M2> M2shiti { get; set; }

        public virtual DbSet<M3> M3shiti { get; set; }

        // 实体千万不要复制啥的 很容易出错，还是自己老老实实的写吧

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M1>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<M3>()
              .Property(e => e.Name)
              .IsFixedLength();

            modelBuilder.Entity<M1>()
                .HasMany(e => e.M1List)
                .WithRequired(e => e.M1Model)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<M1>()
               .HasMany(e => e.M2List)
               .WithRequired(e => e.M1Model)
               .HasForeignKey(e => e.M1Id);
        }


        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}