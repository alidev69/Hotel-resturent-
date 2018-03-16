import { Component } from '@angular/core';
import { ReservationModel } from '../models/ReservationModel';

@Component({
    selector: 'reservation',
    templateUrl: './reservation.component.html'
})
export class ReservationComponent {
    model: ReservationModel;
    
    roomList = ['Single Room', 'Double Room', 'King Suit'];
    
    getNameList() {
        this.model = new ReservationModel();
    }
    onSubmit() {
        alert("form submitted");
    }  
 
}


