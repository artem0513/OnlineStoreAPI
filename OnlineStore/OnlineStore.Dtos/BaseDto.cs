namespace OnlineStore.Dtos
{
    public class BaseDto<TId>
    {
        public required TId Id { get; set; }
    }
}
