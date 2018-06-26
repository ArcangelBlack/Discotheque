import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { CategoryModel } from '../Category.Model';
import { CategoryService } from '../Services/Category.service';

@Component({
    selector: 'new-category',
    templateUrl: './newCategory.component.html',
    providers: [CategoryService]
})
export class newCategoryComponent {

    currentModel: CategoryModel = new CategoryModel();
    ID: string | undefined;
    private data: any;

    constructor(private categoryService: CategoryService, private route: Router, private _routeParams: ActivatedRoute) { }

    onSubmit() {
        var formData = this.currentModel;
        this.categoryService.addCategory(formData).subscribe(data => {
            if (data == true) {
                alert("Your Data Update Successfully ");
                this.route.navigate(['categories']);
            }
        }, error => {
            if (error) {
                alert("An Error has occured please try again after some time !");
            }
        })
    }
}