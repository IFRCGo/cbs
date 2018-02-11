/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System.Collections.Generic;
using Domain.RuleImplementations;
using Xunit;

namespace Domain.Tests
{
    public class ReplyMessageConfigUpValidatorTests
    {

        //Tag should be unique
        //Tag should be valid, alpha nummeric no space
        // Language must be unique
        // Language must be specified


        [Theory]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData(@"\t", false)]
        [InlineData(@"adfdas asdfsa", false)]
        [InlineData(@"1 asdfsa", false)]
        [InlineData(@"1_asdfsa", false)]
        [InlineData("asdfsa", true)]
        [InlineData("1", true)]
        [InlineData("1a", true)]
        [InlineData("a1 ", true)]
        public void ValidateReplyMessageConfigTag(string tag, bool shouldValidate)
        {
            var validator = new ReplyMessagesConfigValidator(new ReplyMessagesConfigRules());
            var validationResult = validator.Validate(new UpdateReplyMessagesConfig
            {
                Messages = new Dictionary<string, IDictionary<string, string>>
                    {
                        { tag,null}
                    }
            });
            Assert.Equal(shouldValidate, validationResult.IsValid);

        }
       
    }


}