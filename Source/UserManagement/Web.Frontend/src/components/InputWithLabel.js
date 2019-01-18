import React from "react";
import { TextInput, Label } from "evergreen-ui";

export class InputWithLabel extends React.Component {
    render() {
        const { label, placeholder } = this.props;

        return (
            <div className="inputWithLabel--container">
                <Label>{label}</Label>
                <TextInput placeholder={placeholder} />
            </div>
        );
    }
}
