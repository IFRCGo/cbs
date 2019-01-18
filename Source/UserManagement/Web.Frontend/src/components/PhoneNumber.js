import React from "react";
import { TextInput, Label } from "evergreen-ui";

export class PhoneNumber extends React.Component {
    render() {
        const { label, countryCodePlaceholder, numberPlaceholder } = this.props;
        return (
            <div className="phonenumber--container">
                <Label>{label}</Label>
                <div>
                    <TextInput
                        width="60px"
                        marginRight="20px"
                        className="phoneNumber--countryCode"
                        placeholder={countryCodePlaceholder}
                    />
                    <TextInput width="200px" placeholder={numberPlaceholder} />
                </div>
            </div>
        );
    }
}
