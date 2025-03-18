namespace SignalRWebpack.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
        Task<string> GetMessage();
    }
}
