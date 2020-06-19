import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { TopSecretService } from './top-secret.service';
import { TopSecretRoutingModule } from './top-secret.routing-module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [IndexComponent],
  providers: [ TopSecretService ],
  imports: [
    CommonModule,
    TopSecretRoutingModule,
    SharedModule
  ]
})
export class TopSecretModule { }
