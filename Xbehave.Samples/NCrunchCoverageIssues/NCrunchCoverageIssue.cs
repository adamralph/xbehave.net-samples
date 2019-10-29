namespace Xbehave.Samples.NCrunchCoverageIssues
{
    using FluentAssertions;
    using Xbehave;

    // As per NCrunch preview build 2.14.0.5, this is the only identified coverage issue.
    // Note that if the pass/fail indicators are assumed to be set for a scenario as whole then they are correct.
    // They are only 'incorrect' if the expectation is that they are set independently for each step.
    public class NCrunchCoverageIssue
    {
        [Scenario]
        public void OnePassingStepAndOneFailingStep(int answer)
        {
            // NCrunch marks the step definition as failing - INCORRECT
            // NCrunch marks the step delegate as failing - INCORRECT
            "Given true is true"
                .x(() => true.Should().BeTrue());

            // NCrunch marks the step definition as failing - INCORRECT
            // NCrunch marks the step delegate as failing - CORRECT
            // NCrunch marks the second statement of the delegate as the exception source - CORRECT
            "Then true is false"
                .x(() =>
                {
                    true.Should().BeTrue();
                    true.Should().BeFalse();
                });

            // NCrunch marks the step definition as failing - INCORRECT
            // NCrunch marks the step delegate as uncovered - CORRECT
            "And true is true"
                .x(() => true.Should().BeTrue());
        }
    }
}
