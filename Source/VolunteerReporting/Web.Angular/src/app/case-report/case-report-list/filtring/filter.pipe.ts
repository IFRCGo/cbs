import {Pipe, PipeTransform} from "@angular/core"
import { CaseReportForListing } from "../../../shared/models/case-report-for-listing.model";

@Pipe({
    name: "filter",
    pure: false
})

//TODO: Add smarter filtering. Preferably a filter should be a json
export class Filter implements PipeTransform{
    transform(reports: Array<CaseReportForListing>, value: string){
        if (!reports || !value) {
            return reports;
        }
        // I tried using Array.filter, but I did not get it to work for some reason...
        // This should be optimized!!!
        // TODO: 
        let list = [];
        reports.forEach(report => {
            switch(value) {
                case "all":
                list.push(report);
                    break;
                case "success":
                    if (report.healthRiskId) {
                        list.push(report);
                    }
                    break;
                case "error":
                    if (!report.healthRiskId) {
                        list.push(report);
                    }
                    break;
                case "unknownSender":
                    if (!report.dataCollectorId) {
                        list.push(report);
                    }
                    break;

                default:
                    list.push(report);
                    break;
            }       
        });
        
        return list;
    }


}