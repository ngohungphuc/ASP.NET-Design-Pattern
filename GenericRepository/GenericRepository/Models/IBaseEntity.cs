namespace GenericRepository.Models
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}