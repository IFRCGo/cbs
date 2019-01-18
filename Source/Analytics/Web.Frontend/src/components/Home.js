import React, {Component} from "react";
import {Tab, TabNavigation} from "evergreen-ui";

class Home extends Component {

    constructor(props) {
        super(props);

    }

    render() {
        return (
            <div>
                <TabNavigation>
                    {['Traits', 'Event History', 'Identities'].map((tab, index) => (
                        <Tab key={tab} is="a" href="#" id={tab} isSelected={index === 0}>
                            {tab}
                        </Tab>
                    ))}
                </TabNavigation>
            </div>
        );
    }

}

export default Home