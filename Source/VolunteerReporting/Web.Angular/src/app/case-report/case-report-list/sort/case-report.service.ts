import { Injectable } from '@angular/core';

import { Report } from '../../../shared/models/report.model';

@Injectable()
export class ReportService {
    getReports(reports: Array<Report>, reports_detailed: Array<any>, criteria: ReportSearchCriteria): Array<Report> {
        /*
        return reports.sort( function(a,b) {
            
                if (criteria.sortColumn === 'timeStamp') {
                    return (criteria.sortDirection === 'desc')? 
                        a.timestamp < b.timestamp? 1 : a.timestamp > b.timestamp? -1 : 0
                        : a.timestamp > b.timestamp? 1 : a.timestamp < b.timestamp? -1 : 0;
                } else if (criteria.sortColumn === 'status') {
                    let result = a.success && b.success? 0 : a.success? -1 : 1
                    return (criteria.sortDirection === 'desc')? 
                    result : result * -1;
                    
                }
        });
        */
        if (criteria.sortColumn === 'timeStamp') {
            return reports.sort( function(a,b) {
                    return (criteria.sortDirection === 'desc')? 
                            a.timestamp < b.timestamp? 1 : a.timestamp > b.timestamp? -1 : 0
                            : a.timestamp > b.timestamp? 1 : a.timestamp < b.timestamp? -1 : 0;
            });
        } else if (criteria.sortColumn === 'status') {
            return reports_detailed.sort( function(a,b) {
                let result = ((a.healthRisk && b.healthRisk) || (!a.healthRisk && !b.healthRisk))? 
                            0 : a.healthRisk? -1 : 1;
                return (criteria.sortDirection === "desc")? result : result * -1;
            });
        }
    }
    

}

export class ReportSearchCriteria {
  sortColumn: string;
  sortDirection: string;
}