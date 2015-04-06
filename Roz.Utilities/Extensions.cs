using System;
using System.Collections.Generic;
using System.Linq;

namespace Roz.Utilities
{
    public static class Extensions
    {
        public static IQueryable<T> ToPage<T>(this IQueryable<T> items, int page, int pageSize) where T : class
        {
            if (page <= 0)
                page = 1;

            if (pageSize > 0)
            {
                items = items.Skip((page - 1) * pageSize).Take(pageSize);
            }
            return items;
        }

        /// <summary>
        /// Converts the current <see cref="string"/> value to a <see cref="Uri"/> equivalent.
        /// </summary>
        /// <param name="string">Current <see cref="string"/> value.</param>
        /// <returns><see cref="Uri"/> instance created from current<see cref="string"/> value. If the <see cref="string"/> value doesn't correspond with an <see cref="Uri"/> it returns null.</returns>
        public static Uri AsUri(this string @string)
        {
            Uri result;
            return Uri.TryCreate(@string, UriKind.RelativeOrAbsolute, out result) ? result : null;
        }

        /// <summary>
        /// Converts the caller <see cref="Uri"/> instance to a <see cref="string"/> equivalent.
        /// </summary>
        /// <param name="uri">Caller <see cref="Uri"/> instance.</param>
        /// <returns>Equivalent <see cref="string"/> value. If the caller <see cref="Uri"/> instance if null return an empty string.</returns>
        public static string AsString(this Uri uri)
        {
            return uri != (Uri)null ? uri.ToString() : String.Empty;
        }

        public static void IfNotNullOrElse<TItem>(this TItem item, Action<TItem> action, Action nullAction) where TItem : class
        {
            if ((object)item == null)
            {
                nullAction();
                return;

            }
            action(item);
        }

        public static void IfElementNotNullOrElse<TItem>(this IEnumerable<TItem> items, Action<TItem> action, Action nullAction) where TItem : class
        {
            if (items == null)
                return;
            foreach (TItem obj in items)
                obj.IfNotNullOrElse(action, nullAction);
        }


        public static void IfNull<TItem>(this TItem item, Action action) where TItem : class
        {
            if ((object)item != null)
                return;
            action();
        }

        public static void IfElementNull<TItem>(this IEnumerable<TItem> items, Action action) where TItem : class
        {
            if (items == null)
                return;
            foreach (TItem obj in items)
                obj.IfNull(action);
        }

        public static void IfElementNotNull<TItem>(this IEnumerable<TItem> items, Action<TItem> action) where TItem : class
        {
            if (items == null)
                return;
            foreach (TItem obj in items)
                obj.IfNotNull(action);
        }

        public static void IfFalse(this bool predicate, Action action)
        {
            if (predicate)
                return;
            action();
        }

        public static void IfTrue(this bool predicate, Action action)
        {
            if (predicate)
                action();
        }

        public static void IfTrueOrElse(this bool predicate, Action trueAction, Action elseAction)
        {
            if (predicate)
                trueAction();
            else
                elseAction();
        }

        public static void IfFalseOrElse(this bool predicate, Action falseAction, Action elseAction)
        {
            if (!predicate)
                falseAction();
            else
                elseAction();
        }

        public static void IfNotNull<TItem>(this TItem item, Action<TItem> action) where TItem : class
        {
            if ((object)item == null)
                return;
            action(item);
        }

        public static void ListenOnce(this object eventSource, string eventName, EventHandler handler)
        {
            var eventInfo = eventSource.GetType().GetEvent(eventName);
            EventHandler internalHandler = null;
            internalHandler = (src, args) =>
            {
                handler(src, args);
                eventInfo.RemoveEventHandler(eventSource, internalHandler);
            };
            eventInfo.AddEventHandler(eventSource, internalHandler);
        }

        public static void ListenOnce<TEventArgs>(this object eventSource, string eventName, EventHandler<TEventArgs> handler) where TEventArgs : EventArgs
        {
            var eventInfo = eventSource.GetType().GetEvent(eventName);
            EventHandler<TEventArgs> internalHandler = null;
            internalHandler = (src, args) =>
            {
                handler(src, args);
                eventInfo.RemoveEventHandler(eventSource, internalHandler);
            };
            eventInfo.AddEventHandler(eventSource, internalHandler);
        }

        public static void ListenUntil(this object eventSource, string eventName, bool stopCondition, EventHandler handler)
        {
            var eventInfo = eventSource.GetType().GetEvent(eventName);
            EventHandler internalHandler = null;
            internalHandler = (src, args) =>
            {
                if (stopCondition)
                    eventInfo.RemoveEventHandler(eventSource, internalHandler);
                else
                    handler(src, args);
            };
            eventInfo.AddEventHandler(eventSource, internalHandler);
        }

        public static void ListenUntil<TEventArgs>(this object eventSource, string eventName, bool stopCondition, EventHandler<TEventArgs> handler) where TEventArgs : EventArgs
        {
            var eventInfo = eventSource.GetType().GetEvent(eventName);
            EventHandler<TEventArgs> internalHandler = null;
            internalHandler = (src, args) =>
            {
                if (stopCondition)
                    eventInfo.RemoveEventHandler(eventSource, internalHandler);
                else
                    handler(src, args);
            };
            eventInfo.AddEventHandler(eventSource, internalHandler);
        }

        public static T Find<T>(this List<T> list, Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            foreach (T t in list)
            {
                if (match(t))
                    return t;
            }
            return default(T);
        }

        public static void ThrowIfNull<T>(this T obj, string param)
        {
            if (obj == null)
                throw new ArgumentNullException(param);
        }

        public static void ThrowIfNull(this string str, string param)
        {
            if (String.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException(param);
        }


        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }

        public static Type GetGenericBaseType(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            if (!type.IsGenericType)
            {
                return null;
            }
            Type[] args = type.GetGenericArguments();
            if (args.Length != 1)
            {
                throw new ArgumentOutOfRangeException("type", type.FullName + " isn't a Generic type with one argument -- e.g. T<U>");
            }
            return args[0];
        }
    }
}