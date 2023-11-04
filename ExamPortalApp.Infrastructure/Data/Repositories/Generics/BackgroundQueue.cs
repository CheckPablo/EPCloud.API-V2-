using ExamPortalApp.Contracts.Data.Repositories.Generic;
using System.Collections.Concurrent;

namespace ExamPortalApp.Infrastructure.Data.Repositories.Generics
{
    public class BackgroundQueue<T> : IBackgroundQueue<T> where T : class
    {
        private readonly ConcurrentQueue<T> _items = new ConcurrentQueue<T>();

        public void Enqueue(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            _items.Enqueue(item);
        }

        public T? Dequeue()
        {
            var success = _items.TryDequeue(out var workItem);

            if (workItem == null) return null;

            return success
                ? workItem
                : null;
        }
    }
}
