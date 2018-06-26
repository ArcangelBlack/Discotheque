import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { UserModel } from '../users/User.Model';

@Component({
    selector: 'users',
    templateUrl: './users.component.html'
})
export class usersComponent {
    public UsersList: UserModel[] | undefined;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/User/GetAll').subscribe(result => {
            this.UsersList = result.json();
        }, error => console.error(error));
    }
}