import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AlertService } from '../services/alert.service';
import { AuthenticationService } from '../services/authentication.service';
import { IUserLogin } from '../SharedModels/UserLogin.interface';


@Component({
  selector: 'app-home',
  templateUrl: './Login.component.html',
})

export class LoginComponent {
  loginForm: FormGroup;
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthenticationService,
    private alertService: AlertService) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
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
    
    const loginModel: IUserLogin = this.loginForm.value as IUserLogin;
    
    this.authService.Login(loginModel)
      .subscribe(
        data => {
            this.router.navigate([this.returnUrl]);
            localStorage.setItem('currentUser', this.f.username.value);
            localStorage.setItem('currentId', data.toString());
        },
        () => {
              this.alertService.error("Login failed");
        });
  }
}



