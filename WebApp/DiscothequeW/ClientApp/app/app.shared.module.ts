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

import { categoriesComponent } from './components/categories/categories.component';
import { detailsCategoryComponent } from './components/categories/detailsCategory/detailsCategory.component';
import { newCategoryComponent } from './components/categories/newCategory/newCategory.component';
import { editCategoryComponent } from './components/categories/editCategory/editCategory.component';

import { companiesComponent } from './components/companies/companies.component';
import { detailsCompanyComponent } from './components/companies/detailsCompany/detailsCompany.component';
import { newCompanyComponent } from './components/companies/newCompany/newCompany.component';
import { editCompanyComponent } from './components/companies/editCompany/editCompany.component';

import { discothequesComponent } from './components/discotheques/discotheques.component';
import { detailsDiscothequeComponent } from './components/discotheques/detailsDiscotheque/detailsDiscotheque.component';
import { newDiscothequeComponent } from './components/discotheques/newDiscotheque/newDiscotheque.component';
import { editDiscothequeComponent } from './components/discotheques/editDiscotheque/editDiscotheque.component';

import { employeesComponent } from './components/employees/employees.component';
import { detailsEmployeeComponent } from './components/employees/detailsEmployee/detailsEmployee.component';
import { newEmployeeComponent } from './components/employees/newEmployee/newEmployee.component';
import { editEmployeeComponent } from './components/employees/editEmployee/editEmployee.component';

import { usersComponent } from './components/users/users.component';
import { detailsUserComponent } from './components/users/detailsUser/detailsUser.component';
import { newUserComponent } from './components/users/newUser/newUser.component';
import { editUserComponent } from './components/users/editUser/editUser.component';

import { downloadDocumentComponent } from './components/documents/downloadDocument/downloadDocument.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,

        categoriesComponent,
        detailsCategoryComponent,
        newCategoryComponent,
        editCategoryComponent,

        companiesComponent,
        detailsCompanyComponent,
        newCompanyComponent,
        editCompanyComponent,

        discothequesComponent,
        detailsDiscothequeComponent,
        newDiscothequeComponent,
        editDiscothequeComponent,

        employeesComponent,
        detailsEmployeeComponent,
        newEmployeeComponent,
        editEmployeeComponent,

        usersComponent,
        detailsUserComponent,
        newUserComponent,
        editUserComponent,

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

            { path: 'categories', component: categoriesComponent },
            { path: 'categories/edit/:Id', component: editCategoryComponent },
            { path: 'categories/details/:Id', component: detailsCategoryComponent },
            { path: 'categories/new', component: newCategoryComponent },

            { path: 'companies', component: companiesComponent },
            { path: 'companies/edit/:Id', component: editCompanyComponent },
            { path: 'companies/details/:Id', component: detailsCompanyComponent },
            { path: 'companies/new', component: newCompanyComponent },

            { path: 'discotheques', component: discothequesComponent },
            { path: 'discotheques/edit/:Id', component: editDiscothequeComponent },
            { path: 'discotheques/details/:Id', component: detailsDiscothequeComponent },
            { path: 'discotheques/new', component: newDiscothequeComponent },

            { path: 'employees', component: employeesComponent },
            { path: 'employees/edit/:Id', component: editEmployeeComponent },
            { path: 'employees/details/:Id', component: detailsEmployeeComponent },
            { path: 'employees/new', component: newEmployeeComponent },

            { path: 'users', component: usersComponent },
            { path: 'users/edit/:Id', component: editUserComponent },
            { path: 'users/details/:Id', component: detailsUserComponent },
            { path: 'users/new', component: newUserComponent },

            { path: 'download', component: downloadDocumentComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
