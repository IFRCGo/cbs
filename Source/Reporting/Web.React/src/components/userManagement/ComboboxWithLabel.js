import React from "react";
import { Combobox, Label } from "evergreen-ui";

export class ComboboxWithLabel extends React.Component {
    render() {
        const {
            label,
            items,
            placeholder,
            onChange,
            selectedItem
        } = this.props;
        return (
            <div className="comboboxWithLabel--container">
                <Label>{label}</Label>
                <Combobox
                    width="280px"
                    items={items}
                    selectedItem={selectedItem}
                    onChange={selected => !!onChange && onChange(selected)}
                    placeholder={placeholder}
                />
            </div>
        );
    }
}
