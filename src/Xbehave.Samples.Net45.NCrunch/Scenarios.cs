namespace Xbehave.Samples
{
    using FluentAssertions;
    using Xbehave;
    using Xbehave.Samples.Fixtures;

    public class Scenarios
    {
        [Scenario]
        public void Addition(int x, int y, Calculator calculator, int answer)
        {
            "Given the number 1"
                .f(() => x = 1);

            "And the number 2"
                .f(() => y = 2);

            "And a calculator"
                .f(() => calculator = new Calculator());

            "When I add the numbers together"
                .f(() => answer = calculator.Add(x, y));

            "Then the answer is 3"
                .f(() => answer.Should().Be(3));
        }

        [Scenario]
        public void EmptyScenario()
        {
            true.Should().Be(true);
        }
    }
}
