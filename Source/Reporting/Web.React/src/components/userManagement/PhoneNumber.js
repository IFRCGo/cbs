import React from "react";
import { TextInput, Label } from "evergreen-ui";

export class PhoneNumber extends React.Component {
    render() {
        const {
            label,
            countryCodePlaceholder,
            countryCodeValue,
            numberPlaceholder,
            numberValue,
            onCountryCodeChange,
            onPhoneNumberChange
        } = this.props;
        return (
            <div className="phonenumber--container">
                <Label>{label}</Label>
                <div>
                    <TextInput
                        width="60px"
                        marginRight="20px"
                        type="tel"
                        pattern="\+\d+"
                        className="phoneNumber--countryCode"
                        placeholder={countryCodePlaceholder}
                        value={countryCodeValue || ""}
                        onChange={e =>
                            !!onCountryCodeChange &&
                            onCountryCodeChange(e.target.value)
                        }
                    />
                    <TextInput
                        type="tel"
                        width="200px"
                        placeholder={numberPlaceholder}
                        value={numberValue}
                        onChange={e =>
                            !!onPhoneNumberChange &&
                            onPhoneNumberChange(e.target.value)
                        }
                    />
                </div>
            </div>
        );
    }
}
