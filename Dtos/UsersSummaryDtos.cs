namespace Contacts.Api.Dtos;

public record class UsersSummaryDtos(
    int Id,
    string Name,
    string Surname,
    string mail,
    string phoneNumber
    );



