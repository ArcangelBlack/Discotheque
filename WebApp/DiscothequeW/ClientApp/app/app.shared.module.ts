import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

import { discothequesComponent } from './components/discotheques/discotheques.component';
import { detailsDiscothequeComponent } from './components/discotheques/detailsDiscotheque/detailsDiscotheque.component';
import { newDiscothequeComponent } from './components/discotheques/newDiscotheque/newDiscotheque.component';
import { editDiscothequeComponent } from './components/discotheques/editDiscotheque/editDiscotheque.component';

import { employeesComponent } from './components/employees/employees.component';
import { detailsEmployeeComponent } from './components/employees/detailsEmployee/detailsEmployee.component';
import { newEmployeeComponent } from './components/employees/newEmployee/newEmployee.component';
import { editEmployeeComponent } from './components/employees/editEmployee/editEmployee.component';

import { downloadDocumentComponent } from './components/documents/downloadDocument/downloadDocument.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        discothequesComponent,
        detailsDiscothequeComponent,
        newDiscothequeComponent,
        editDiscothequeComponent,
        employeesComponent,
        detailsEmployeeComponent,
        newEmployeeComponent,
        editEmployeeComponent,
        downloadDocumentComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'discotheques', component: discothequesComponent },
            { path: 'discotheques/edit/:Id', component: editDiscothequeComponent },
            { path: 'discotheques/details/:Id', component: detailsDiscothequeComponent },
            { path: 'discotheques/new', component: newDiscothequeComponent },

            { path: 'employees', component: employeesComponent },
            { path: 'employees/edit/:Id', component: editEmployeeComponent },
            { path: 'employees/details/:Id', component: detailsEmployeeComponent },
            { path: 'employees/new', component: newEmployeeComponent },

            { path: 'download', component: downloadDocumentComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
