using System.Text.RegularExpressions;
using System.Threading.Channels;
using WRMC.Infrastructure.Domain.Entities;

namespace WRMC.Infrastructure.DataAccess.Extensions;

public static class LinqExtensions
{
    public static IEnumerable<T> GetChildFlatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector)
    {
        var queue = new Queue<T>(source);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            yield return current;
            var children = childrenSelector(current);
            if (children == null) continue;
            foreach (var child in children) queue.Enqueue(child);
        }
    }



    public static IEnumerable<T> Flatten11<T>(
    this IEnumerable<T> source,
    Func<T, IEnumerable<T>> childSelector)
    {
        HashSet<T> added = new HashSet<T>();
        Queue<T> queue = new Queue<T>();
        foreach (T t in source)
            if (added.Add(t))
                queue.Enqueue(t);
        while (queue.Count > 0)
        {
            T current = queue.Dequeue();
            yield return current;
            if (current != null)
            {
                IEnumerable<T> children = childSelector(current);
                if (children != null)
                    foreach (T t in childSelector(current))
                        if (added.Add(t))
                            queue.Enqueue(t);
            }
        }
    }


    public static IEnumerable<T> ByHierarchy<T>(
 this IEnumerable<T> source, Func<T, bool> startWith, Func<T, T, bool> connectBy)
    {
        if (source == null)
            throw new ArgumentNullException("source");

        if (startWith == null)
            throw new ArgumentNullException("startWith");

        if (connectBy == null)
            throw new ArgumentNullException("connectBy");

        foreach (T root in source.Where(startWith))
        {
            yield return root;
            foreach (T child in source.ByHierarchy(c => connectBy(root, c), connectBy))
            {
                yield return child;
            }
        }
    }




    public static IEnumerable<TR> Recur<T, TR>(
    this IEnumerable<T> source,
    Func<T, bool> filter,
    Func<T, IEnumerable<T>> recursor,
    Func<T, IEnumerable<T>, TR> resultor)
    {
        foreach (var t in source)
            if (filter(t))
                yield return resultor(t, recursor(t));
    }


    public static IEnumerable<T> Flatten<T>(this IEnumerable<T> e, Func<T, IEnumerable<T>> f)
    {
       return e.SelectMany(c => f(c).Flatten(f)).Concat(e);
    }
    public static IEnumerable<Tuple<T, int>> ToLeveled<T>(this IEnumerable<T> source, int level)
    {
        if (source == null)
        {
            return null;
        }
        else
        {
            return source.Select(item => new Tuple<T, int>(item, level));
        }
    }


    public static IEnumerable<Section> EnumerateChildren(this Section parent)
    {
        if (parent.Sections != null)
        {
            foreach (var g in parent.Sections)
            {
                yield return g;

                foreach (var sub in EnumerateChildren(g))
                {
                    yield return sub;
                }
            }
        }
    }




    public static IEnumerable<T> DepthFirstTreeTraversal<T>(this T root, Func<T, IEnumerable<T>> children)
    {
        var stack = new Stack<T>();
        stack.Push(root);
        while (stack.Count != 0)
        {
            var current = stack.Pop();
            // If you don't care about maintaining child order then remove the Reverse.
            foreach (var child in children(current).Reverse())
                stack.Push(child);
            yield return current;
        }
    }

   

    public static  IEnumerable<T> GetAncestors<T>(this T source, Func<T, T> parentOf)
    {
        var Parent = parentOf(source);
        while (Parent != null)
        {
            yield return Parent;
            Parent = parentOf(Parent);
        }
    }


}