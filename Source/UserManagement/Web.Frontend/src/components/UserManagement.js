import React from "react";
import Helmet from "react-helmet";
import PropTypes from "prop-types";
import { Button } from "evergreen-ui";

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

    constructor(component) {
        super(component);

        this.state = {};
    }

    render() {
        const title = "User Management";
        const description = "";
        const {
            currentSortColumn,
            isSortedAscending,
            currentFilter
        } = this.props;

        return (
            <React.Fragment>
                <Helmet>
                    <title>{title}</title>
                    <meta property="og:title" content={title} />
                    <meta property="og:description" content={description} />
                    <meta name="description" content={description} />
                </Helmet>
                <div className="userManagement--headerContainer">
                    <h1>Edit Data Collectors</h1>
                    <div>
                        <Button>Export Data collectors</Button>
                        <Button>Add Data Collectors</Button>
                    </div>
                </div>
            </React.Fragment>
        );
    }
}
export default UserManagement;
