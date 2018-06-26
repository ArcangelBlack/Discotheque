import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { CompanyModel } from '../Company.Model';
import { CompanyService } from '../Services/Company.service';

@Component({
    selector: 'edit-company',
    templateUrl: './editCompany.component.html',
    providers: [CompanyService]
})
export class editCompanyComponent implements OnInit {

    currentModel: CompanyModel = new CompanyModel();
    ID: string | undefined;
    private data: any;

    constructor(private companyService: CompanyService, private route: Router, private _routeParams: ActivatedRoute) { }

    ngOnInit(): void {
        this.ID = this._routeParams.snapshot.params['Id'];

        if (this.ID != null) {
            this.companyService.editCompany(this.ID).subscribe(data => {
                this.currentModel = <CompanyModel>data;
            }, error => {
                if (error) {
                    alert("An Error has occured please try again after some time !");
                }
            })
        }
    }

    onSubmit() {
        var formData = this.currentModel;
        this.companyService.updateCompany(formData).subscribe(data => {
            if (data == true) {
                alert("Your Data Update Successfully ");
                this.route.navigate(['Companies']);
            }
        }, error => {
            if (error) {
                alert("An Error has occured please try again after some time !");
            }
        })
    }
}