using Monads.Framework;

namespace Monads.Domain
{
    public static class Calculator
    {
        public static Maybe<int> Div(this int numerator, int denominator)
        {
            return denominator == 0
                ? Maybe<int>.Nothing
                : new Maybe<int>(numerator/denominator);
        }
    }
}