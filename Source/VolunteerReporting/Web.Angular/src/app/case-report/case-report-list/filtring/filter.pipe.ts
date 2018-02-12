import {Pipe, PipeTransform} from "@angular/core"

@Pipe({
    name: "filter",
    pure: false
})

export class Filter implements PipeTransform{
    transform(reports: Array<any>, value: string){
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
                    if (report.healthRisk) {
                        list.push(report);
                    }
                    break;
                case "error":
                    if (!report.healthRisk) {
                        list.push(report);
                    }
                    break;
                case "unknownSender":
                    if (
                        report.dataCollector?
                            report.dataCollector.fullName?
                                (report.dataCollector.fullName === "")? true
                                    : false
                                : true
                            : true
                    ) {
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