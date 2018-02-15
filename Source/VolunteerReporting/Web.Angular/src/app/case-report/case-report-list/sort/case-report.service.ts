import { Injectable } from '@angular/core';

import { Report } from '../../../shared/models/report.model';

@Injectable()
export class ReportService {
    getReports(reports: Array<Report>, reports_detailed: Array<any>, criteria: ReportSearchCriteria): Array<Report> {
        // Sort by timestamp
        if (criteria.sortColumn === 'timeStamp') {
            return reports.sort( function(a,b) {
                return ReportService.compareTimestamps(a, b, criteria);
            });
        // Sort by status
        } else if (criteria.sortColumn === 'status') {
            
            return reports_detailed.sort( function(a,b) {
                return ReportService.compareStatus(a,b,criteria);
            });
        // Sort by datacollector fullName
        } else if (criteria.sortColumn === 'dataCollector') {
            return reports_detailed.sort( function(a,b ) {
                const fullName_a = a.dataCollector? 
                                    a.dataCollector.fullName?
                                        a.dataCollector.fullName : undefined
                                    : undefined;
                const fullName_b = b.dataCollector? 
                                    b.dataCollector.fullName?
                                        b.dataCollector.fullName : undefined
                                    : undefined;
                
                return ReportService.compareNullableField(fullName_a, fullName_b, criteria);
            });
        // Sort by HealthRisk
        } else if (criteria.sortColumn === 'healthRisk') {
            return reports_detailed.sort( function(a, b) { 
                return ReportService.compareHealthRisk(a, b, criteria);
            });
        // Sort by femalesOver5
        } else if (criteria.sortColumn === "femalesOver5") {
            return reports_detailed.sort( function(a, b) {
                return ReportService.compareNullableField(a.numberOfFemalesOver5, b.numberOfFemalesOver5, criteria);
            });
        // Sort by femalesUnder5
        } else if (criteria.sortColumn === "femalesUnder5") {
            return reports_detailed.sort( function(a, b) {
                return ReportService.compareNullableField(a.numberOfFemalesUnder5, b.numberOfFemalesUnder5, criteria);
            });
        // Sort by malesOver5
        } else if (criteria.sortColumn === "malesOver5") {
            return reports_detailed.sort( function(a, b) {
                return ReportService.compareNullableField(a.numberOfMalesOver5, b.numberOfMalesOver5, criteria);
            });
        // Sort by malesUnder5
        } else if (criteria.sortColumn === "malesUnder5") {
            return reports_detailed.sort( function(a, b) {
                return ReportService.compareNullableField(a.numberOfMalesUnder5, b.numberOfMalesUnder5, criteria);
            });
        } 
          
        return reports;
    }
    /**
     * Special function to compare two report's timestamps. 
     * Should not have to check the timestamp fields for null-pointer.
     * @param a Report
     * @param b Report
     * @param criteria ReportSearchCriteria 
     */
    private static compareTimestamps(a: Report, b:Report, criteria: ReportSearchCriteria) {
        return (criteria.sortDirection === 'desc')? 
                    a.timestamp < b.timestamp? 1 : a.timestamp > b.timestamp? -1 : 0
                    : a.timestamp > b.timestamp? 1 : a.timestamp < b.timestamp? -1 : 0;
    }
    /**
     * Special function to compare two object's status.
     * @param a A case report as an object
     * @param b A case report as an object
     * @param criteria ReportSearchCriteria 
     */
    private static compareStatus(a, b, criteria: ReportSearchCriteria) {
        const result = 
            ((a.healthRisk && b.healthRisk) || (!a.healthRisk && !b.healthRisk))? 
                0 : a.healthRisk? -1 : 1;

                return (criteria.sortDirection === "desc")? result : result * -1;
    }

    private static compareHealthRisk(a, b, criteria) { 
        const result = 
            (!this.hasNonNullField(a, "healthRisk") && !this.hasNonNullField(b, "healthRisk"))? 0
                : (!this.hasNonNullField(a, "healthRisk") && this.hasNonNullField(b, "healthRisk"))? -1
                    :  (this.hasNonNullField(a, "healthRisk") && !this.hasNonNullField(b, "healthRisk"))? 1
                            : (a.healthRisk.readableId < b.healthRisk.readableId)? 1
                                : (a.healthRisk.readableId > b.healthRisk.readableId)? -1
                                    : 0;
        return (criteria.sortDirection === "desc")? result : result * -1;
    }
    /**
     * Compares two case reports by passing in the fields it is going to be compared on.
     * This is a special case comparison algorithm since it can compare case reports with a field in the form of:
     *  reportA.field1 and reportA.field1.field2
     * It should check if each of the fields is undefined so that all cases where one of the fields are undefined
     * clusters together either at the bottom of the list or the top of the list depening on the criteria.sortDirection
     * @param aNullable Field 1 of case report a
     * @param bNullable Field 1 of case report b
     * @param criteria ReportSearchCriteria
     * @param aField Field 2 of case report a, passed in as a string. Defaults to aNullable if not specified 
     * @param bField Field 2 of case report b, passed in as a string. Defaults to bNullable if not specified
     */
    private static compareNullableField(aNullable, bNullable, criteria: ReportSearchCriteria, 
        aField: string = aNullable, bField: string = bNullable) {
        // This function is pretty arcane, but trust me, it should work...
        const result = 
            (aNullable === undefined && bNullable === undefined)? 0
                : (aNullable === undefined && bNullable != undefined)? -1
                    :  (aNullable != undefined && bNullable === undefined)? 1
                        : (aField === aNullable)? // No need to compare Nullable[field]
                            (aField < bField)? -1
                                :  (aField > bField)? 1 : 0
                            : this.compareNullableField(aNullable[aField], bNullable[bField], criteria);
        return (criteria.sortDirection === "desc")? result : result * -1;
    }
    /**
     * Checks whether o has a field called field which is not null.
     * @param o Any object
     * @param field The field where we want to access data
     */
    private static hasNonNullField(o: any, field: string): boolean {
        return (o != null && o[field] != undefined && o[field] != null);
    }       
}


export class ReportSearchCriteria {
  sortColumn: string;
  sortDirection: string;
}
