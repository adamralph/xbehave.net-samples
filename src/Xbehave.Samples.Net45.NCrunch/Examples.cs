namespace Xbehave.Samples
{
    using FluentAssertions;
    using Xbehave;
    using Xbehave.Samples.Fixtures;

    public class Examples
    {
        [Scenario]
        [Example(1, 2, 3)]
        [Example(2, 3, 5)]
        public void Addition(int x, int y, int expectedAnswer, Calculator calculator, int answer)
        {
            "Given the number {0}"
                .f(() => { });

            "And the number {1}"
                .f(() => { });

            "And a calculator"
                .f(() => calculator = new Calculator());

            "When I add the numbers together"
                .f(() => answer = calculator.Add(x, y));

            "Then the answer is {2}"
                .f(() => answer.Should().Be(expectedAnswer));
        }
    }
}
