export class ReservationModel {

    checkinDate: string;
    checkoutDate: string;
    numberOfAdults: number;
    numberOfChildren: number;
    numberOfRooms: number;

    constructor() {
       // data = data || {};
        this.checkinDate = "";
        this.checkoutDate = "";
        this.numberOfAdults = 0;
        this.numberOfChildren = 0;
        this.numberOfRooms = 0;
    }
}

