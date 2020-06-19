import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AuthService } from '../core/authentication/auth.service';
import { AccountRoutingModule } from './account.routing-module';
import { SharedModule } from '../shared/shared.module';
import { MyFeedService } from '../my-feed/my-feed.service';

@NgModule({
  declarations: [
    RegisterComponent, 
    LoginComponent    
  ],
  imports: [
    CommonModule,    
    ReactiveFormsModule,
    AccountRoutingModule,
    SharedModule
  ],
  providers: [AuthService, MyFeedService],
  schemas: [NO_ERRORS_SCHEMA]
})
export class AccountModule { }
