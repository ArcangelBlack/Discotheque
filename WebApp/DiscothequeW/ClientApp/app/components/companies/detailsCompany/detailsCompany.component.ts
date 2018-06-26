import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { CompanyModel } from '../Company.Model';
import { CompanyService } from '../Services/Company.service';

@Component({
    selector: 'details-company',
    templateUrl: './detailsCompany.component.html',
    providers: [CompanyService]
})
export class detailsCompanyComponent implements OnInit {

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

}