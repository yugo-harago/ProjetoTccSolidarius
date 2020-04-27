import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { LoginComponent } from './account/login/login.component';
import { NewAccountComponent } from './account/new-account/new-account.component';
import { UserAccountComponent } from './account/user-account/user-account.component';
import { UserComponent } from './user/user.component';
import { StudentUserRecebidosComponent } from './user/student-user/student-user-recebidos/student-user-recebidos.component';
import { ConcluidosComponent } from './account/concluidos/concluidos.component';

const routes: Routes = [
    {
      path: '',
      component: LandingPageComponent
    },
    {
      path: 'login',
      component: LoginComponent
    },
    {
      path: 'new-account',
      component: NewAccountComponent
    },
    {
      path: 'user-account',
      component: UserAccountComponent
    },
    {
        path: 'user',
        children: [
            {
                path: '',
                component: UserComponent
            },
            {
                path: 'concluidos',
                component: ConcluidosComponent
            }
        ]

    }
  ];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
