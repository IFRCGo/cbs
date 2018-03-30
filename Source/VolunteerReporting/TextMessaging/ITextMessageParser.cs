/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Infrastructure.TextMessaging;

namespace TextMessaging
{
    /// <summary>
    /// Defines a system that is capable of parsing a <see cref="TextMessage"/>
    /// </summary>
    public interface ITextMessageParser
    {
        /// <summary>
        /// Parse a <see cref="TextMessage"/>
        /// </summary>
        /// <param name="textMessage"><see cref="TextMessage"/></param>
        /// <returns>The <see cref="TextMessageParsingResult">result</see></returns>
        /// <remarks>
        /// Delimiters: * # 
        /// Expected format of sms content: Event [delimiter] sex of case [delimiter] Age of case [delimiter]
        /// or Event # Number of male cases five or under # Number of male cases over 5	# Number of female cases five or under # Number of female cases over five
        /// </remarks>
        TextMessageParsingResult Parse(TextMessage textMessage);
    }
}