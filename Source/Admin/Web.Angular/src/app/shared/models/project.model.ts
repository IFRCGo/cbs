import { NationalSociety } from './index';
import { User } from './user.model';

export class Project {
    id: string;
    name: string;
    nationalSociety: NationalSociety;
    projectOwner: User;
}