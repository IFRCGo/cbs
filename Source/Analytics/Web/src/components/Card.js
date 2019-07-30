import React from "react";
import { Heading, UnorderedList, ListItem } from "evergreen-ui";

class Card extends React.Component {
    constructor(props){
        super(props)
        this.state = {
            value: props.value,
            isLoading: true,
            isError: false
        };
    }

    render() {
        return (
            <div>
                <div>Total number of reports</div>
                <div>
                    {this.state.value}
                </div>
            </div>
        );
    }
}

export default Card;