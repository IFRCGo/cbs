import React from "react";
import { Heading, UnorderedList, ListItem } from "evergreen-ui";

export class HeaderPanel extends React.Component {

    render() {
        return (
            <div className="analytics--headerPanel">
                <i className={`${this.props.icon} fa fa-5x analytics--headerPanelIcon`} />

                <Heading color={this.props.color} size={600} paddingTop={"20px"}>
                    {this.props.headline}
                </Heading>

                <div className="analytics--listContainer">
                    <UnorderedList size={500}>
                        {this.props.list.map(
                            (data, index) => (
                                <ListItem key={index}>
                                    {data.numberOfReports || data.inactiveDataCollectors} {data.name || data.healthRisk}
                                </ListItem>
                            )
                        )}
                    </UnorderedList>
                </div>
            </div>
        );
    }
}
