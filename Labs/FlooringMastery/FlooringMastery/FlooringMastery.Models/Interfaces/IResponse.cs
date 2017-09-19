namespace FlooringMastery.Models
{
    public interface IResponse
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}