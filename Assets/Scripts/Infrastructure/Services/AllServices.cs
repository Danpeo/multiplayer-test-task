namespace Infrastructure.Services
{
    public class AllServices
    {
        private static AllServices _instance;
        public static AllServices Container => _instance ??= new AllServices();

        public void RegisterSingle<TypeService>(TypeService implementation) where TypeService : IService => 
            Implementation<TypeService>.ServiceInstance = implementation;

        public TypeService Single<TypeService>() where TypeService : IService => 
            Implementation<TypeService>.ServiceInstance;

        private static class Implementation<TypeService>
        {
            public static TypeService ServiceInstance;
        }
    }
}