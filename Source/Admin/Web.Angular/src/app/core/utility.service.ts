import { Injectable } from '@angular/core';

import { AddProject } from '../shared/models/add-project.model';

@Injectable()
export class UtilityService {

    constructor() { }

    createGuid() {
        function segment() {
            return Math.floor((1 + Math.random()) * 0x10000)
                .toString(16)
                .substring(1);
        }

        return segment() + segment() + '-' + segment() + '-' + segment() + '-' +
            segment() + '-' + segment() + segment() + segment();
    }
}
