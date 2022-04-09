using Shared.Interfaces;

namespace Shared.Entities;

public class Filter<T>: IFilter<T>
{
    public List<T> Filtering(List<T> items, ISpecification<T> spec)
    {
        List<T> results = new List<T>();
        foreach (var item in items)
        {
            if (spec.isSatisfied(item)) results.Add(item);
        }
        return results;
    }
} 