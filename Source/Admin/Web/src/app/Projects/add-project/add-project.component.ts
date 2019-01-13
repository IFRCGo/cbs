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

    resetForm() {
        this.formError = '';
        this.isFormSubmitted = false;
        this.formData = { selectedSociety: '', selectedOwner: '', projectName: '', selectedSurveillanceOptionId: '' };
    }

    findInArray(id: string, array: any[]) {
        if (!array) {
            return {};
        }

        console.log("findInArray", id);

        const found = array.find(element => element.id === id);
        return found || {};            
    }

    onSocietyChange(selectedNationalSocietyId: string) {
        this.getProjectOwners(selectedNationalSocietyId);
    }

    allNationalSocieties = () => {
        console.log("AllNationalSocieties");
        this.formData.selectedSociety = '';

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

    getProjectOwners(nationalSocietyId: string) {
        console.log("getProjectOwners");
        this.formData.selectedOwner = '';;

        let query = new AllUsers();
        query.nationalSocietyId = nationalSocietyId;
        this.queryCoordinator.execute(query).then(result => {
            if (result.success) {
                console.log("getProjectOwners", result);
                const sortItems = result.items;
                this.projectOwners = [...sortItems];
            } else {
                console.error(result);
                this.formError = `Error getting project projectOwners: ${result}`;
            }
        });
    }

    addProject = () => {

        const projectId = Guid.create();
        const { selectedOwner, selectedSociety, selectedSurveillanceOptionId, projectName } = this.formData;
        console.log('addProject' + '\n selectedOwner:' + selectedOwner + '\n selectedSociety:' + selectedSociety + '\n projectName:' + projectName);

        let command = new CreateProject();
        command.id = projectId;
        command.name = projectName;
        command.nationalSocietyId = selectedSociety;
        command.dataOwnerId = selectedOwner;
        command.surveillanceContext = 0;//selectedSurveillanceOptionId;

        console.log(command);

        this.commandCoordinator.handle(command).then(response => {
                console.log(response);
            if (response.success) {
                console.log('Successfully create a new health risk!');
                this.isFormSubmitted = true;
            } else {
                if (!response.passedSecurity) { // Security error
                    console.log('Could not create a new project because of security issues');
                } else {
                    const errors = response.allValidationMessages.join('\n');
                    console.log('Could not create a new project :\n' + errors);
                }
                this.formError = "Could not create a new project.";

                this.isFormSubmitted = false;
            }
        }).catch(response => {
            console.log(response);

            if (!response.passedSecurity) { // Security error
                console.log('Could not create a new project because of security issues');
            } else {
                const errors = response.allValidationMessages.join('\n');
                console.log('Could not create a new project:\n' + errors);
            }

            this.formError = "Could not create a new project.";
            this.isFormSubmitted = false;
        });
    }
}