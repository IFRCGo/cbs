import React from "react";
export default class ComponentWithState extends React.Component {
    render() {
        const { state, setState } = this.props;
        return React.cloneElement(this.props.children, {
            state: state,
            setState: setState
        });
    }
}
