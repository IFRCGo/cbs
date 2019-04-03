import React from "react";
import DayPicker, { DateUtils } from "react-day-picker";
import "react-day-picker/lib/style.css";
import { Text, Button } from "evergreen-ui";

export class DatePicker extends React.Component {
    constructor(props) {
        super(props);
        this.handleDayClick = this.handleDayClick.bind(this);
        this.handleResetClick = this.handleResetClick.bind(this);
        this.state = this.getInitialState();
    }
    getInitialState() {
        return {
            from: undefined,
            to: undefined
        };
    }
    handleDayClick(day) {
        const range = DateUtils.addDayToRange(day, this.state);
        this.setState(range);

        const { from, to } = range;

        if (from && to && this.props.onRangeSelected) {
            this.props.onRangeSelected({
                to: range.to.getTime(),
                from: range.from.getTime()
            });
        }
    }
    handleResetClick() {
        this.setState(this.getInitialState());
    }
    render() {
        const { from, to } = this.state;
        const modifiers = { start: from, end: to };
        return (
            <div className={"analytics--datePicker"}>
                <div>
                    <Text>
                        {!from && !to && "Please select the first day."}
                        {from && !to && "Please select the last day."}
                        {/* {from &&
                            to &&
                            `Selected from ${from.toLocaleDateString()} to
                        ${to.toLocaleDateString()}`}{" "} */}
                    </Text>
                </div>
                <DayPicker
                    className="Selectable"
                    numberOfMonths={this.props.numberOfMonths}
                    selectedDays={[from, { from, to }]}
                    modifiers={modifiers}
                    onDayClick={this.handleDayClick}
                />
            </div>
        );
    }
}
