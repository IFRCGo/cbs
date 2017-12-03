/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
 
 namespace Web.Localization
{
    public class ExampleStringManager
    {
        public virtual string ExampleString { get; } = "This is an example";
        public string ErrorVirtualMissingString { get; } = "This will not be translated because the virtual keyword is missing";
        public virtual string ExampleMissingTranslationString { get; } = "This string is missing French translation, hence the default will be output";
    }
}
