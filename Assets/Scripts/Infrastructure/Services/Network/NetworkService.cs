using Mirror;

namespace Infrastructure.Services.Network
{
    public class NetworkService : NetworkBehaviour
    {
        public static bool IsHost { get; set; }
        
        public static string PlayerName { get; set; }

        public static void StartHost() => 
            IsHost = true;

        public static void StartClient() => 
            IsHost = false;
    }
}