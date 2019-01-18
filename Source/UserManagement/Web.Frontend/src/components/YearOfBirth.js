import React from "react";
import { TextInput, Label } from "evergreen-ui";

export class YearOfBirth extends React.Component {
    render() {
        const { label, placeholder } = this.props;
        return (
            <div className="yearOfBirth--container">
                <Label>{label}</Label>
                <TextInput placeholder={placeholder} width="80px" />
            </div>
        );
    }
}
