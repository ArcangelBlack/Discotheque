import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { DiscothequeModel } from '../Discotheque.Model';
import { DiscothequeService } from '../Services/Discotheque.service';

@Component({
    selector: 'details-discotheque',
    templateUrl: './detailsDiscotheque.component.html',
    providers: [DiscothequeService]
})
export class detailsDiscothequeComponent implements OnInit {

    currentModel: DiscothequeModel = new DiscothequeModel();
    ID: string | undefined;
    private data: any;

    constructor(private discothequeService: DiscothequeService, private route: Router, private _routeParams: ActivatedRoute) {

    }

    ngOnInit(): void {
        this.ID = this._routeParams.snapshot.params['Id'];

        if (this.ID != null) {
            this.discothequeService.editDiscotheque(this.ID).subscribe(data => {
                this.currentModel = <DiscothequeModel>data;
            }, error => {
                if (error) {
                    alert("An Error has occured please try again after some time !");
                }
            })
        }
    }
}