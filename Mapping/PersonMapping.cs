using Contacts.Api.Dtos;

namespace Contacts.Api;

public static class PersonMapping
{
    public static Person ToEntity(this CreatePersonDtos person)
    {
        return new Person()
        {

            Name = person.Name,
            SurName = person.Surname,
            mail = person.mail

        };
    }
    public static Person ToEntity(this UpdatePersonDtos person, int id)
    {
        return new Person()
        {
            Id = id,
            Name = person.Name,
            SurName = person.Surname,
            mail = person.mail,
            phoneNumberId = person.phoneNumberId

        };
    }

    public static UsersSummaryDtos ToUsersSummaryDto(this Person person)
    {
        return new(
            person.Id,
             person.Name,
             person.SurName!,
             person.mail!,
            person.PhoneNumber.phoneNumberName
    );
    }

    public static UsersDetailsDtos ToUsersDetailsDto(this Person person)
    {
        return new(
            person.Id,
            person.Name,
            person.SurName,
            person.mail,
            person.phoneNumberId
    );
    }
}
