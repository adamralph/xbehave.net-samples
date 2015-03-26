// <copyright file="NCrunchCoverageIssue2.cs" company="xBehave.net contributors">
//  Copyright (c) xBehave.net contributors. All rights reserved.
// </copyright>

namespace Xbehave.Samples.NCrunchCoverageIssues
{
    using FluentAssertions;
    using Xbehave;

    public class NCrunchCoverageIssue2
    {
        [Scenario]
        public void OnePassingStepAndOneFailingStep(int answer)
        {
            // NCrunch shows this step as failing when it actually passes
            "Given true is true"
                .f(() => true.Should().BeTrue());

            // NCrunch shows this step as failing, as it should
            "Then true is false"
                .f(() => true.Should().BeFalse());
        }
    }
}
