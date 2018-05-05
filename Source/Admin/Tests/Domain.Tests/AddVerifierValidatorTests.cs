/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Domain.Admin;
using Domain.RuleImplementations;
using FakeItEasy;
using Read.ProjectFeatures;
using Read.UserFeatures;
using Xunit;

namespace Domain.Tests
{
    public class AddVerifierValidatorTests
    {
        [Fact]
        public void UserIsNotSpecified_ShouldNotValidate()
        {
            var users = A.Fake<IUsers>();
            A.CallTo(() => users.GetById(A<Guid>._)).Returns(
                new User()
            );

            var projects = A.Fake<IProjects>();
            var projectId = Guid.NewGuid();

            A.CallTo(() => projects.GetById(A<Guid>._)).Returns(
                new Read.ProjectFeatures.Project
                {
                    DataVerifiers = new[] {new User {Id = Guid.NewGuid()}},
                }
            );

            var validator = new AddDataVerifierValidator(new UserRules(users), new ProjectRules(projects));
            var validationResult = validator.Validate(new AddDataVerifier
            {
                ProjectId = Guid.NewGuid()
            });
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void UserIsNotExisting_ShouldNotValidate()
        {
            var users = A.Fake<IUsers>();
            A.CallTo(() => users.GetById(A<Guid>._)).Returns(
                null
            );

            var projects = A.Fake<IProjects>();
            var projectId = Guid.NewGuid();

            A.CallTo(() => projects.GetById(A<Guid>._)).Returns(
                new Read.ProjectFeatures.Project
                {
                    DataVerifiers = new[] {new User {Id = Guid.NewGuid()}},
                }
            );

            var validator = new AddDataVerifierValidator(new UserRules(users), new ProjectRules(projects));
            var validationResult = validator.Validate(new AddDataVerifier
            {
                ProjectId = Guid.NewGuid(),
                UserId = Guid.NewGuid()
            });
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void UserIsAlreadyAVerifier_ShouldNotValidate()
        {
            var userId = Guid.NewGuid();
            var users = A.Fake<IUsers>();
            A.CallTo(() => users.GetById(A<Guid>._)).Returns(
                new User {Id = userId}
            );

            var projects = A.Fake<IProjects>();
            var projectId = Guid.NewGuid();

            A.CallTo(() => projects.GetById(A<Guid>._)).Returns(
                new Read.ProjectFeatures.Project
                {
                    DataVerifiers = new[] {new User {Id = userId}},
                }
            );

            var validator = new AddDataVerifierValidator(new UserRules(users), new ProjectRules(projects));
            var validationResult = validator.Validate(new AddDataVerifier
            {
                ProjectId = projectId,
                UserId = userId
            });
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void UserExistAndIsNotAVerifier_ShouldValidate()
        {
            var users = A.Fake<IUsers>();
            A.CallTo(() => users.GetById(A<Guid>._)).Returns(
                new User()
            );

            var projects = A.Fake<IProjects>();
            var projectId = Guid.NewGuid();


            A.CallTo(() => projects.GetById(A<Guid>._)).Returns(
                new Read.ProjectFeatures.Project
                {
                    DataVerifiers = new[] {new User {Id = Guid.NewGuid()}},
                }
            );

            var validator = new AddDataVerifierValidator(new UserRules(users), new ProjectRules(projects));
            var validationResult = validator.Validate(new AddDataVerifier
            {
                ProjectId = Guid.NewGuid()
            });
            Assert.False(validationResult.IsValid);
        }
    }
}