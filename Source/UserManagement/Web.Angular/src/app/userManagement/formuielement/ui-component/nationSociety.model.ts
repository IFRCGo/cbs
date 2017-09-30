export class NationalSociety {
    public country: string;
    public countryCode: number;

    constructor(o: any) {
        this.country = o.country;
        this.countryCode = o.countryCode;
    }
}
