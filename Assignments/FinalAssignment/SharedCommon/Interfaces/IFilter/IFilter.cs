namespace Shared.Interfaces;

public interface IFilter<T>
{
    List<T> Filtering(List<T> items, ISpecification<T> spec);
}