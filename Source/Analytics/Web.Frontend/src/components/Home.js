import React, {Component} from "react";
import {Tab, TabNavigation} from "evergreen-ui";

class Home extends Component {

    constructor(props) {
        super(props);


        this.state = {
            selectedIndex : 0
        }
    }

    render() {
        return (
            <div>
                <TabNavigation>
                    <Tab is="a" href="#" id={0} isSelected={this.state.selectedIndex === 0} onClick={() => this.setState({selectedIndex : 0})}>
                        Home
                    </Tab>
                    <Tab is="a" href="#" id={1} isSelected={this.state.selectedIndex === 1} onClick={() => this.setState({selectedIndex : 1})}>
                        Epicurve
                    </Tab>
                    <Tab is="a" href="#" id={1} isSelected={this.state.selectedIndex === 1} onClick={() => this.setState({selectedIndex : 1})}>
                        Age and sex distribution
                    </Tab>
                    <Tab is="a" href="#" id={1} isSelected={this.state.selectedIndex === 1} onClick={() => this.setState({selectedIndex : 1})}>
                        Epicurve
                    </Tab>

                </TabNavigation>
            </div>
        );
    }

}

export default Home