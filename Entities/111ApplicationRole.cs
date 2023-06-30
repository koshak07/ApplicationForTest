using Microsoft.AspNetCore.Identity;

namespace ApplicationForTest.Entities
{
    public class ApplicationRole : IdentityRole<Guid>

    {
        public ApplicationRole(string name) : base(name)
        {
        }

        public ApplicationRole() : base()
        {
        }

        public Guid Id { get; set; }

        public Guid UserId
        {
            get; set;
        }
    }
}