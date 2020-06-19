import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeShellComponent } from './home-shell.component';
import { HomeHeaderComponent } from './home-header/home-header.component';
import { NgMaterialModule } from 'src/app/ngmaterial/ngmaterial.module';

@NgModule({
  declarations: [HomeShellComponent, HomeHeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    NgMaterialModule
  ]
})
export class HomeShellModule { }
