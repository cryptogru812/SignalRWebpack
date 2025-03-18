using Microsoft.AspNetCore.SignalR;

namespace SignalRWebpack.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(string user, string message) =>
            await Clients.All.ReceiveMessage(user, message);

        public async Task SendMessageToCaller(string user, string message) =>
            await Clients.Caller.ReceiveMessage(user, message);

        public async Task SendMessageToGroup(string user, string message) =>
            await Clients.Group("SignalR Users").ReceiveMessage(user, message);

        [HubMethodName("SendMessageToUser")]
        public async Task DirectMessage(string user, string message) =>
            await Clients.Users(user).ReceiveMessage(user, message);

        public async Task<string> WaitForMessage(string connectionId)
        {
            var message = await Clients.Client(connectionId).GetMessage();
            return message;
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
