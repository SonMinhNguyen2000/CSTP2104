namespace Shared.Interfaces;

public interface ISpecification<T>
{
    bool isSatisfied(T t);
}