// <copyright file="SkippedScenarios.cs" company="xBehave.net contributors">
//  Copyright (c) xBehave.net contributors. All rights reserved.
// </copyright>

namespace Xbehave.Samples
{
    using FluentAssertions;
    using Xbehave;
    using Xbehave.Samples.Fixtures;
    using Xunit;

    public class SkippedScenarios
    {
        [Scenario(Skip = "It's no good, I just can't figure out addition today.")]
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
    }
}
