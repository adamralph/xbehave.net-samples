// <copyright file="NCrunchCoverageIssue3.cs" company="xBehave.net contributors">
//  Copyright (c) xBehave.net contributors. All rights reserved.
// </copyright>

namespace Xbehave.Samples.NCrunchCoverageIssues
{
    using FluentAssertions;
    using Xbehave;

    public class NCrunchCoverageIssue3
    {
        [Scenario]
        public void OnePassingStepAndOneFailingStep(int answer)
        {
            // NCrunch shows this step as uncovered
            // Note that this is only the case when another scenario exists in the class
            // if you comment out OnePassingStep then the step is shown as failing
            // but the step expression is still shown as uncovered
            "Given true is true"
                .f(() => true.Should().BeTrue());

            // NCrunch shows this step as uncovered but the step expression as failing
            // Note that this is only the case when another scenario exists in the class
            // if you comment out OnePassingStep then the step is shown as failing
            "Then true is false"
                .f(() => true.Should().BeFalse());
        }

        [Scenario]
        public void OnePassingStep(int answer)
        {
            // NCrunch shows this step expression as passing but the step as failing
            // also the scenario method closing brace is shown as failing
            "Given true is true"
                .f(() => true.Should().BeTrue());
        }
    }
}
