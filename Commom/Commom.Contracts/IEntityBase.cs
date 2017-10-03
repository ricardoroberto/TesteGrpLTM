namespace Commom.Contracts
{
    public interface IEntityBase<BaseType>
    {
        BaseType Id { get; set; }
    }
}
