import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { CompanyModel } from '../Company.Model';
import { CompanyService } from '../Services/Company.service';

@Component({
    selector: 'new-company',
    templateUrl: './newCompany.component.html',
    providers: [CompanyService]
})
export class newCompanyComponent {

    currentModel: CompanyModel = new CompanyModel();
    ID: string | undefined;
    private data: any;

    constructor(private companyService: CompanyService, private route: Router, private _routeParams: ActivatedRoute) { }

    onSubmit() {
        var formData = this.currentModel;
        this.companyService.addCompany(formData).subscribe(data => {
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