using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monads.Domain;
using Monads.Framework;

// ReSharper disable InconsistentNaming
namespace MonadTests
{
    [TestClass]
    public class MaybeMonadTests
    {
        [TestMethod]
        public void Add_5_to_Nothing_returns_Nothing()
        {
            var result = from x in 5.ToMaybe()
                    from y in Maybe<int>.Nothing
                    select x + y;

            Assert.AreEqual(result, Maybe<int>.Nothing);

            Console.Out.WriteLine(result.HasValue ? result.Value.ToString() : "Nothing");
        }

        [TestMethod]
        public void Add_5_to_3_returns_8()
        {
            var result = from x in 5.ToMaybe()
                    from y in 3.ToMaybe()
                    select x + y;

            Assert.AreEqual(result.Value, 8);

            Console.Out.WriteLine(result.HasValue ? result.Value.ToString() : "Nothing");
        }

        [TestMethod]
        public void Add_string_to_int_to_datetime_returns_string()
        {
            var today = DateTime.Now;

            var result = "Hello ".ToMaybe().Bind(       a =>
                2.ToMaybe().Bind(                       b =>
                " all of you today on ".ToMaybe().Bind( c =>
                today.ToMaybe().Bind(                   d =>
                (a + b + c + d.ToShortDateString())
                .ToMaybe()))));
                   

            Assert.AreEqual(result.Value, "Hello 2 all of you today on " + today.ToShortDateString());

            Console.Out.WriteLine(result.HasValue ? result.Value : "Nothing");
        }

        [TestMethod]
        public void Add_string_to_int_to_datetime_returns_string_linq_style()
        {
            var today = DateTime.Now;

            var result = from a in "Hello ".ToMaybe()
                    from b in 2.ToMaybe()
                    from c in " all of you today on ".ToMaybe()
                    from d in today.ToMaybe()
                    select a + b + c + d.ToShortDateString();

            Assert.AreEqual(result.Value, "Hello 2 all of you today on " + today.ToShortDateString());

            Console.Out.WriteLine(result.HasValue ? result.Value : "Nothing");
        }

        [TestMethod]
        public void Divide_12_by_2_by_2_returns_3()
        {
            var result = from a in 12.Div(2)
                         from b in a.Div(2)
                         select b;

            Assert.AreEqual(result.Value, 3);

            Console.Out.WriteLine(result);
        }

        [TestMethod]
        public void Divide_12_by_0_by_2_returns_Nothing()
        {
            var result = from a in "Result: ".ToMaybe()
                         from b in 12.Div(0)
                         from c in b.Div(2)
                         select a + c;

            Assert.AreEqual(result, Maybe<string>.Nothing);

            Console.Out.WriteLine(result);
        }
    }
}
