namespace Xbehave.Samples
{
    using FluentAssertions;
    using Xbehave;
    using Xbehave.Samples.Fixtures;

    public class SkippedScenarios
    {
        [Scenario(Skip = "It's no good, I just can't figure out addition today.")]
        public void Addition(int x, int y, Calculator calculator, int answer)
        {
            "Given the number 1"
                .x(() => x = 1);

            "And the number 2"
                .x(() => y = 2);

            "And a calculator"
                .x(() => calculator = new Calculator());

            "When I add the numbers together"
                .x(() => answer = calculator.Add(x, y));

            "Then the answer is 3"
                .x(() => answer.Should().Be(3));
        }
    }
}
