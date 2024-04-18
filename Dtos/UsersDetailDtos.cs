namespace Contacts.Api.Dtos;

public record class UsersDetailsDtos(
    int Id,
    string Name,
    string Surname,
    string mail,
    int phoneNumberId
    );



