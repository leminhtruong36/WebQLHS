using Microsoft.EntityFrameworkCore;
namespace WebQLHS.Models
{
    public class QlhsDbContext : DbContext
    {
        public QlhsDbContext(DbContextOptions<QlhsDbContext> options) : base(options) { }
        public DbSet<HocSinh> HocSinh { get; set; }
        public DbSet<BangDiem> BangDiem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HocSinh>()
                .HasKey(hs => hs.MaHS);
            modelBuilder.Entity<BangDiem>()
                .HasKey(bd => bd.MaBangDiem);

            //modelBuilder.Entity<HocSinh>()
            //    .HasOne(hs => hs.GiaoVien)
            //    .WithMany(gv => gv.HocSinhs)
            //    .HasForeignKey(hs => hs.MaGVCN);
        }

    }
}
