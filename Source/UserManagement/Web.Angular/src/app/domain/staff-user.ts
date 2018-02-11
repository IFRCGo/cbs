export class StaffUser {
    firstName: string;
    lastName: string;
    email: string;

    constructor(o: any) {
        this.firstName = o.firstName;
        this.lastName = o.lastName;
        this.email = o.email;
    }
}
