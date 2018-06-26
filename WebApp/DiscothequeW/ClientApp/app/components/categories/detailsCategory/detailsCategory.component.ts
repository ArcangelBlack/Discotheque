import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { CategoryModel } from '../Category.Model';
import { CategoryService } from '../Services/Category.service';

@Component({
    selector: 'details-category',
    templateUrl: './detailsCategory.component.html',
    providers: [CategoryService]
})
export class detailsCategoryComponent implements OnInit {

    currentModel: CategoryModel = new CategoryModel();
    ID: string | undefined;
    private data: any;

    constructor(private categoryService: CategoryService, private route: Router, private _routeParams: ActivatedRoute) { }

    ngOnInit(): void {
        this.ID = this._routeParams.snapshot.params['Id'];

        if (this.ID != null) {
            this.categoryService.editCategory(this.ID).subscribe(data => {
                this.currentModel = <CategoryModel>data;
            }, error => {
                if (error) {
                    alert("An Error has occured please try again after some time !");
                }
            })
        }
    }
}