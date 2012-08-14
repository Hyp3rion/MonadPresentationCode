using System;

namespace Monads.Extensions
{
    public static class MonadicExtensions
    {
        public static TInput Do<TInput>(this TInput o, Action<TInput> action) where TInput : class
        {
            if (o == null) return null;
            action(o);
            return o;
        }

        public static TInput If<TInput>(this TInput o, Func<TInput, bool> evaluator)
            where TInput : class
        {
            if (o == null) return null;
            return evaluator(o) ? o : null;
        }

        public static TResult IfNotNull<TInput, TResult>(
            this TInput o, Func<TInput, TResult> evaluator)
            where TInput : class
            where TResult : class
        {
            return o == null ? null : evaluator(o);
        }

        public static TResult Return<TInput, TResult>(
            this TInput o, Func<TInput, TResult> evaluator, TResult failureValue)
            where TInput : class
        {
            return o == null ? failureValue : evaluator(o);
        }

        public static T WithDefault<T>(
            this T input, T failureValue)
            where T : class
        {
            return input ?? failureValue;
        }

        public static TResult WithValue<TInput, TResult>(this TInput value, Func<TInput, TResult> evaluator)
            where TInput : struct
        {
            return evaluator(value);
        }

        public static TInput GuardWith<TInput>(
            this TInput o, Exception failureException)
            where TInput : class
        {
            if (o == null)
            {
                throw failureException;
            }
            return o;
        }
    }
}