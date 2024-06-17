using System.ComponentModel.DataAnnotations;

namespace Auction.Contracts.Users;

public record RegisterUserRequest(
    [Required] string Username,
    [Required] string Password,
    [Required] string Email);