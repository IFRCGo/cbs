/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using Xunit;
using Events;

namespace Domain.Tests
{
    public class UpdateProjectValidatorTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("\t")]
        [InlineData(" ")]
        public void NameIsNotValid_ShouldNotValidate(string name)
        {
            var validator = new UpdateProjectValidator();
            var validationResult = validator.Validate(new UpdateProject
            {
                Name = name
            });
            Assert.Contains(validationResult.Errors, e => e.ErrorMessage.Equals("Name is mandatory"));
        }

        [Fact]
        public void DataOwnerIsNotSet_ShouldNotValidate()
        {
            
            var validator = new UpdateProjectValidator();
            var validationResult = validator.Validate(new UpdateProject
            {
                Name = "name"
            });
            Assert.Contains(validationResult.Errors, e =>e.ErrorMessage.Equals("Data owner id is mandatory"));
        }

        [Fact]
        public void DataOwnerIsEmpty_ShouldNotValidate()
        {

            var validator = new UpdateProjectValidator();
            var validationResult = validator.Validate(new UpdateProject
            {
                Name = "name",
                DataOwnerId = Guid.Empty
            });
            Assert.Contains(validationResult.Errors, e => e.ErrorMessage.Equals("Data owner id is mandatory"));
        }

        [Fact]
        public void NationalSocietyIdIsEmpty_ShouldNotValidate()
        {

            var validator = new UpdateProjectValidator();
            var validationResult = validator.Validate(new UpdateProject
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

            var validator = new UpdateProjectValidator();
            var validationResult = validator.Validate(new UpdateProject
            {
                Name = "name",
                DataOwnerId = Guid.NewGuid(),
                NationalSocietyId = Guid.NewGuid(),
            });
            Assert.Contains(validationResult.Errors, e => e.ErrorMessage.Equals("Surveillance context is mandatory"));
        }

        [Fact]
        public void UpdateProject_ShouldValidate()
        {

            var validator = new UpdateProjectValidator();
            var validationResult = validator.Validate(new UpdateProject
            {
                Name = "name",
                DataOwnerId = Guid.NewGuid(),
                NationalSocietyId = Guid.NewGuid(),
                SurveillanceContext = ProjectSurveillanceContext.AggregateReports
            });
            Assert.False(validationResult.Errors.Any());
        }

    }
}
