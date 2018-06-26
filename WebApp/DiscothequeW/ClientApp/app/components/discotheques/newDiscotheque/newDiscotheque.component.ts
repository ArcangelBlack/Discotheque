﻿import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { DiscothequeModel } from '../Discotheque.Model';
import { DiscothequeService } from '../Services/Discotheque.service';

@Component({
    selector: 'new-discotheque',
    templateUrl: './newDiscotheque.component.html',
    providers: [DiscothequeService]
})
export class newDiscothequeComponent {

    currentModel: DiscothequeModel = new DiscothequeModel();
    ID: string | undefined;
    private data: any;

    constructor(private discothequeService: DiscothequeService, private route: Router, private _routeParams: ActivatedRoute) { }

    onSubmit() {
        var formData = this.currentModel;
        this.discothequeService.addDiscotheque(formData).subscribe(data => {
            if (data == true) {
                alert("Your Data Update Successfully ");
                this.route.navigate(['discotheques']);
            }
        }, error => {
            if (error) {
                alert("An Error has occured please try again after some time !");
            }
        })
    }
}