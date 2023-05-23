namespace Grpc_JSON.Helper
{
    public class Target
    {
        public string Id { get; set; }
        public int Count { get; set; }

        public Target(string id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}
