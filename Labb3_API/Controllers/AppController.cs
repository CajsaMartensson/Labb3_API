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
        [HttpGet("persons", Name = "GetAllPersons")]
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

        //Extra, hämta alla intressen i systemet
        [HttpGet("interests", Name = "GetAllInterests")]
        public async Task<ActionResult<Interest>> GetAllInterests()
        {
            return Ok(await _ctx.Interests
                .AsNoTracking()
                .ToListAsync());
        }

        //Hämta alla intressen kopplade till en specifik person
        [HttpGet("persons/{personId}/interests", Name = "GetPersonsInterests")]
        public async Task<ActionResult> GetInterestById(int personId)
        {
            var person = await _ctx.Persons
                .AsNoTracking()
                .Where(u => u.Id == personId)
                .Select(i => new
                {
                    i.Name,
                    Interests = i.Links.Select(l => new
                    {
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
        public async Task<ActionResult<Person>> GetLinkById(int personId)
        {
            var person = await _ctx.Persons
                .AsNoTracking()
                .Where(u => u.Id == personId)
                .Select(i => new
                {
                    i.Name,
                    Link = i.Links.Select(l => new
                    {
                        l.Url
                    })
                })
                .FirstOrDefaultAsync();

            if (person is null)
            {
                return NotFound($"Personen med id: {personId} kunde inte hittas.");
            }
            return Ok(person);
        }

        //Koppla en person till ett nytt intresse
        [HttpPost("addInterest/persons/{personId}/interest/{interestId}", Name = "AddInterest")]
        public async Task<ActionResult<Link>> AddInterestToPerson(int personId, int interestId)
        {
            var personToUpdate = await _ctx.Persons.FirstOrDefaultAsync(u => u.Id == personId);
            var interest = await _ctx.Interests.FirstOrDefaultAsync(i => i.Id == interestId);


            if (personToUpdate is null)
            {
                return NotFound("Personen hittades inte");
            }
            else if (interest is null)
            {
                return NotFound("Intresset hittades inte");
            }

            var alreadyExists = await _ctx.Links.AnyAsync(l => l.PersonId == personId && l.InterestId == interestId);

            if (alreadyExists)
            {
                return BadRequest("Personen har redan detta intressetn");
            }

            var interestToAdd = new Link
            {
                InterestId = interestId,
                PersonId = personId
            };

            await _ctx.Links.AddAsync(interestToAdd);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInterestById), new { personId = personId }, interestToAdd);
        }

        //Lägga till nya länkar för en specifik person och ett specifikt intresse
        [HttpPut("addLinkToPersonInterest/person/{personId}/interest/{interestId}")]
        public async Task<IActionResult> UpdateLinks(int personId, int interestId, UpdateLink updatedLink)
        {
            var person = await _ctx.Persons.FirstOrDefaultAsync(p => p.Id == personId);
            if (person is null)
            {
                return BadRequest($"Det finns ingen person med id: {personId}");
            }

            var interest = await _ctx.Interests.FirstOrDefaultAsync(i => i.Id == interestId);
            if (interest is null)
            {
                return BadRequest($"Det finns inget intresse med id: {interestId}");
            }

            var linkToUpdate = await _ctx.Links.FirstOrDefaultAsync(l => l.PersonId == personId && l.InterestId == interestId);

            if (linkToUpdate is null)
            {
                return NotFound("Denna personen har inte det valda intresset. Den måste ha intresset för att lägga till en länk.");
            }

            if (!string.IsNullOrWhiteSpace(linkToUpdate.Url))
            {
                return BadRequest("Det finns redan en länk. Du kan bara lägga till där det saknas.");
            }

            if (string.IsNullOrWhiteSpace(updatedLink.Url))
            {
                return BadRequest("Du måste ange en URL");
            }



            linkToUpdate.Url = updatedLink.Url;

            _ctx.Update(linkToUpdate);
            await _ctx.SaveChangesAsync();

            return Ok($"Länken {linkToUpdate.Url} har lagt till!");
        }
    }
}
