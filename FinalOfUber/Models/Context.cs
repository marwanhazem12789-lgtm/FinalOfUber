using Microsoft.EntityFrameworkCore;

namespace FinalOfUber.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> o):base(o) { }

        public DbSet<User> users { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Rating> ratings { get; set; }
        public DbSet<Ride> rides { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(i => i.Vehicle).WithOne(i => i.Driver).HasForeignKey<Vehicle>(o => o.DriverId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasMany(i => i.Driverrides).WithOne(i => i.Driver).HasForeignKey(o => o.DriverId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>().HasMany(i => i.Riderrides).WithOne(i => i.Rider).HasForeignKey(o => o.RiderId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ride>().HasOne(i => i.Payment).WithOne(i => i.Ride).HasForeignKey<Payment>(o => o.RideId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Ride>().HasOne(i => i.Rating).WithOne(i => i.Ride).HasForeignKey<Rating>(o => o.RideId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Email = "Moo@gmail.com",
                FullName = "Mohamed Ashraf",
                Password = "123456",
                Phone = "01096857067",
                Role= "Admin"
                
            },
            new User
            {
                Id = 2,
                Email = "Maro@gmail.com",
                FullName = "Maro Ashraf",
                Password = "123456",
                Phone = "01096857067",
                Role = "Driver"

            });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = 1,
                Color = " Red",
                DriverId = 1,
                Model = "BMW-7",
                PalteNumber = "125487",
                
            },

            new Vehicle
            {
                Id = 2,
                Color = " Black",
                DriverId = 2,
                Model = "BMW-9",
                PalteNumber = "12548",

            });

            modelBuilder.Entity<Ride>().HasData(new Ride
            {
                Id = 1,
                DriverId = 1,
                RiderId = 1,
                Status = "Availble",
                DropOffLocatin = "Imbaba",
                PickupLocatin = "October",
                Fare = 80

            }, new Ride
            {
                Id = 2,
                DriverId = 2,
                RiderId =2,
                Status = "Busy",
                DropOffLocatin = "Fasel",
                PickupLocatin = "Zayed",
                Fare = 100

            });

            modelBuilder.Entity<Rating>().HasData(new Rating
            {
                Id = 1,
                Score = 2,
                Comments = "Good",
                RideId = 1
            }, new Rating
            {
                Id = 2,
                Score = 4,
                Comments = "Very Good",
                RideId = 2
            });


            modelBuilder.Entity<Payment>().HasData(new Payment
            {
                Id = 1,
                Amount = 250,
                PaymentDate = new DateTime(2022, 8, 8),
                PaymentMethod = "Cash",
                RideId = 1,
               Status = "Complete"
            }, new Payment
            {
                Id = 2,
                Amount = 350,
                PaymentDate = new DateTime(2024, 9, 8),
                PaymentMethod = "مش معايا فلوس",
                RideId =2,
                Status = "Canceled"
            });
        }


    }

}
