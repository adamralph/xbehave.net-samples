// <copyright file="Failures.cs" company="xBehave.net contributors">
//  Copyright (c) xBehave.net contributors. All rights reserved.
// </copyright>

namespace Xbehave.Samples
{
    using System;
    using System.Reflection;
    using FluentAssertions;
    using Xbehave;
    using Xunit.Sdk;

    public class Failures
    {
        [Scenario]
        public void FailingScenario()
        {
            true.Should().Be(false);
        }

        [Scenario]
        public void FailingStep()
        {
            "Given true is false"
                .f(() => true.Should().Be(false));
        }

        [Scenario]
        public void PassingStepAndFailingStep()
        {
            "Given true is true"
                .f(() => true.Should().Be(true));

            "Then true is false"
                .f(() => true.Should().Be(false));
        }

        [Scenario]
        public void FailingStepAndPassingStep()
        {
            "Given true is false"
                .f(() => true.Should().Be(false));

            "Then true is true"
                .f(() => true.Should().Be(true));
        }

        [Scenario]
        public void FailingDisposal()
        {
            "Given a failing disposable"
                .f(c => new FailingDisposable().Using(c));
        }

        [Scenario]
        public void FailingTeardown()
        {
            "Given a fixture which believes true is false"
                .f(c => { })
                .Teardown(() => true.Should().BeFalse());
        }

        [Scenario]
        [FailingBefore]
        public void FailingBefore()
        {
        }

        [Scenario]
        [FailingAfter]
        public void FailingAfter()
        {
        }

        public class FailingFeatureClass
        {
            public FailingFeatureClass()
            {
                true.Should().BeFalse();
            }

            [Scenario]
            public void SomeScenario()
            {
            }
        }

        public sealed class FailingDisposable : IDisposable
        {
            public void Dispose()
            {
                true.Should().BeFalse();
            }
        }

        public class FailingBeforeAttribute : BeforeAfterTestAttribute
        {
            public override void Before(MethodInfo methodUnderTest)
            {
                true.Should().BeFalse();
            }
        }

        public class FailingAfterAttribute : BeforeAfterTestAttribute
        {
            public override void After(MethodInfo methodUnderTest)
            {
                true.Should().BeFalse();
            }
        }
    }
}
