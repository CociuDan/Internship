namespace GeekStore.Model.Infrastucture
{
    public class IDGenerator : IIDGenerator<int>
    {
        private static int _id = 1;

        public static int NextID()
        {
            return _id++;
        }

        int IIDGenerator<int>.NextID()
        {
            return NextID();
        }
    }
}
