/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017 International Federation of Red Cross. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
 
 namespace Web.Localization.Customer
{
    public class CustomerStrings
    {
        public virtual string FirstNameLabel => "First name";
        public virtual string LastNameLabel => "Last name";

        public string ErrorVirtalMissingExample =>
            "This string is missing the virtual keyword and will not be translated";

        public virtual string ExampleMissingTranslationExample =>
            "This string is missing French translation, hence the default will be output";
    }
}
