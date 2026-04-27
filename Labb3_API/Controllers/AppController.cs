using Labb3_API.Models;
using Labb3_API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public AppController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        //Hämta alla personer i systemet
        [HttpGet("getAllPersons", Name = "GetAllPersons")]
        public async Task<ActionResult<IEnumerable<GetPersonResponse>>> GetAllPersons()
        {
            return Ok(await _ctx.Persons
                .AsNoTracking()
                .Select(p => new GetPersonResponse(
                    p.Id,
                    p.Name,
                    p.PhoneNumber
                    ))
                .ToListAsync());
        }

        //Hämta alla intressen kopplade till en specifik person
        [HttpGet("persons/{personId}/interests", Name = "GetPersonsInterests")]
        public async Task<ActionResult<IEnumerable<GetInterestResponse>>> GetInterestById(int personId)
        {
            var person = await _ctx.Persons
                .AsNoTracking()
                .Where(u => u.Id == personId)
                .Select(i => new
                {
                    i.Name,
                    Interests = i.InterestPersons.Select(l => new
                    {
                        l.InterestId,
                        l.Interest.Title,
                        l.Interest.Description
                    })
                })
                .FirstOrDefaultAsync();

            if (person is null)
            {
                return NotFound($"Personen med id: {personId} kunde inte hittas.");
            }
            return Ok(person);
        }

        //Hämta alla länkar kopplade till en specifik person
        [HttpGet("getPersonLinkById/persons/{personId}", Name = "GetLinkById")]
        public async Task<ActionResult<IEnumerable<GetLinkResponse>>> GetLinkById(int personId)
        {
            var personExist = await _ctx.Persons.FirstOrDefaultAsync(p => p.Id == personId);

            if (personExist is null)
            {
                return NotFound($"Personen med id: {personId} kunde inte hittas.");
            }

            var links = await _ctx.Links
                .AsNoTracking()
                .Where(u => u.InterestPerson.PersonId == personId)
                .Select(i => new
                {
                    i.Id,
                    i.Url,
                    Interest = i.InterestPerson.Interest.Title
                })
                .ToListAsync();

            return Ok(links);
        }

        //Koppla en person till ett nytt intresse
        [HttpPost("addInterest/{personId}", Name = "AddInterest")]
        public async Task<ActionResult<IEnumerable<AddInterestToPersonRequst>>> AddInterestToPerson(int personId, AddInterestToPersonRequst request)
        {
            var personToUpdate = await _ctx.Persons.FirstOrDefaultAsync(u => u.Id == personId);

            if (personToUpdate is null)
            {
                return NotFound("Personen hittades inte");
            }


            var interest = await _ctx.Interests.FirstOrDefaultAsync(i => i.Id == request.InterestId);

            if (interest is null)
            {
                return NotFound("Intresset hittades inte");
            }

            var alreadyExists = await _ctx.InterestPersons.AnyAsync(l => l.PersonId == personId && l.InterestId == request.InterestId);

            if (alreadyExists)
            {
                return BadRequest("Personen har redan detta intresset");
            }

            var interestToAdd = new InterestPerson
            {
                InterestId = request.InterestId,
                PersonId = personId
            };

            await _ctx.InterestPersons.AddAsync(interestToAdd);
            await _ctx.SaveChangesAsync();

            return Ok($"{personToUpdate.Name}(id: {personId}) har fått {interest.Title} (id: {request.InterestId}) som intresse!");
        }

        //Lägg till ny länk
        [HttpPost("addLinkToPersonInterest")]
        public async Task<IActionResult> UpdateLinks(AddLinkRequest request)
        {
            var person = await _ctx.Persons.FirstOrDefaultAsync(p => p.Id == request.PersonId);
            if (person is null)
            {
                return BadRequest($"Det finns ingen person med id: {request.PersonId}");
            }

            var interest = await _ctx.Interests.FirstOrDefaultAsync(i => i.Id == request.InterestId);
            if (interest is null)
            {
                return BadRequest($"Det finns inget intresse med id: {request.InterestId}");
            }

            if (string.IsNullOrWhiteSpace(request.Url))
            {
                return BadRequest("Du måste ange en URL");
            }

            var existingPersonInterest = await _ctx.InterestPersons.FirstOrDefaultAsync(ip => ip.PersonId == request.PersonId && ip.InterestId == request.InterestId);
            if (existingPersonInterest is null)
            {
                existingPersonInterest = new InterestPerson
                {
                    PersonId = request.PersonId,
                    InterestId = request.InterestId
                };

                await _ctx.InterestPersons.AddAsync(existingPersonInterest);
                await _ctx.SaveChangesAsync();
            }

            var newLink = await _ctx.Links.FirstOrDefaultAsync(l => l.InterestPersonId == existingPersonInterest.Id && l.Url == request.Url);
            if (newLink is not null)
            {
                return BadRequest("Länken finns redan, vänligen välj en annan länk.");
            }

            var addNewLink = new Link
            {
                InterestPersonId = existingPersonInterest.Id,
                Url = request.Url
            };

            existingPersonInterest.Links.Add(addNewLink);
            await _ctx.SaveChangesAsync();

            return Ok($"Länken {addNewLink.Url} har lagt till!");
        }
    }
}
