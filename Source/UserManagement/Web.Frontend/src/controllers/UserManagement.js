import { BaseController } from "repertoire";

export default class UserManagementController extends BaseController {
    get stateNamespace() {
        return "userManagement";
    }

    addDataCollector(currentField) {
        return {
            dataCollectorToAdd: {
                ...(this.state.dataCollectorToAdd || {}),
                ...currentField
            }
        };
    }

    clearDataCollector() {
        return {
            dataCollectorToAdd: {}
        };
    }

    getDataCollectorToAdd() {
        console.log(this.state.dataCollectorToAdd || {});
    }

    constructor(component) {
        super(component);
        this.state = {
            dataCollectorToAdd(store) {
                return (
                    store.dataCollectorToAdd ||
                    {} || {
                        countryCode: "61",
                        displayName: "display",
                        district: "district",
                        fullName: "fullname",
                        latitude: "lat",
                        longitude: "long",
                        phoneNumber: "123213",
                        preferedLanguage: "English",
                        region: "regian",
                        sex: "Male",
                        training: "Training",
                        village: "village",
                        yearOfBirth: "year"
                    }
                );
            }
        };

        this.connect();
    }
}
