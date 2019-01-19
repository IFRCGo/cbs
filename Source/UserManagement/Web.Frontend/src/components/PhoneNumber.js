import React from "react";
import { TextInput, Label } from "evergreen-ui";

const valueOrPlaceholder = (value, placeholder) => {
    if (!!value) {
        return { value: value };
    }

    return { placeholder: placeholder };
};

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
                        className="phoneNumber--countryCode"
                        placeholder={countryCodePlaceholder}
                        value={countryCodeValue || ""}
                        onChange={e =>
                            !!onCountryCodeChange &&
                            onCountryCodeChange(e.target.value)
                        }
                    />
                    <TextInput
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
