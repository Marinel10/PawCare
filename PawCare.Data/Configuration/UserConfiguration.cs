namespace PawCare.Data.Configuration
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration: IEntityTypeConfiguration<IdentityUser>
    {

        public static IdentityUser DefaultUser =>
            new IdentityUser
            {
                Id = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                UserName = "admin@pawcare.com",
                NormalizedUserName = "ADMIN@PAWCARE.COM",
                Email = "admin@pawcare.com",
                NormalizedEmail = "ADMIN@PAWCARE.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>()
                        .HashPassword(new IdentityUser {UserName = "admin@pawcare.com" }, "admin@pawcare.com123")

            };

        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(DefaultUser);
        }
    }
}