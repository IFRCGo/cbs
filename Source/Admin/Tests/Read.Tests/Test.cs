/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Xunit;
using FakeItEasy;
using Read;
using Read.ProjectFeatures;

namespace Read.Tests
{
    public class Test
    {
        [Fact]
        public void DummyTest()
        {
            // Arrange
            var projectId = Guid.NewGuid();
            var projects = A.Fake<IProjects>();
            A.CallTo(() => projects.GetById(A<Guid>._)).Returns(new Project() { Id = projectId });

            // Act
            var project = projects.GetById(projectId);

            // Assert
            Assert.Equal(projectId, project.Id);
        }
    }
}
