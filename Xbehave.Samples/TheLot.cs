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
                .x(() => calculator = new Calculator())
                .Teardown(() => calculator.CoolDown());
        }

        [Scenario]
        [Example(1, 2, 3)]
        [Example(2, 3, 5)]
        public static void Addition(int x, int y, int expectedAnswer, Calculator calculator, int answer)
        {
            "Given the number {0}"
                .x(() => { });

            "And the number {1}"
                .x(() => { });

            "And a calculator"
                .x(() => calculator = new Calculator());

            "And some disposable object"
                .x(c => new Disposable().Using(c));

            "When I add the numbers together"
                .x(async () => answer = await calculator.AddAsync(x, y));

            "Then the answer is {2}"
                .x(() => answer.Should().Be(expectedAnswer));

            "And the answer is one more than {2}"
                .x(() => answer.Should().Be(expectedAnswer + 1))
                .Skip("because the assertion is nonsense");

            "But the answer is not one less than {2}"
                .x(() => answer.Should().NotBe(expectedAnswer - 1));
        }
    }
}
