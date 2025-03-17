using Microsoft.AspNetCore.SignalR;

namespace SignalRWebpack.Hubs
{
    public class ChatHub : Hub
    {
        public async Task newMessage(long username, string messsage) =>
            await Clients.All.SendAsync("messageReceived", username, messsage);
    }
}
