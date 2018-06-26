import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { DiscothequeModel } from '../Discotheque.Model';
import { DiscothequeService } from '../Services/Discotheque.service';

@Component({
    selector: 'edit-discotheque',
    templateUrl: './editDiscotheque.component.html',
    providers: [DiscothequeService]
})
export class editDiscothequeComponent implements OnInit {

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

    onSubmit() {
        var formData = this.currentModel;
        this.discothequeService.updateDiscotheque(formData).subscribe(data => {
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