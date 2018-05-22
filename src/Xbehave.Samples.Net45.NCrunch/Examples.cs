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
                .x(() => { });

            "And the number {1}"
                .x(() => { });

            "And a calculator"
                .x(() => calculator = new Calculator());

            "When I add the numbers together"
                .x(() => answer = calculator.Add(x, y));

            "Then the answer is {2}"
                .x(() => answer.Should().Be(expectedAnswer));
        }
    }
}
