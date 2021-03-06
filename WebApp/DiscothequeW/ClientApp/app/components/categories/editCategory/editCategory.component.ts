﻿import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { CategoryModel } from '../Category.Model';
import { CategoryService } from '../Services/Category.service';

@Component({
    selector: 'edit-category',
    templateUrl: './editCategory.component.html',
    providers: [CategoryService]
})
export class editCategoryComponent implements OnInit {

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

    onSubmit() {
        var formData = this.currentModel;
        this.categoryService.updateCategory(formData).subscribe(data => {
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