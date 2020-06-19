import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuthService } from '../../core/authentication/auth.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit { 

  returnUrl: string;  
  loginForm = this.formBuilder.group({
    username: ['', Validators.required],
    password: ['', Validators.required],
    rememberMe: [false]
  });

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService, 
    private router: Router,
    private spinner: NgxSpinnerService) { }    
  
    title = "Login";
    
    login() {     
      this.spinner.show();
      this.authService.login();
    }   

    ngOnInit() {
      this.returnUrl = "http://localhost:4200/home";
    }

    onSubmit() {
      this.spinner.show();
      console.log('submit');
            
    }

    register() {
      this.router.navigate(['/register']);
    }
}