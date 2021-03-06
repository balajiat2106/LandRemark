import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AgmCoreModule } from "@agm/core";

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { RegistrationComponent } from './Registration/Registration.component';
import { LoginComponent } from './Login/Login.component';
import { AlertComponent } from './directive/UserAlert.component';

import { UserService } from './services/user.service';
import { AuthenticationService } from './services/authentication.service';
import { AlertService } from './services/alert.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    RegistrationComponent,
    LoginComponent,
    AlertComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegistrationComponent }
    ]),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyC7muZkX8wz4TcwYmc-ycC8fKlVygs_XLU'
    }),
  ],
  providers: [AlertService, UserService, AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
