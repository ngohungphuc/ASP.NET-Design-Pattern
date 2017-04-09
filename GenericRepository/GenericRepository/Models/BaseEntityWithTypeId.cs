namespace GenericRepository.Models
{
    /// <summary>
    /// This will be base class for model since all of entities will have Id column
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseEntityWithTypeId<T> : IBaseEntity<T>
    {
        public T Id { get; set; }
    }
}