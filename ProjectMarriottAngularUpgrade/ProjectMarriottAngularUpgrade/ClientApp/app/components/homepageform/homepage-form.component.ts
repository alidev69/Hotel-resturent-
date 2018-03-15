import { Component, OnInit } from '@angular/core';
import { ReservationModel } from '../ReservationModel';

@Component({
    selector: 'homepage-form',
    templateUrl: './homepage-form.component.html',
    styleUrls: ['./homepage-form.component.css']
})
export class HomepageFormComponent implements OnInit {

    private model: ReservationModel;

    constructor(
        model = new ReservationModel()
    ) { }

    ngOnInit() {

    }
}
