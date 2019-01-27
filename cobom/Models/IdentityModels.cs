using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace cobom.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<cobom.Models.coordinator> coordinators { get; set; }

        public System.Data.Entity.DbSet<cobom.Models.slide> slides { get; set; }
        public System.Data.Entity.DbSet<cobom.Models.news> News { get; set; }

        public System.Data.Entity.DbSet<cobom.Models.member> members { get; set; }

        public System.Data.Entity.DbSet<cobom.Models.gallary_picture> gallary_picture { get; set; }

        public System.Data.Entity.DbSet<cobom.Models.archievement> archievements { get; set; }

        public System.Data.Entity.DbSet<cobom.Models.messagedetail> messagedetails { get; set; }

        public System.Data.Entity.DbSet<cobom.Models.message> messages { get; set; }
        public System.Data.Entity.DbSet<cobom.Models.about> abouts { get; set; }

        public System.Data.Entity.DbSet<cobom.Models.downloadFile> downloadFiles { get; set; }
        public System.Data.Entity.DbSet<cobom.Models.newarchievement> newarchievement { get; set; }
        public System.Data.Entity.DbSet<cobom.Models.newarchievementDetail> newarchievementDetails { get; set; }
        public System.Data.Entity.DbSet<cobom.Models.newscategory> newscategories { get; set; }

        public System.Data.Entity.DbSet<cobom.Models.newsComment> newsComments { get; set; }

    }
}