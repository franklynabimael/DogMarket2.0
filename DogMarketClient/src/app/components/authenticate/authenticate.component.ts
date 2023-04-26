import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LogingDTO } from '../../interfaces/logingdto';
import { Logingresponse } from '../../interfaces/responses/logingresponse';
import { UserService } from '../../services/user.service';


@Component({
  selector: 'app-authenticate',
  templateUrl: './authenticate.component.html',
  styleUrls: ['./authenticate.component.css'],
})
export class AuthenticateComponent implements OnInit {
  errorMessage: any = null;
  loginForm: FormGroup;
  private returnUrl!: string;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private userService: UserService,
    private toastr: ToastrService,
    private http: HttpClient
  ) {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });

    localStorage.clear();
  }

  private assertInputsProvided(): void {
    if (!this.loginForm) {
      throw new Error('The required input [userId] was not provided');
    }
  }

  ngOnInit(): void {
    this.assertInputsProvided();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  validateControl = (controlName: string) => {
    return (
      this.loginForm.get(controlName).invalid &&
      this.loginForm.get(controlName).touched
    );
  };

  hasError = (controlName: string, errorName: string) => {
    return this.loginForm.get(controlName).hasError(errorName);
  };

  loginUser = (loginFormValue: any) => {
    const login = { ...loginFormValue };
    const userForAuth: LogingDTO = {
      username: login.username,
      password: login.password,
    };
    this.userService.postLoging(userForAuth).subscribe({
      next: (res: Logingresponse) => {
        this.toastr.success('You are now logged in!', 'Success!', {
          timeOut: 3000,
          enableHtml: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          tapToDismiss: true,
          toastClass: 'ngx-toastr',
        });
        localStorage.setItem('token', res.token);
        console.log(res);
        this.userService.sendAuthStateChangeNotification(res.isauthsuccessful);
        this.router.navigate(['']);
      },
      error: (error: HttpErrorResponse) => {
        this.errorMessage = error.error;
        this.router.navigate(['/login'], {
          queryParams: { returnUrl: this.router.url },
        });
        this.toastr.error(`${this.errorMessage.message}`, 'Error', {
          timeOut: 3000,
          enableHtml: true,
          progressBar: true,
          progressAnimation: 'decreasing',
          tapToDismiss: true,
          toastClass: 'ngx-toastr',
        });
      },
    });
  };
}
