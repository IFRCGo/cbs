import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../../core/project.service';

@Component({
    selector: 'cbs-projectlist',
    templateUrl: './projectlist.component.html',
    styleUrls: ['./projectlist.component.scss']
})
export class ProjectlistComponent implements OnInit {

    constructor(private projectService: ProjectService) { }

    ngOnInit() {
    }
}
