export class Location {
    notSet: Location = new Location();
    constructor() {
        this.latitude = -1;
        this.longitude = -1;
    }

    latitude: number;
    longitude: number;

    //isNotSet: function() { return this.latitude == 0 && this.longitude == 0; }
}