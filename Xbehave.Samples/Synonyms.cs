namespace Xbehave.Samples
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using Xbehave.Samples.Fixtures;
    using Xbehave.Sdk;

    public static class Synonyms
    {
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Fluent API")]
        public static IStepBuilder f(this string text, Action body)
        {
            return text.x(body);
        }

        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Fluent API")]
        public static IStepBuilder ʃ(this string text, Action body)
        {
            return text.x(body);
        }

        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Fluent API")]
        public static IStepBuilder σʃσ(this string text, Action body)
        {
            return text.x(body);
        }

        public static IStepBuilder 梟(this string text, Action body)
        {
            return text.x(body);
        }

        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Fluent API")]
        public static IStepBuilder χ(this string text, Action body)
        {
            return text.x(body);
        }

        [Scenario]
        public static void Addition(int x, int y, Calculator calculator, int answer)
        {
            "Given the number 1"
                .f(() => x = 1);

            "And the number 2"
                .ʃ(() => y = 2);

            "And a calculator"
                .σʃσ(() => calculator = new Calculator());

            "When I add the numbers together"
                .梟(() => answer = calculator.Add(x, y));

            "Then the answer is 3"
                .χ(() => answer.Should().Be(3));
        }
    }
}
