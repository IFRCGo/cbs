import React from "react";
import Helmet from "react-helmet";
import PropTypes from "prop-types";
import {
    Heading,
    Button,
    TextInputField,
    Pane,
    Dialog,
    BackButton
} from "evergreen-ui";
import { PhoneNumber } from "./PhoneNumber";
import { ComboboxWithLabel } from "./ComboboxWithLabel";
import { MapWithLabel } from "./MapWithLabel";

import UserManagementController from "../../controllers/UserManagement";

class AddDataCollector extends React.Component {
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

    constructor(props) {
        super(props);

        this.state = {
            showConfirmDialog: false,
            showGeolocationDialog: false
        };

        this._mapsRef = {};
    }

    componentDidMount() {
        if (this.props.match.params.id) {
            this.props.loadDataCollector(this.props.match.params.id);
        }
    }

    getLocation() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(position => {
                this.props.addDataCollector({
                    longitude: position.coords.longitude,
                    latitude: position.coords.latitude
                });
                this._mapsRef.getMapsRef().panTo({
                    lat: parseFloat(position.coords.latitude),
                    lng: parseFloat(position.coords.longitude)
                });
            });
        } else {
            this.setState({ ...this.state, showGeolocationDialog: true });
        }
    }

    noGeolocationDialog() {
        return (
            <Pane>
                <Dialog
                    hasCancel={false}
                    isShown={this.state.showGeolocationDialog}
                    title="Geolocation is not supported"
                    onCloseComplete={() =>
                        this.setState({
                            ...this.state,
                            showGeolocationDialog: false
                        })
                    }
                    confirmLabel="OK"
                >
                    Geolocation is not supported by your browser
                </Dialog>
            </Pane>
        );
    }

    confirmDialog() {
        return (
            <Pane>
                <Dialog
                    isShown={this.state.showConfirmDialog}
                    title="Clear input form"
                    intent="danger"
                    onCloseComplete={() => {
                        this.props.clearDataCollector();
                        this.setState({
                            ...this.state,
                            showConfirmDialog: false
                        });
                    }}
                    onComfirm={() => {
                        this.setState({
                            ...this.state,
                            showConfirmDialog: false
                        });
                    }}
                    confirmLabel="Clear input"
                >
                    Do you really want to reset the input form?
                </Dialog>
            </Pane>
        );
    }

    updateCoordinates() {
        if (
            this.props.dataCollectorToAdd.latitude &&
            this.props.dataCollectorToAdd.longitude
        ) {
            this._mapsRef.getMapsRef().panTo({
                lat: parseFloat(this.props.dataCollectorToAdd.latitude),
                lng: parseFloat(this.props.dataCollectorToAdd.longitude)
            });
        }
    }

    render() {
        const title = this.props.match.params.id
            ? "Edit Data Collector"
            : "Add Data Collector";
        const description = "";

        return (
            <React.Fragment>
                <Helmet>
                    <title>{title}</title>
                    <meta property="og:title" content={title} />
                    <meta property="og:description" content={description} />
                    <meta name="description" content={description} />
                </Helmet>
                {this.noGeolocationDialog()}
                {this.confirmDialog()}

                <div className="addDataCollector--container">
                    <div className="addDataCollector--center">
                        <div className="addDataCollector--grid">
                            <div className="addDataCollector--heading">
                                <BackButton
                                    onClick={() => this.props.history.goBack()}
                                />
                                <Heading
                                    marginLeft="20px"
                                    size={700}
                                    paddingBottom="20px"
                                >
                                    {title}
                                </Heading>
                            </div>
                            <div className="addDataCollector--gridElement">
                                <TextInputField
                                    width="280px"
                                    label="Full name"
                                    placeholder="Somaliland Cholera Preperedness"
                                    value={
                                        this.props.dataCollectorToAdd
                                            .fullName || ""
                                    }
                                    onChange={e => {
                                        this.props.addDataCollector({
                                            fullName: e.target.value
                                        });
                                    }}
                                />

                                <TextInputField
                                    width="280px"
                                    label="Display name"
                                    placeholder="Somaliland Cholera Preperedness"
                                    value={
                                        this.props.dataCollectorToAdd
                                            .displayName || ""
                                    }
                                    onChange={e =>
                                        this.props.addDataCollector({
                                            displayName: e.target.value
                                        })
                                    }
                                />
                            </div>
                            <div className="addDataCollector--gridElement">
                                <PhoneNumber
                                    label="Phone number"
                                    countryCodePlaceholder="+61"
                                    countryCodeValue={
                                        this.props.dataCollectorToAdd
                                            .countryCode || ""
                                    }
                                    numberPlaceholder="123412432"
                                    numberValue={
                                        this.props.dataCollectorToAdd
                                            .phoneNumber || ""
                                    }
                                    onCountryCodeChange={countryCode =>
                                        this.props.addDataCollector({
                                            countryCode: countryCode
                                        })
                                    }
                                    onPhoneNumberChange={phoneNumber =>
                                        this.props.addDataCollector({
                                            phoneNumber: phoneNumber
                                        })
                                    }
                                />
                                <div style={{ width: "280px" }}>
                                    <TextInputField
                                        type="number"
                                        min="1900"
                                        max="2200"
                                        width="100px"
                                        marginRight="20px"
                                        label="Year of birth"
                                        placeholder="1975"
                                        value={
                                            this.props.dataCollectorToAdd
                                                .yearOfBirth || ""
                                        }
                                        onChange={e =>
                                            this.props.addDataCollector({
                                                yearOfBirth: e.target.value
                                            })
                                        }
                                    />
                                </div>
                            </div>
                            <div className="addDataCollector--gridElement">
                                <ComboboxWithLabel
                                    label="Sex"
                                    items={["Male", "Female"]}
                                    placeholder="Male"
                                    selectedItem={
                                        this.props.dataCollectorToAdd.sex || ""
                                    }
                                    onChange={sex =>
                                        this.props.addDataCollector({
                                            sex: sex
                                        })
                                    }
                                />
                            </div>
                            <div className="addDataCollector--gridElement">
                                <ComboboxWithLabel
                                    label="Prefered language"
                                    items={["English", "French"]}
                                    selectedItem={
                                        this.props.dataCollectorToAdd
                                            .preferedLanguage || ""
                                    }
                                    placeholder="English"
                                    onChange={language =>
                                        this.props.addDataCollector({
                                            preferedLanguage: language
                                        })
                                    }
                                />
                                <ComboboxWithLabel
                                    label="Status"
                                    items={["Training", "No Training"]}
                                    placeholder="Training"
                                    selectedItem={
                                        this.props.dataCollectorToAdd
                                            .training || ""
                                    }
                                    onChange={training =>
                                        this.props.addDataCollector({
                                            training: training
                                        })
                                    }
                                />
                            </div>
                            <div className="addDataCollector--gridElement">
                                <MapWithLabel
                                    ref={ref => (this._mapsRef = ref)}
                                    label="Location"
                                    latitude={
                                        this.props.dataCollectorToAdd
                                            .latitude || 9
                                    }
                                    longitude={
                                        this.props.dataCollectorToAdd
                                            .longitude || 44
                                    }
                                    apiKey={
                                        "AIzaSyCB2IPddbweufj2myYTB4NhlLmpr58kU04"
                                    }
                                />
                            </div>
                            <div className="addDataCollector--coordinate">
                                <TextInputField
                                    width="150px"
                                    label="Longitude"
                                    placeholder="12"
                                    value={
                                        this.props.dataCollectorToAdd
                                            .longitude || ""
                                    }
                                    onChange={e => {
                                        this.updateCoordinates();
                                        this.props.addDataCollector({
                                            longitude: e.target.value
                                        });
                                    }}
                                />
                                <TextInputField
                                    width="150px"
                                    label="Latitude"
                                    placeholder="123"
                                    value={
                                        this.props.dataCollectorToAdd
                                            .latitude || ""
                                    }
                                    onChange={e => {
                                        this.updateCoordinates();
                                        this.props.addDataCollector({
                                            latitude: e.target.value
                                        });
                                    }}
                                />
                                <Button
                                    marginBottom="24px"
                                    onClick={() => {
                                        this.getLocation();
                                    }}
                                >
                                    Get from device
                                </Button>
                            </div>
                            <div className="addDataCollector--gridElement">
                                <TextInputField
                                    width="280px"
                                    label="Region"
                                    placeholder="Puntland"
                                    value={
                                        this.props.dataCollectorToAdd.region ||
                                        ""
                                    }
                                    onChange={e =>
                                        this.props.addDataCollector({
                                            region: e.target.value
                                        })
                                    }
                                />
                                <TextInputField
                                    width="280px"
                                    label="District"
                                    placeholder="Boroma"
                                    value={
                                        this.props.dataCollectorToAdd
                                            .district || ""
                                    }
                                    onChange={e =>
                                        this.props.addDataCollector({
                                            district: e.target.value
                                        })
                                    }
                                />
                            </div>
                            <div className="addDataCollector--gridElement">
                                <TextInputField
                                    width="280px"
                                    label="Village"
                                    placeholder="Nas"
                                    value={
                                        this.props.dataCollectorToAdd.village ||
                                        ""
                                    }
                                    onChange={e =>
                                        this.props.addDataCollector({
                                            village: e.target.value
                                        })
                                    }
                                />
                            </div>
                            <div className="addDataCollector--gridElement">
                                <div>
                                    <Button
                                        onClick={() =>
                                            this.setState({
                                                ...this.state,
                                                showConfirmDialog: true
                                            })
                                        }
                                    >
                                        Cancel
                                    </Button>
                                    <Button
                                        marginLeft="20px"
                                        appearance="primary"
                                        onClick={() =>
                                            this.props.saveNewDataCollector()
                                        }
                                    >
                                        Save
                                    </Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </React.Fragment>
        );
    }
}

export default new UserManagementController(AddDataCollector);
