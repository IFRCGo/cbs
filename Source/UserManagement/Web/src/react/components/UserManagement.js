import React from "react";
import Helmet from "react-helmet";
import PropTypes from "prop-types";

class UserManagement extends React.Component {
    static get contextTypes() {
        return {
            router: PropTypes.shape({
                history: PropTypes.shape({
                    push: PropTypes.func.isRequired,
                    replace: PropTypes.func.isRequired,
                    createHref: PropTypes.func.isRequired
                }).isRequired
            }).isRequired
        };
    }

    render() {
        return (
            <React.Fragment>
                <Helmet>
                    <title>{title}</title>
                    <meta property="og:title" content={title} />
                    <meta property="og:description" content={description} />
                    <meta name="description" content={description} />
                </Helmet>
                <h1>Hello</h1>
            </React.Fragment>
        );
    }
}

export default UserManagement;
