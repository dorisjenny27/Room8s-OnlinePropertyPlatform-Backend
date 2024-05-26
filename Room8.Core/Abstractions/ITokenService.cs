namespace Room8.Core.Abstractions
{
    public interface ITokenService
    {
        string GenerateJwtToken(string userId);
    }
}
