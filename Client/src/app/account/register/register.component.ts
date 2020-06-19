import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize } from 'rxjs/operators'
import { AuthService } from '../../core/authentication/auth.service';
import { FormBuilder, Validators } from '@angular/forms';
import { UserRegistration }    from '../../shared/models/user.registration';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  success: boolean;
  error: string;
  // userRegistration: UserRegistration = { userName: '', first: '', email: '', password: ''};
  submitted: boolean = false;

  registrationForm = this.formBuilder.group({
    userName: ['', Validators.required],
    emailAddress: ['', Validators.email],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    password: ['', Validators.required]
  });  

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService, 
    private spinner: NgxSpinnerService) {
   
  }

  ngOnInit() {
  }

  onSubmit() { 

    this.spinner.show();

    let formValue = this.registrationForm.value;

    this.authService.register(formValue)
      .pipe(finalize(() => {
        this.spinner.hide();
      }))  
      .subscribe(
        result => {         
          if(result) {
            this.success = true;
          }
      },
      error => {
        console.log(error);
        this.error = error;       
      });
  }
}