export class StaffUser {
    fullName: string;
    displayName: string;
    email: string;

    constructor(o: any) {
        this.fullName = o.fullName;
        this.displayName = o.displayName;
        this.email = o.email;
    }
}
