namespace OES.API.Application.Features.Queries.AppUser.GetUserDetails
{
    public class GetUserDetailsQueryResponse
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; }
        public string? WebAddressUrl { get; set; }
    }
}