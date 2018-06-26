import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { CompanyModel } from '../companies/Company.Model';


@Component({
    selector: 'companies',
    templateUrl: './companies.component.html'
})
export class companiesComponent {
    public CompaniesList: CompanyModel[] | undefined;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Company/GetAll').subscribe(result => {
            this.CompaniesList = result.json();
        }, error => console.error(error));
    }
}