using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public List<Reserva>? reserva { get; set; }
}