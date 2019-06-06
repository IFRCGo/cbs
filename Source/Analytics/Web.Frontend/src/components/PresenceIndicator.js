import React from "react";
import { Heading, UnorderedList, ListItem } from "evergreen-ui";

export class PresenceIndicator extends React.Component {
    createInfoLine(presenceData) {
        let text = "";
        Object.values(presenceData).forEach(value => {text = value + " " + text}); //prepend to the text as we want the numbers before the description
        return text;
    }

    render() {
        return (
            <div className="analytics--headerPanel" style={{marginRight: 30}}>
                <i className={`${this.props.icon} fa fa-5x analytics--headerPanelIcon`} />

                <Heading color={this.props.color} size={600} paddingTop={"20px"}>
                    {this.props.headline}
                </Heading>

                <div className="analytics--listContainer">
                    <UnorderedList size={500}>
                        {this.props.list.map(
                            (data, index) => (
                                <ListItem key={index}>
                                    {this.createInfoLine(data)}
                                </ListItem>
                            )
                        )}
                    </UnorderedList>
                </div>
            </div>
        );
    }
}
