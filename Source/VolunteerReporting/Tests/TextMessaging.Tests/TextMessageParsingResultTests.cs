/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Xunit;

namespace TextMessaging.Tests
{
    public class TextMessageParsingResultTests
    {
        [Fact]
        public void WhenCreatedWithOneNumberFragment_ItShouldBeValid()
        {
            var result = new TextMessageParsingResult(new[] {
                new TextMessageFragment("42")
            });

            Assert.True(result.IsValid);
            Assert.False(result.HasMultipleCases);
            Assert.Single(result.Fragments);
            Assert.True(result.ErrorMessages.Count() == 0);
            Assert.Equal(new[] { 42}, result.Numbers);
        }

        [Fact]
        public void WhenCreatedWithAZero_ItShouldBeValid()
        {
            var result = new TextMessageParsingResult(new[] {
                new TextMessageFragment("0")
            });

            Assert.True(result.IsValid);
            Assert.False(result.HasMultipleCases);
            Assert.Single(result.Fragments);
            Assert.True(result.ErrorMessages.Count() == 0);
            Assert.Equal(new[] { 0 }, result.Numbers);
        }

        [Fact]
        public void WhenCreatedWithANegativeNumber_ItShouldNotBeValid()
        {
            var result = new TextMessageParsingResult(new[] {
                new TextMessageFragment("-30")
            });

            Assert.False(result.IsValid);
            Assert.False(result.HasMultipleCases);
            Assert.Single(result.Fragments);
            Assert.True(result.ErrorMessages.Count() == 1);
            Assert.Equal(new[] { -30 }, result.Numbers);
        }

        [Fact]
        public void WhenCreatedWithTwoNumberFragments_ItShouldNotBeValid()
        {
            var result = new TextMessageParsingResult(new[] {
                new TextMessageFragment("42"),
                new TextMessageFragment("43")
            });

            Assert.False(result.IsValid);
            Assert.False(result.HasMultipleCases);
            Assert.Equal(2, result.Fragments.Count());
            Assert.True(result.ErrorMessages.Count() == 1);
            Assert.Equal(new[] {42,43}, result.Numbers);
        }

        [Fact]
        public void WhenCreatedWithFourNumberFragments_ItShouldNotBeValid()
        {
            var result = new TextMessageParsingResult(new[] {
                new TextMessageFragment("42"),
                new TextMessageFragment("43"),
                new TextMessageFragment("44"),
                new TextMessageFragment("45")
            });

            Assert.False(result.IsValid);
            Assert.False(result.HasMultipleCases);
            Assert.Equal(4, result.Fragments.Count());
            Assert.True(result.ErrorMessages.Count() == 1);
            Assert.Equal(new[] {42,43,44,45}, result.Numbers);
        }

        [Fact]
        public void WhenCreatedWithThreeNumberFragmentsWith1Or2InTheLastSlots_ItShoulBeValid()
        {
            var result = new TextMessageParsingResult(new[] {
                new TextMessageFragment("42"),
                new TextMessageFragment("1"),
                new TextMessageFragment("2")
            });

            Assert.True(result.IsValid);
            Assert.False(result.HasMultipleCases);
            Assert.Equal(3, result.Fragments.Count());
            Assert.True(result.ErrorMessages.Count() == 0);
            Assert.Equal(new[] {42,1,2}, result.Numbers);
        }

        [Fact]
        public void WhenCreatedWithThreeNumberFragmentsWithA0InTheLastSlots_ItShoulNotBeValid()
        {
            var result = new TextMessageParsingResult(new[] {
                new TextMessageFragment("42"),
                new TextMessageFragment("0"),
                new TextMessageFragment("2")
            });

            Assert.False(result.IsValid);
            Assert.False(result.HasMultipleCases);
            Assert.Equal(3, result.Fragments.Count());
            Assert.True(result.ErrorMessages.Count() == 1);
            Assert.Equal(new[] { 42, 0, 2 }, result.Numbers);
        }

        [Fact]
        public void WhenCreatedWithAANegativeNumber_ItShoulNotBeValid()
        {
            var result = new TextMessageParsingResult(new[] {
                new TextMessageFragment("42"),
                new TextMessageFragment("1"),
                new TextMessageFragment("-34")
            });

            Assert.False(result.IsValid);
            Assert.False(result.HasMultipleCases);
            Assert.Equal(3, result.Fragments.Count());
            Assert.Equal(new[] { 42, 1, -34 }, result.Numbers);
        }

        [Fact]
        public void WhenCreatedWithFiveNumberFragments_ItShoulBeValid()
        {
            var result = new TextMessageParsingResult(new[] {
                new TextMessageFragment("42"),
                new TextMessageFragment("43"),
                new TextMessageFragment("44"),
                new TextMessageFragment("45"),
                new TextMessageFragment("46")
            });

            Assert.True(result.IsValid);
            Assert.True(result.HasMultipleCases);
            Assert.Equal(5, result.Fragments.Count());
            Assert.True(result.ErrorMessages.Count() == 0);
            Assert.Equal(new[] {42,43,44,45,46}, result.Numbers);
        }

        [Fact]
        public void WhenCreatedWithThreeSegmentsAndMiddleHasNoValue_ItShouldNotBeValid()
        {
            var result = new TextMessageParsingResult(new[] {
                new TextMessageFragment("42"),
                new TextMessageFragment(""),
                new TextMessageFragment("44")
            });

            Assert.False(result.IsValid);
            Assert.True(result.ErrorMessages.Count() == 2);
        }
    }
}