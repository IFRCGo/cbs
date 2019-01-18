import React from "react";
import { Combobox, Label } from "evergreen-ui";

export class ComboboxWithLabel extends React.Component {
    render() {
        const { label, values, placeholder } = this.props;
        return (
            <div className="comboboxWithLabel--container">
                <Label>{label}</Label>
                <Combobox
                    width="280px"
                    items={values}
                    onChange={selected => console.log(selected)}
                    placeholder={placeholder}
                />
            </div>
        );
    }
}
