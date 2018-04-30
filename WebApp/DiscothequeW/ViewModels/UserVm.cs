using D.Models.Enums;

namespace DiscothequeW.ViewModels
{
    public class UserVm
    {
        public int Id { get; set; }

        public int IdRol { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public Gender Gender { get; set; }
    }
}
