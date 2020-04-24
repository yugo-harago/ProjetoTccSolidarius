import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentUserComponent } from './user/student-user/student-user.component';
import { MediatorComponent } from './user/mediator/mediator.component';
import { GiverUserComponent } from './user/giver-user/giver-user.component';
import { NewAccountComponent } from './account/new-account/new-account.component';
import { UserAccountComponent } from './account/user-account/user-account.component';
import { LoginComponent } from './account/login/login.component';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { UserComponent } from './user/user.component';
import { HttpClientModule } from '@angular/common/http';
import { StudentUserHeaderComponent } from './user/student-user/student-user-header/student-user-header.component';
import { GiverUserHeaderComponent } from './user/giver-user/giver-user-header/giver-user-header.component';

@NgModule({
  declarations: [
    AppComponent,
    StudentUserComponent,
    MediatorComponent,
    GiverUserComponent,
    NewAccountComponent,
    UserAccountComponent,
    LoginComponent,
    LandingPageComponent,
    UserComponent,
    StudentUserHeaderComponent,
    GiverUserHeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
