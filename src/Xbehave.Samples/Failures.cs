namespace Xbehave.Samples
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using FluentAssertions;
    using Xbehave;
    using Xunit;
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
                .x(() => true.Should().Be(false));
        }

        [Scenario]
        public void PassingStepAndFailingStep()
        {
            "Given true is true"
                .x(() => true.Should().Be(true));

            "Then true is false"
                .x(() => true.Should().Be(false));
        }

        [Scenario]
        public void FailingStepAndPassingStep()
        {
            "Given true is false"
                .x(() => true.Should().Be(false));

            "Then true is true"
                .x(() => true.Should().Be(true));
        }

        [Scenario]
        public void FailingDisposal()
        {
            "Given a failing disposable"
                .x(c => new FailingDisposable().Using(c));
        }

        [Scenario]
        public void FailingTeardown()
        {
            "Given a fixture which believes true is false"
                .x(c => { })
                .Teardown(() => true.Should().BeFalse());
        }

        [Scenario]
        [FailingBefore]
        public void FailingBefore()
        {
            "Given true is true"
                .x(() => true.Should().Be(true));
        }

        [Scenario]
        [FailingAfter]
        public void FailingAfter()
        {
            "Given true is true"
                .x(() => true.Should().Be(true));
        }

        [Scenario]
        [FailingBefore]
        public void FailingBeforeEmptyScenario()
        {
        }

        [Scenario]
        [FailingAfter]
        public void FailingAfterEmptyScenario()
        {
        }

        [Scenario]
        [BadExample]
        public void FailedDiscovery()
        {
            "Given true is true"
                .x(() => true.Should().Be(true));
        }

        [Scenario]
        [BadExample]
        public void FailedDiscoveryForAnEmptyScenario()
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

        public sealed class BadExampleAttribute : MemberDataAttributeBase
        {
            public BadExampleAttribute()
                : base("Dummy", new object[0])
            {
            }

            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
            {
                throw new NotImplementedException();
            }

            protected override object[] ConvertDataItem(MethodInfo testMethod, object item)
            {
                throw new NotImplementedException();
            }
        }
    }
}
