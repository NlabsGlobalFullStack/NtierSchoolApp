using Bogus;
using Microsoft.AspNetCore.Mvc;
using SchoolBackend.DataAccess.Context;
using SchoolBackend.DataAccess.Interfaces;
using SchoolBackend.Entities.Models;

namespace SchoolBackend.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class SeedDataController(
    AppDbContext context,
    IStudentRepository studentRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult CreateRandomStudents()
    {
        var classRooms = context.ClassRooms.ToList();
        var random = new Random();

        // Eğer sınıf odası yoksa, önce 4 adet sınıf ekleyin
        if (classRooms.Count == 0)
        {
            for (int j = 1; j <= 4; j++)
            {
                ClassRoom newClassRoom = new()
                {
                    Name = $"Sınıf {j}"
                };

                context.Add(newClassRoom);
                context.SaveChanges();
                classRooms.Add(newClassRoom);
            }
        }

        for (int i = 0; i < 1000; i++)
        {
            Faker faker = new();

            int studentNumber = studentRepository.GetNewStudentNumber();
            string identityNumber = Math.Ceiling(faker.Person.Random.Decimal(11111111111, 999999999998)).ToString();

            while (context.Students.Any(p => p.IdentityNumber == identityNumber))
            {
                identityNumber = Math.Ceiling(faker.Person.Random.Decimal(11111111111, 999999999998)).ToString();
            }

            // Rastgele bir sınıf seçin ve öğrenci oluşturun
            ClassRoom randomClassRoom = classRooms[random.Next(0, classRooms.Count)];

            Student student = new()
            {
                ClassRoomId = randomClassRoom.Id,
                FirstName = faker.Person.FirstName,
                LastName = faker.Person.LastName,
                IdentityNumber = identityNumber,
                StudentNumber = studentNumber,
                CreatedDate = DateTime.Now,
                CreatedBy = "Admin",
                IsDeleted = false
            };

            context.Add(student);
            context.SaveChanges();
        }

        return NoContent();
    }

}
