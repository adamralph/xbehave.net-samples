namespace Xbehave.Samples
{
    using FluentAssertions;
    using Xbehave;
    using Xbehave.Samples.Fixtures;

    public static class TheLot
    {
        private static Calculator calculator;

        [Background]
        public static void Background()
        {
            "Given a stack"
                .f(() => calculator = new Calculator())
                .Teardown(() => calculator.CoolDown());
        }

        [Scenario]
        [Example(1, 2, 3)]
        [Example(2, 3, 5)]
        public static void Addition(int x, int y, int expectedAnswer, Calculator calculator, int answer)
        {
            "Given the number {0}"
                .f(() => { });

            "And the number {1}"
                .f(() => { });

            "And a calculator"
                .f(() => calculator = new Calculator());

            "And some disposable object"
                .f(c => new Disposable().Using(c));

            "When I add the numbers together"
                .f(async () => answer = await calculator.AddAsync(x, y));

            "Then the answer is {2}"
                .f(() => answer.Should().Be(expectedAnswer));

            "And the answer is one more than {2}"
                .f(() => answer.Should().Be(expectedAnswer + 1))
                .Skip("because the assertion is nonsense");

            "But the answer is not one less than {2}"
                .f(() => answer.Should().NotBe(expectedAnswer - 1));
        }
    }
}
