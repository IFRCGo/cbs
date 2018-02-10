/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Domain.RuleImplementations;
using Xunit;
using Events;
using FakeItEasy;
using Read.ProjectFeatures;

namespace Domain.Tests
{
    public class CreateProjectValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("\t")]
        [InlineData(" ")]
        public void NameIsNotValid_ShouldNotValidate(string name)
        {
            var projects = A.Fake<IProjects>();
            A.CallTo(() => projects.GetAll()).Returns(
                new[] { new Project { Name = "name" } }
            );

            var validator = new CreateProjectValidator(new ProjectRules(projects));
            var validationResult = validator.Validate(new CreateProject
            {
                Name = name
            });
            Assert.Contains(validationResult.Errors, e => e.ErrorMessage.Equals("Name is mandatory"));
        }

        [Fact]
        public void DataOwnerIsNotSet_ShouldNotValidate()
        {
            var projects = A.Fake<IProjects>();
            A.CallTo(() => projects.GetAll()).Returns(
                new[] { new Project { Name = "name" } }
            );

            var validator = new CreateProjectValidator(new ProjectRules(projects));
            var validationResult = validator.Validate(new CreateProject
            {
                Name = "name"
            });
            Assert.Contains(validationResult.Errors, e =>e.ErrorMessage.Equals("Data owner id is mandatory"));
        }

        [Fact]
        public void DataOwnerIsEmpty_ShouldNotValidate()
        {
            var projects = A.Fake<IProjects>();
            A.CallTo(() => projects.GetAll()).Returns(
                new[] { new Project { Name = "name" } }
            );

            var validator = new CreateProjectValidator(new ProjectRules(projects));
            var validationResult = validator.Validate(new CreateProject
            {
                Name = "name",
                DataOwnerId = Guid.Empty
            });
            Assert.Contains(validationResult.Errors, e => e.ErrorMessage.Equals("Data owner id is mandatory"));
        }

        [Fact]
        public void NationalSocietyIdIsEmpty_ShouldNotValidate()
        {
            var projects = A.Fake<IProjects>();
            A.CallTo(() => projects.GetAll()).Returns(
                new[] { new Project { Name = "name" } }
            );

            var validator = new CreateProjectValidator(new ProjectRules(projects));
            var validationResult = validator.Validate(new CreateProject
            {
                Name = "name",
                DataOwnerId = Guid.NewGuid(),
                NationalSocietyId = Guid.Empty
            });
            Assert.Contains(validationResult.Errors, e => e.ErrorMessage.Equals("National society id is mandatory"));
        }

        [Fact]
        public void SurveillanceContextIsEmpty_ShouldNotValidate()
        {
            var projects = A.Fake<IProjects>();
            A.CallTo(() => projects.GetAll()).Returns(
                new[] { new Project { Name = "name" } }
            );

            var validator = new CreateProjectValidator(new ProjectRules(projects));
            var validationResult = validator.Validate(new CreateProject
            {
                Name = "name",
                DataOwnerId = Guid.NewGuid(),
                NationalSocietyId = Guid.NewGuid(),
            });
            Assert.Contains(validationResult.Errors, e => e.ErrorMessage.Equals("Surveillance context is mandatory"));
        }

        [Fact]
        public void CreateProject_ShouldValidate()
        {
            var projects = A.Fake<IProjects>();
            A.CallTo(() => projects.GetAll()).Returns(
                new[] { new Project { Name = "name" } }
            );

            var validator = new CreateProjectValidator(new ProjectRules(projects));
            var validationResult = validator.Validate(new CreateProject
            {
                Name = "name2",
                DataOwnerId = Guid.NewGuid(),
                NationalSocietyId = Guid.NewGuid(),
                SurveillanceContext = ProjectSurveillanceContext.AggregateReports
            });
            Assert.True(validationResult.IsValid);
        }

        [Fact]
        public void ProjectNameMustBeUnique()
        {
            var projects = A.Fake<IProjects>();
            A.CallTo(() => projects.GetAll()).Returns(
                new[] {new Project { Name = "name"} }
            );

            var validator = new CreateProjectValidator(new ProjectRules(projects));
            var validationResult = validator.Validate(new CreateProject
            {
                Name = "name",
                DataOwnerId = Guid.NewGuid(),
                NationalSocietyId = Guid.NewGuid(),
                SurveillanceContext = ProjectSurveillanceContext.AggregateReports
            });
            Assert.False(validationResult.IsValid);
            Assert.Contains(validationResult.Errors, e => e.ErrorMessage.Equals("Project name is already in use"));
        }

    }
}
