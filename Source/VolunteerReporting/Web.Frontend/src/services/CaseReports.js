import { BaseApi } from "@ifrc-cbs/common-react-ui";

export default class CaseReports extends BaseApi {
    fetchAllCaseReports(params) {
        return this.fetch("/api/case-reports", {
            parameters: {}
        });
    }
}
