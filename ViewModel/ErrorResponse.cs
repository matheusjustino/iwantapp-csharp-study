namespace IWantApp.ViewModel;

using System.Text.Json;

public class ErrorResponse
{
    public string Message { get; set; }

    public string Endpoint { get; set; }

    public int StatusCode { get; set; }

    public DateTime Timestamp { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
