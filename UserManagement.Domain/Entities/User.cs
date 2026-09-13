using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Domain.Entities;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public long SocialIdFK { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime? BirthDate { get; set; }
    public string MobileNumber { get; set; }
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}
