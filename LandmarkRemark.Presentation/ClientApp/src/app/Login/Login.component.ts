import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AlertService } from '../services/alert.service';
import { UserService } from '../services/user.service';


@Component({
  selector: 'app-home',
  templateUrl: './Login.component.html',
})

export interface ILoginModel {
  Username: string,
  Password: string
}

export class LoginComponent {
  loginForm: FormGroup;
  loginModel: ILoginModel = {
    Username: '',
    Password: ''
  }
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private alertService: AlertService) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      Username: ['', Validators.required],
      Password: ['', Validators.required]
    });
    
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  onSubmit() {
    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    const loginModel: ILoginModel = this.loginForm.value as ILoginModel;

    this.authService.login(loginModel, () => {
      //if the user is redirected to the login page from a restricted page, he is redirected to the same again after login
      this.router.navigate([this.authService.lastRestrictedPage || '/']);
    });

    this.userService.getByUserName(this.f.username.value)
      .subscribe(
      data => {
        if (data > 0) {
          this.router.navigate([this.returnUrl]);
            localStorage.setItem('currentUser', this.f.username.value);
            localStorage.setItem('currentId', data.toString());
          }
        },
        error => {
          this.alertService.error(error);
        });
  }
}



