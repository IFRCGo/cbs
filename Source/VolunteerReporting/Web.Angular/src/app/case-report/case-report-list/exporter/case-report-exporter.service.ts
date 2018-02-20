import { Injectable } from '@angular/core';
import * as json2csv from 'json2csv'
import { CaseReportForListing } from '../../../shared/models/case-report-for-listing.model';

import "fs";
import { writeFile } from 'fs';

@Injectable()
export class CaseReportExporter {
    constructor() { }
    
    exportToCsv(listedReports: Array<CaseReportForListing>, fields: Array<string>) {
        let result = json2csv({data: listedReports, fields: fields})
        console.log(result);
        writeFile("test.csv", listedReports);
        
     }
}
