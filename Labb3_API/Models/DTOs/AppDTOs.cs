namespace Labb3_API.Models.DTOs
{
    public record GetPersonResponse(int Id, string Name, string Phone);
    //public record GetInterestResponse(int Id, string Title);

    public record GetInterestResponse(int Id, string Title, string Description);
    
    public record GetLinkResponse(int Id, string Url);

    public record AddInterestToPersonRequst (int InterestId);

    public record AddLinkRequest(int PersonId, int InterestId, string Url);
}
