import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DataCollector } from '../DataCollector';
import { Location } from '@angular/common';
import { Sex } from '../../Sex';
import { Language } from '../../Language';
import { QueryCoordinator } from '@dolittle/queries';
import { DataCollectorById } from '../DataCollectorById';

@Component({
    templateUrl: './details.html',
    styleUrls: ['./details.scss']
})
export class Details implements OnInit {

    queryCoordinator: QueryCoordinator;

    dataCollector: DataCollector;

    constructor(
        private route: ActivatedRoute,
        private location: Location
    ) {
    }

    ngOnInit(): void {
        this.queryCoordinator = new QueryCoordinator();
        this.getDataCollector();
    }

    getDataCollector(): void {
        const id = this.route.snapshot.paramMap.get('id');
        let query = new DataCollectorById();
        query.dataCollectorId = id;
        this.queryCoordinator.execute(query)
            .then(response => {
                if (response.success) {
                    if (response.items.length > 0) {
                        this.dataCollector = response.items[0]
                    } else {
                        console.error(response)
                    }
                } else {
                    console.error(response);
                }
            })
            .catch(response => {
                console.error(response);
            })
    }

    getSexString(sex: number): string {
        return Sex[sex];
    }
    getLanguageString(lan: number): string {
        return Language[lan];
    }
    goBack(): void {
        this.location.back();
    }
}
