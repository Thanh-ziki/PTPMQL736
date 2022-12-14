using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PTPMQL.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PTPMQL.Models.Account> Account { get; set; } = default!;

        public DbSet<PTPMQL.Models.CheckAccount> CheckAccount { get; set; } = default!;

        public DbSet<PTPMQL.Models.KhachHang> KhachHang { get; set; } = default!;

        public DbSet<PTPMQL.Models.Passenger> Passenger { get; set; } = default!;

        public DbSet<PTPMQL.Models.Meeting> Meeting { get; set; } = default!;

        public DbSet<PTPMQL.Models.QuanLiHangGui> QuanLiHangGui { get; set; } = default!;

        public DbSet<PTPMQL.Models.QuanLiChuyenBay> QuanLiChuyenBay { get; set; } = default!;
    }
