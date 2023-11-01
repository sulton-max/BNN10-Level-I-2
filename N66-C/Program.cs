using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using N66_C.Domain.Entities;
using N66_C.Persistence.DataContexts;

var services = new ServiceCollection();

services.AddDbContext<AppDbContext>();

var serviceProvider = services.BuildServiceProvider();

var appDbContext = serviceProvider.GetRequiredService<AppDbContext>();

// Seed Data
if (!appDbContext.Authors.Any())
{
    appDbContext.Authors.AddRange(new Author
        {
            FirstName = "John",
            LastName = "Doe"
        },
        new Author
        {
            FirstName = "Jonibek",
            LastName = "Doniyorov"
        });

    var changedRowsCount = await appDbContext.SaveChangesAsync();
}

if (appDbContext.Authors.Any() && !appDbContext.Books.Any())
{
    appDbContext.Books.AddRange(new Book
        {
            Title = "Asp.NET Core in Action 2018",
            Description = "Programming",
            AuthorId = appDbContext.Authors.First().Id
        },
        new Book
        {
            Title = "Asp.NET Core in Action 2021",
            Description = "Programming",
            AuthorId = appDbContext.Authors.Skip(1).First().Id
        });

    var changedRowsCount = await appDbContext.SaveChangesAsync();
}

// Read Data


var sameBookA = await appDbContext.Books.FirstAsync(book => book.Id.Equals(Guid.Parse("393f9c34-10fa-4184-84bc-73eb55b339bf")));
sameBookA.Title = "Test update";
appDbContext.Update(sameBookA);

var sameBookB = await appDbContext.Books.FirstAsync(book => book.Id.Equals(Guid.Parse("393f9c34-10fa-4184-84bc-73eb55b339bf")));

// var allBooks = await appDbContext.Books
//     .Include(book => book.Author)
//     .ToListAsync();

Console.ReadLine();

// CRUD
// Console.WriteLine(allBooks);


// book and author entity
// book and author service
// book and author validation
// book and author controller
// seed data
// configuration