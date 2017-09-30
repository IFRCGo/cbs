export class DistrictSociety {

    public place: string;
    public countryCode: number;

    constructor(o: any) {
        this.place = o.place;
        this.countryCode = o.countryCode;
    }
}
