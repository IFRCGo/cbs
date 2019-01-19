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
                return store.dataCollectorToAdd || {};
            }
        };

        this.connect();
    }
}
