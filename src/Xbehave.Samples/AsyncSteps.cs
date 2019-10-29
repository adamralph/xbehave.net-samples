namespace Xbehave.Samples
{
    using FluentAssertions;
    using Xbehave;
    using Xbehave.Samples.Fixtures;

    public class AsyncSteps
    {
        [Scenario]
        public void Addition(int x, int y, Calculator calculator, int answer)
        {
            "Given the number 1"
                .x(() => x = 1);

            "And the number 2"
                .x(() => y = 2);

            "And a calculator"
                .x(() => calculator = new Calculator());

            "When I add the numbers together"
                .x(async () => answer = await calculator.AddAsync(x, y));

            "Then the answer is 3"
                .x(() => answer.Should().Be(3));
        }
    }
}
