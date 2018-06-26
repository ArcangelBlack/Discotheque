import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { DiscothequeModel } from '../discotheques/Discotheque.Model';

@Component({
    selector: 'discotheques',
    templateUrl: './discotheques.component.html'
})
export class discothequesComponent {
    public DiscothequesList: DiscothequeModel[] | undefined;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Discotheque/GetAll').subscribe(result => {
            this.DiscothequesList = result.json();
        }, error => console.error(error));
    }
} 