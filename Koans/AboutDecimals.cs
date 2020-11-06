using DotNetCoreKoans.Engine;
using Xunit;

namespace DotNetCoreKoans.Koans
{
    public class AboutDecimals : Koan
    {
        [Step(1)]
        public void UnquotedNumbersEndingInMAreDecimals()
        {
            var d = 1m;

            Assert.Equal(typeof(decimal), d.GetType());
        }

        [Step(2)]
        public void DecimalsAndIntsCanPlayNice()
        {
            //Decimals have achieved zen when working with integers.
            //(Thanks to C#'s automatic conversion between
            //decimals and whole numbers)
            decimal d = 5.2m;
            int n = 7;

            var result = d + n;

            Assert.Equal(12.2m, result);

            // Notice that the result is a decimal when you do this

            // Okay, great, but will it work with int+decimal tho
            var newResult = n + d;
            Assert.Equal(12.2m, newResult);
            // yea, it would, that's wonderful,
            // but floats aren't that great then
        }

        [Step(3)]
        public void DecimalsAndOtherFloatingPointTypesDoNotPlayNice()
        {
            //Since C# will not automatically convert between these types,
            //decimals have not achieved zen when working with other
            //floating point types (you must manually cast others in
            //order to perform arithmetic and achieve zen)
            decimal d = 5.1m;
            float f = 4.2f;
            double db = 7.4d;

            var result = 0m;
            result = d + (decimal)f;
            Assert.Equal(9.3m, result);

            result = d + (decimal)db;
            Assert.Equal(12.5m, result);
        }

        [Step(4)]
        public void DecimalsHaveMaximumAndMinimumValues()
        {
            // Even the zen of the decimal has its limits...
            Assert.Throws(typeof(System.FormatException), () =>
            {
                // TODO this throws System.FormatException not because
                // it's too big, but because of commas
                // formatting below is correct
                //
                // var d = decimal.Parse("-79 228 162 514 264 337 593 543 950 336");
                var d = decimal.Parse("79,228,162,514,264,337,593,543,950,336");
            });

            Assert.Throws(typeof(System.FormatException), () =>
            {
                var d = decimal.Parse("-79,228,162,514,264,337,593,543,950,336");
            });

            // TODO also i could throw those in
            // just for context above throw examples 
            Assert.Equal(decimal.MinValue,
                         decimal.Parse("-79 228 162 514 264 337 593 543 950 335"));
            Assert.Equal(decimal.MaxValue,
                         decimal.Parse("79 228 162 514 264 337 593 543 950 335"));
        }

        [Step(5)]
        public void DecimalsHaveLimitedPrecision()
        {
            var twentyEightDigits = 0.9999999999999999999999999999m;
            var twentyNineDigits = 0.99999999999999999999999999999m;

            Assert.Equal(0.9999999999999999999999999999m, twentyEightDigits);
            Assert.Equal(1, twentyNineDigits);

            //Decimals use 128 bits to store their data, therefore they can store
            //up to 28 significant digits
        }

        [Step(6)]
        public void DecimalMathBehavesWell()
        {
            var d = 0.1m;
            var result = d + d + d + d + d + d + d;

            Assert.Equal(result, 0.7m);

            //The zen of the decimal is quite exceptional indeed. Unlike
            //floats, they are able to handle math the way humans expect. 
        }
    }
}