using System.ComponentModel.DataAnnotations;

namespace Contacts.Api;

public record class UpdatePersonDtos(
[Required][StringLength(50)] string Name,
[Required][StringLength(50)] string Surname,
[Required][StringLength(50)] string mail,
int phoneNumberId
);
