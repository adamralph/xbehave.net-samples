// <copyright file="NCrunchCoverageIssue1.cs" company="xBehave.net contributors">
//  Copyright (c) xBehave.net contributors. All rights reserved.
// </copyright>

namespace Xbehave.Samples.NCrunchCoverageIssues
{
    using FluentAssertions;
    using Xbehave;

    public class NCrunchCoverageIssue1
    {
        [Scenario]
        public void TwoPassingSteps(int answer)
        {
            // NCrunch shows the expression in this step as uncovered
            "When I get an answer"
                .f(() => answer = new TwoPassingStepsSut().GetAnswer());

            // NCrunch shows the expression in this step as covered
            "Then the answer is 42"
                .f(() => answer.Should().Be(42));
        }

        [Scenario]
        public void OnePassingStep()
        {
            // NCrunch shows the expression in this step as covered
            "When I get an answer"
                .f(() => new OnePassingStepSut().GetAnswer());
        }

        public class TwoPassingStepsSut
        {
            // NCrunch shows this method as uncovered, presumably due to the first step expression being uncovered
            public int GetAnswer()
            {
                return 42;
            }
        }

        public class OnePassingStepSut
        {
            // NCrunch shows this method as covered, since the scenario is shown as fully covered
            public int GetAnswer()
            {
                return 42;
            }
        }
    }
}
