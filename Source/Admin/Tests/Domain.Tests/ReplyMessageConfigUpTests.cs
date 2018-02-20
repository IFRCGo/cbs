/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Xunit;

namespace Domain.Tests
{
    public class UpdateReplyMessagesConfigTests
    {
        [Fact]
        public void Tags_ShouldBeCaseInsensitiv()
        {
            Assert.Throws<DuplicateTagException>(() =>
                new UpdateReplyMessagesConfig
                {
                    Messages = new Dictionary<string, IDictionary<string, string>>
                    {
                        {" KEY ", new Dictionary<string, string>()},
                        {"key", new Dictionary<string, string>()}
                    }
                });
        }
    }


}