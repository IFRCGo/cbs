import React from "react";
import Helmet from "react-helmet";
import PropTypes from "prop-types";
import {
    Button,
    Table,
    IconButton,
    TextDropdownButton,
    Badge,
    Heading,
    SearchInput
} from "evergreen-ui";
import UserManagementController from "../../controllers/UserManagement";
import _ from "lodash";

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

        this.state = { sortOrder: "asc", field: null, searchTerm: null };
    }

    componentDidMount() {
        this.props.loadDataCollectors();
    }

    getSortedData() {
        let allDataCollectors = [];

        if (!this.state.field) {
            allDataCollectors = this.props.allDataCollectors;
        } else {
            allDataCollectors = _.orderBy(
                this.props.allDataCollectors,
                this.state.field,
                this.state.sortOrder
            );
        }

        if (this.state.searchTerm && this.state.searchTerm.length >= 3) {
            return allDataCollectors.filter(
                row =>
                    JSON.stringify(row)
                        .toLowerCase()
                        .indexOf(this.state.searchTerm.toLowerCase()) > 0
            );
        } else {
            return allDataCollectors;
        }
    }

    createSortableHeader(field) {
        const icon =
            this.state.field === field
                ? {
                      icon:
                          this.state.sortOrder == "asc"
                              ? "caret-down"
                              : "caret-up"
                  }
                : { icon: " " };
        return {
            ...icon,
            onClick: () =>
                this.setState({
                    ...this.state,
                    field: field,
                    sortOrder: this.state.sortOrder === "asc" ? "desc" : "asc"
                })
        };
    }

    getColorForBadge(status) {
        switch (status) {
            case "In Training":
                return "blue";
            case "Active":
                return "green";
            case "Moved":
                return "yellow";
            case "Removed":
                return "red";
            default:
                return "teal";
        }
    }

    render() {
        const title = "User Management";
        const description = "";
        const { history } = this.props;

        return (
            <React.Fragment>
                <Helmet>
                    <title>{title}</title>
                    <meta property="og:title" content={title} />
                    <meta property="og:description" content={description} />
                    <meta name="description" content={description} />
                </Helmet>
                <div className="userManagement--container">
                    <div className="userManagement--center">
                        <div className="userManagement--headerContainer">
                            <Heading paddingBottom="20px" size={700}>
                                Data Collectors
                            </Heading>
                            <div>
                                <SearchInput
                                    placeholder="Search"
                                    onChange={e =>
                                        this.setState({
                                            ...this.state,
                                            searchTerm: e.target.value
                                        })
                                    }
                                />
                                <Button
                                    marginLeft="20px"
                                    onClick={() => history.push("/users/add")}
                                >
                                    Add Data Collectors
                                </Button>
                            </div>
                        </div>
                        <Table>
                            <Table.Head>
                                <Table.TextHeaderCell>
                                    <TextDropdownButton
                                        {...this.createSortableHeader(
                                            "fullName"
                                        )}
                                    >
                                        Full name
                                    </TextDropdownButton>
                                </Table.TextHeaderCell>
                                <Table.TextHeaderCell>
                                    <TextDropdownButton
                                        {...this.createSortableHeader(
                                            "displayName"
                                        )}
                                    >
                                        Display name
                                    </TextDropdownButton>
                                </Table.TextHeaderCell>
                                <Table.TextHeaderCell>
                                    <TextDropdownButton
                                        {...this.createSortableHeader("region")}
                                    >
                                        Region
                                    </TextDropdownButton>
                                </Table.TextHeaderCell>
                                <Table.TextHeaderCell>
                                    <TextDropdownButton
                                        {...this.createSortableHeader(
                                            "district"
                                        )}
                                    >
                                        District
                                    </TextDropdownButton>
                                </Table.TextHeaderCell>
                                <Table.TextHeaderCell>
                                    <TextDropdownButton
                                        {...this.createSortableHeader(
                                            "village"
                                        )}
                                    >
                                        Village
                                    </TextDropdownButton>
                                </Table.TextHeaderCell>
                                <Table.TextHeaderCell>
                                    <TextDropdownButton
                                        {...this.createSortableHeader("status")}
                                    >
                                        Status
                                    </TextDropdownButton>
                                </Table.TextHeaderCell>
                                <Table.TextHeaderCell
                                    flexBasis={60}
                                    flexShrink={0}
                                    flexGrow={0}
                                />
                            </Table.Head>
                            <Table.VirtualBody height={700}>
                                {this.getSortedData().map(dataCollector => (
                                    <Table.Row
                                        key={dataCollector.id}
                                        isSelectable
                                    >
                                        <Table.TextCell>
                                            {dataCollector.fullName}
                                        </Table.TextCell>
                                        <Table.TextCell>
                                            {dataCollector.displayName}
                                        </Table.TextCell>
                                        <Table.TextCell>
                                            {dataCollector.region}
                                        </Table.TextCell>
                                        <Table.TextCell>
                                            {dataCollector.district}
                                        </Table.TextCell>
                                        <Table.TextCell>
                                            {dataCollector.village}
                                        </Table.TextCell>
                                        <Table.TextCell>
                                            <Badge
                                                color={this.getColorForBadge(
                                                    dataCollector.status
                                                )}
                                                isSolid
                                            >
                                                {dataCollector.status}
                                            </Badge>
                                        </Table.TextCell>
                                        <Table.Cell
                                            flexBasis={60}
                                            flexShrink={0}
                                            flexGrow={0}
                                        >
                                            <IconButton
                                                icon="more"
                                                height={24}
                                                appearance="minimal"
                                                onClick={() =>
                                                    history.push(
                                                        `/users/edit/${
                                                            dataCollector.id
                                                        }`
                                                    )
                                                }
                                            />
                                        </Table.Cell>
                                    </Table.Row>
                                ))}
                            </Table.VirtualBody>
                        </Table>
                    </div>
                </div>
            </React.Fragment>
        );
    }
}
export default new UserManagementController(UserManagement);
