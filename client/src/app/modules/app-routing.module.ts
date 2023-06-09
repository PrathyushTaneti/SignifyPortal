import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { NavbarComponent } from "../navbar/navbar.component";
import { HomeComponent } from "../home/home.component";
import { AdminComponent } from "../admin/admin.component";
import { AuthGuardService } from "../services/auth-guard.service";
import { StudentDetailsComponent } from "../student-details/student-details.component";


const routes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: NavbarComponent,
        children: [
            {
                path: '',
                redirectTo: 'welcome',
                pathMatch: 'full'
            },
            {
                path: 'welcome',
                component: HomeComponent
            }
        ]
    },
    {
        path: 'admin/:id/:name',
        component: AdminComponent,
        canActivate: [AuthGuardService],
        children: [
            {
                path: '',
                redirectTo: 'student-details',
                pathMatch: 'full'
            },
            {
                path: 'student-details',
                component: StudentDetailsComponent,
                canActivateChild: [AuthGuardService]
            }
        ]
    }
];


@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]

})



export class AppRouting {

}