using System;
using System.Linq;
using Xunit;
using FakeItEasy;
using Read.ProjectFeatures;
using Domain;

namespace Domain.Tests
{
    public class SetProjectHealthRiskThresholdValidatorTests
    {
        [Fact]
        public void HealthRiskBelongsToProject_ShouldValidate()
        {
            var projectId = Guid.NewGuid();
            var healthRiskId = Guid.NewGuid();

            var projects = A.Fake<IProjects>();
            A.CallTo(() => projects.GetById(A<Guid>._)).Returns(
                new Project()
                {
                    Id = projectId,
                    HealthRisks = new ProjectHealthRisk[]
                    {
                        new ProjectHealthRisk() { HealthRiskId = healthRiskId, Threshold = 1 }
                    }
                }
            );

            var validator = new SetProjectHealthRiskThresholdValidator(projects);
            var validationResult = validator.Validate(new SetProjectHealthRiskThreshold() { ProjectId = projectId, HealthRiskId = healthRiskId, Threshold = 2 });
            Assert.False(validationResult.Errors.Any(), "The command should validate when health risk belongs to project");
        }

        [Fact]
        public void HealthRiskThatDoesntBelongToProject_ShouldNotValidate()
        {
            var projectId = Guid.NewGuid();
            var healthRiskId = Guid.NewGuid();
            var anotherHealthRiskId = Guid.NewGuid();

            var projects = A.Fake<IProjects>();
            A.CallTo(() => projects.GetById(A<Guid>._)).Returns(
                new Project()
                {
                    Id = projectId,
                    HealthRisks = new ProjectHealthRisk[]
                    {
                        new ProjectHealthRisk() { HealthRiskId = healthRiskId, Threshold = 1 }
                    }
                }
            );

            var validator = new SetProjectHealthRiskThresholdValidator(projects);
            var validationResult = validator.Validate(new SetProjectHealthRiskThreshold() { ProjectId = projectId, HealthRiskId = anotherHealthRiskId, Threshold = 2 });
            Assert.True(validationResult.Errors.Any(), "The command should NOT validate when health risk does not belongs to project");
        }

        [Theory]
        [InlineData(-15, false)]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(15, true)]
        public void NegativeThreshold_OnlyPositiveThresholdShouldValidate(int threshold, bool shouldValidate)
        {
            var projectId = Guid.NewGuid();
            var healthRiskId = Guid.NewGuid();

            var projects = A.Fake<IProjects>();
            A.CallTo(() => projects.GetById(A<Guid>._)).Returns(
                new Project()
                {
                    Id = projectId,
                    HealthRisks = new ProjectHealthRisk[]
                    {
                        new ProjectHealthRisk() { HealthRiskId = healthRiskId, Threshold = 1 }
                    }
                }
            );

            var validator = new SetProjectHealthRiskThresholdValidator(projects);
            var validationResult = validator.Validate(new SetProjectHealthRiskThreshold() { ProjectId = projectId, HealthRiskId = healthRiskId, Threshold = threshold });
            Assert.Equal(shouldValidate, !validationResult.Errors.Any());
        }
    }
}
