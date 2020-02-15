using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PubNew.Models
{
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            try
            {
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
            catch (DbEntityValidationException ex)
            {

                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                System.Diagnostics.Debug.WriteLine(sb.ToString(), ex);
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            };




        }

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public override String Id { get; set; }

        [Required(ErrorMessage = "User name is requied")]
        [RegularExpression(@"^[a-zA-Z""'\S-]*$")]
        [Column("UserName")]
        [Display(Name = "Username")]
        [StringLength(20, ErrorMessage = " User name connet be loger than 20 charactes.")]
        public override String UserName { get; set; }

        [Display(Name = "Email")]
        public override String Email { get; set; }


        [Required(ErrorMessage = "Password is requied")]
        [Display(Name = "Password")]
        [RegularExpression(@"^[a-zA-Z""'\S-]*$")]
        [DataType(DataType.Password)]
        
        public String Password { get; set; }

        [Display(Name = "Create Date")]
        //[ConcurrencyCheck]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }

        public string LoginErrorMsg { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

    }
}