using System;

namespace Monads.Framework
{
    public class Maybe<T>
    {
        public static readonly Maybe<T> Nothing = new Maybe<T>();
        public T Value { get; private set; }
        public bool HasValue { get; private set; }

        Maybe()
        {
            HasValue = false;
        }

        public Maybe(T value)
        {
            Value = value;
            HasValue = true;
        }

        public override string ToString()
        {
            return HasValue ? Value.ToString() : "Nothing";
        }
    }

    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<U> Bind<T, U>(this Maybe<T> m, Func<T, Maybe<U>> func)
        {
            return m.HasValue ? func(m.Value) : Maybe<U>.Nothing;
        }

        public static Maybe<C> SelectMany<A,B,C>(this Maybe<A> a, Func<A, Maybe<B>> func, Func<A,B,C> select)
        {
            return a.Bind(              aval => 
                func(aval).Bind(        bval => 
                select(aval, bval)
                .ToMaybe()));
        }
    }
}