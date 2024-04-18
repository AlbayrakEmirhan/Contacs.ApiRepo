using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Contacts.Api;

public static class DatExcentions
{
    public static async Task MigrateAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope(); // işlemleri yapabileceğim alan oluşturuyorum 

        var DbContext = scope.ServiceProvider.GetRequiredService<DirectoryContex>();

        await DbContext.Database.MigrateAsync(); // güncel duruma getirmek için kullanıyorum

    }

}
