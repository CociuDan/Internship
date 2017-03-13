namespace GeekStore.Model.Infrastucture
{
    public interface IIDGenerator<TID>
    {
        TID NextID();
    }
}
