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

    loadDataCollector(id) {
        // Do the API request here

        return {
            dataCollectorToAdd: {
                id: id,
                fullName: `fullname${id}`,
                displayName: `displayName${id}`,
                region: `region${id}`,
                district: `district${id}`,
                village: `village${id}`,
                status: `status${id}`
            }
        };
    }

    loadDataCollectors() {
        // Do the API request here

        return {
            allDataCollectors: [...Array(50).keys()].map(id => {
                return {
                    id: id,
                    fullName: `fullname${id}`,
                    displayName: `displayName${id}`,
                    region: `region${id}`,
                    district: `district${id}`,
                    village: `village${id}`,
                    status: `status${id}`
                };
            })
        };
    }

    saveNewDataCollector() {
        // Do the API request with data in this.state.dataCollectorToAdd

        console.log(this.state.dataCollectorToAdd || {});
    }

    clearDataCollector() {
        return {
            dataCollectorToAdd: {}
        };
    }
    constructor(component) {
        super(component);
        this.state = {
            dataCollectorToAdd(store) {
                return store.dataCollectorToAdd || {};
            },
            allDataCollectors(store) {
                return store.allDataCollectors || [];
            }
        };

        this.connect();
    }
}
