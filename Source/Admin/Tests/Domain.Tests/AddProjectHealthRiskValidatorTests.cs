/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using Domain.RuleImplementations;
using FakeItEasy;
using Read.HealthRiskFeatures;
using Read.ProjectFeatures;
using Xunit;

namespace Domain.Tests
{
    public class AddProjectHealthRiskValidatorTests
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(6, false)]
        public void ProjectCannotHaveMoreThanFiveHealthRisks(int numberOfRisks, bool shouldValidate)
        {
            var projects = A.Fake<IProjects>();
            var projectId = Guid.NewGuid();

            A.CallTo(() => projects.GetById(A<Guid>._)).Returns(
                new Project
                {
                    Id = projectId,
                    HealthRisks = new List<ProjectHealthRisk>(Enumerable.Repeat(new ProjectHealthRisk {HealthRiskId = Guid.NewGuid()}, numberOfRisks)).ToArray()
                }
            );

            var healthRisks = A.Fake<IHealthRisks>();
            A.CallTo(() => healthRisks.GetById(A<Guid>._)).Returns(
                new HealthRisk());

            IProjectHealthRiskRules projectHealthRiskRules = new ProjectHealthRiskRules(projects, healthRisks);
            var validator = new AddProjectHealthRiskValidator(projectHealthRiskRules);
            var validationResult = validator.Validate(new AddProjectHealthRisk());
            Assert.Equal(shouldValidate, validationResult.IsValid);
        }

        [Fact]
        public void ProjectCannotHaveSameHealthRiskTwice()
        {
            var projects = A.Fake<IProjects>();
            var projectId = Guid.NewGuid();
            Guid healthRiskId = Guid.NewGuid();

            A.CallTo(() => projects.GetById(A<Guid>._)).Returns(
                new Project
                {
                    Id = projectId,
                    HealthRisks = new[] { new ProjectHealthRisk() { HealthRiskId = healthRiskId }, }
                }
            );

            var healthRisks = A.Fake<IHealthRisks>();
            A.CallTo(() => healthRisks.GetById(A<Guid>._)).Returns(
                 new HealthRisk()
            );

            IProjectHealthRiskRules projectHealthRiskRules = new ProjectHealthRiskRules(projects, healthRisks);
            var validator = new AddProjectHealthRiskValidator(projectHealthRiskRules);
            var validationResult = validator.Validate(new AddProjectHealthRisk { HealthRiskId = healthRiskId, ProjectId = projectId });
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void ProjectCannotAddNotExistingHealthRisk()
        {
            var projects = A.Fake<IProjects>();
            var projectId = Guid.NewGuid();

            A.CallTo(() => projects.GetById(A<Guid>._)).Returns(
                new Project
                {
                    Id = projectId,
                }
            );

            var healthRisks = A.Fake<IHealthRisks>();
            A.CallTo(() => healthRisks.GetById(A<Guid>._)).Returns(
                null
            );

            IProjectHealthRiskRules projectHealthRiskRules = new ProjectHealthRiskRules(projects, healthRisks);
            var validator = new AddProjectHealthRiskValidator(projectHealthRiskRules);
            var validationResult = validator.Validate(new AddProjectHealthRisk { HealthRiskId = Guid.NewGuid(), ProjectId = projectId });
            Assert.False(validationResult.IsValid);
        }
    }
}
