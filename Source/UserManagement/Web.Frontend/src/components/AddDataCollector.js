import React from "react";
import Helmet from "react-helmet";
import PropTypes from "prop-types";
import { InputWithLabel } from "./InputWithLabel";
import { Heading, TextInput, Button } from "evergreen-ui";
import { PhoneNumber } from "./PhoneNumber";
import { YearOfBirth } from "./YearOfBirth";
import { ComboboxWithLabel } from "./ComboboxWithLabel";
import { MapWithLabel } from "./MapWithLabel";
import { CoordinateInputWithLabel } from "./CoordinateInputWithLabel";

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

    render() {
        const title = "Add Data Collector";
        const description = "";

        return (
            <React.Fragment>
                <Helmet>
                    <title>{title}</title>
                    <meta property="og:title" content={title} />
                    <meta property="og:description" content={description} />
                    <meta name="description" content={description} />
                </Helmet>
                <div className="addDataCollector--container">
                    <div className="addDataCollector--center">
                        <div className="addDataCollector--grid">
                            <Heading size={700} paddingBottom="20px">
                                Edit data collector
                            </Heading>
                            <div className="addDataCollector--gridElement">
                                <InputWithLabel
                                    label="Full name"
                                    placeholder="Somaliland Cholera Preperedness"
                                />
                                <InputWithLabel
                                    label="Display name"
                                    placeholder="Somaliland Cholera Preperedness"
                                />
                            </div>
                            <div className="addDataCollector--gridElement">
                                <PhoneNumber
                                    label="Phone number"
                                    countryCodePlaceholder="+61"
                                    numberPlaceholder="123412432"
                                />
                                <YearOfBirth
                                    label="Year of birth"
                                    placeholder="1975"
                                />
                            </div>
                            <div className="addDataCollector--gridElement">
                                <PhoneNumber
                                    label="Phone number"
                                    countryCodePlaceholder="+61"
                                    numberPlaceholder="123412432"
                                />
                                <YearOfBirth
                                    label="Year of birth"
                                    placeholder="1975"
                                />
                            </div>
                            <div className="addDataCollector--gridElement">
                                <ComboboxWithLabel
                                    label="Prefered language"
                                    values={["English", "French"]}
                                    placeholder="English"
                                />
                                <ComboboxWithLabel
                                    label="Status"
                                    values={["Training", "Not Training"]}
                                    placeholder="Training"
                                />
                            </div>
                            <div className="addDataCollector--gridElement">
                                <MapWithLabel
                                    label="Location"
                                    longitude={-34.397}
                                    latitude={150.644}
                                />
                            </div>
                            <div className="addDataCollector--coordinate">
                                <CoordinateInputWithLabel
                                    label="Longitude"
                                    placeholder="8"
                                />
                                <CoordinateInputWithLabel
                                    label="Latitude"
                                    placeholder="123"
                                />
                                <Button>Get from device</Button>
                            </div>
                            <div className="addDataCollector--gridElement">
                                <InputWithLabel
                                    label="Region"
                                    placeholder="Puntland"
                                />
                                <InputWithLabel
                                    label="District"
                                    placeholder="Boroma"
                                />
                            </div>
                            <div className="addDataCollector--gridElement">
                                <InputWithLabel
                                    label="Village"
                                    placeholder="Nas"
                                />
                            </div>
                            <div className="addDataCollector--gridElement">
                                <div>
                                    <Button>Cancel</Button>
                                    <Button
                                        marginLeft="20px"
                                        appearance="primary"
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

export default AddDataCollector;
