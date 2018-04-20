/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Infrastructure.TextMessaging;
using Xunit;

namespace TextMessaging.Tests
{
    public class TextMessageParserTests
    {
        //TODO: Write more tests
        [Fact]
        public void WhenParsingWithTwoFragments_ItShoulReturnTwoFragments()
        {
            var parser = new TextMessageParser();
            var message = new TextMessage { Message = "first#second" };
            var result = parser.Parse(message);
            Assert.Equal(2, result.Fragments.Count());
        }

        [Fact]
        public void WhenParsingWithTwoFragmentsAndOneIsEmpty_ItShouldReturnTwoFragments()
        {
            var parser = new TextMessageParser();
            var message = new TextMessage { Message = "first#" };
            var result = parser.Parse(message);
            Assert.Equal(2, result.Fragments.Count());
        }
    }
}