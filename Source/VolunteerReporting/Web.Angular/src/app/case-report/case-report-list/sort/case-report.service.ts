import { Injectable } from '@angular/core';

import { Report } from '../../../shared/models/report.model';

@Injectable()
export class ReportService {
    getReports(reports: Array<Report>, reports_detailed: Array<any>, criteria: ReportSearchCriteria): Array<Report> {
        if (criteria.sortColumn === 'timeStamp') {
            return reports.sort( function(a,b) {
                    return (criteria.sortDirection === 'desc')? 
                            a.timestamp < b.timestamp? 1 : a.timestamp > b.timestamp? -1 : 0
                            : a.timestamp > b.timestamp? 1 : a.timestamp < b.timestamp? -1 : 0;
            });
        } else if (criteria.sortColumn === 'status') {
            // Sorts the table by the status field. Should make it possible to sort on two parameters,
            // The sorting direcetion of sortColumn and the sortDirection of the timeStamp field
            return reports_detailed.sort( function(a,b) {
                let result = ((a.healthRisk && b.healthRisk) || (!a.healthRisk && !b.healthRisk))? 
                            0 : a.healthRisk? -1 : 1;
                return (criteria.sortDirection === "desc")? result : result * -1;
            }); //.sort( (a, b) => a.timestamp > b.timestamp? 1 : a.timestamp < b.timestamp? -1 : 0);
            // WIP
        } else if (criteria.sortColumn === 'dataCollector') {
            return reports_detailed.sort( function(a,b ) {
                console.log(a.dataCollector);
                const fullName_a = a.dataCollector? 
                                    a.dataCollector.fullName?
                                        a.dataCollector.fullName : undefined
                                    : undefined;
                const fullName_b = b.dataCollector? 
                                    b.dataCollector.fullName?
                                        b.dataCollector.fullName : undefined
                                    : undefined;

                console.log(fullName_a);
                let result = ((fullName_a === undefined && fullName_b === undefined) || (String(fullName_a) === String(fullName_b)))?
                                0 : (fullName_a < fullName_b)?
                                    -1 : 1;

                return (criteria.sortDirection === "desc")? result : result * -1; 
            });
            
        }
    }
    

}

export class ReportSearchCriteria {
  sortColumn: string;
  sortDirection: string;
}