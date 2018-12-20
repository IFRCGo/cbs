import { Component, OnInit, PipeTransform, Pipe  } from '@angular/core';
import { Guid } from '@dolittle/core';
import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import { CreateProject } from '../CreateProject';
import { NationalSociety } from '../../NationalSocieties/NationalSociety'
import { AllNationalSocieties } from '../../NationalSocieties/AllNationalSocieties'
import { User } from '../../Users/User';
import { AllUsers } from '../../Users/AllUsers';

interface FormData {
    selectedSociety: string;
    selectedOwner: string;
    projectName: string;
    selectedSurveillanceOptionId: string;
}

@Component({
    selector: 'cbs-add-project',
    templateUrl: './add-project.component.html',
    styleUrls: ['./add-project.component.scss']
})
export class AddProjectComponent implements OnInit {
    societies: NationalSociety[];
    owners: User[];
    projectOwners: User[];
    surveillanceOptions: object[];
    formError: string = '';
    isFormSubmitted: boolean = false;
    formData: FormData;

    constructor(
        private commandCoordinator: CommandCoordinator,
        private queryCoordinator: QueryCoordinator
    ) {}

    ngOnInit() {
        this.resetForm();

        this.allNationalSocieties();
        this.surveillanceOptions = [
            { id: '0', name: 'Single Reports' },
            { id: '1', name: 'Aggregated Reports' },
            { id: '2', name: 'Both' }
        ];
    }

    allNationalSocieties = () => {
        console.log("AllNationalSocieties");
        let query = new AllNationalSocieties();
        this.queryCoordinator.execute(query).then(result => {
            if (result.success) {
                console.log("AllNationalSocieties", result);
                const sortItems = result.items;
                this.societies = [...sortItems];
            } else {
                console.error(result);
                this.formError = `Error getting national societies: ${result}`;
            }

        });
    };


    resetForm() {
        this.formError = '';
        this.isFormSubmitted = false;
        this.formData = { selectedSociety: '', selectedOwner: '', projectName: '', selectedSurveillanceOptionId: '' };
    }

    findInArray(id:string, array: any[]) {
        if (!array) {
            return {};
        }
        const found = array.find(element => element.id === id);
        return found || {};            
    }

    onSocietyChange(selectedNationalSocietyId: string) {
        this.getProjectOwners(selectedNationalSocietyId);
    }

    getProjectOwners(nationalSocietyId: string) {
        this.queryCoordinator.execute(new AllUsers()).then(
            users => {
                this.projectOwners = users;
            },
            error => {
                this.formError = `Error getting project owners: ${error}`;
                console.error(error);
            }
        );
    }

    async addProject() {
        const projectId = Guid.create();
        const { selectedOwner, selectedSociety, selectedSurveillanceOptionId, projectName } = this.formData;

        let command = new CreateProject();
        command.id = projectId;
        command.dataOwnerId = selectedOwner;
        command.name = projectName;
        command.nationalSocietyId = selectedSociety;
        //project.surveillanceContext = selectedSurveillanceOptionId;

        await this.commandCoordinator.handle(command);
        console.log('project created successfully');
        this.isFormSubmitted = true;
    }
}
