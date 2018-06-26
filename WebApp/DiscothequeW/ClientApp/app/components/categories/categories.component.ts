import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { CategoryModel } from '../categories/Category.Model';

@Component({
    selector: 'categories',
    templateUrl: './categories.component.html'
})
export class categoriesComponent {
    public CategoriesList: CategoryModel[] | undefined;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Category/GetAll').subscribe(result => {
            this.CategoriesList = result.json();
        }, error => console.error(error));
    }
}