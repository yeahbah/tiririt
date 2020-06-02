import { NgModule } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  imports: [
    MatInputModule,
    MatTableModule,
    MatIconModule
  ],  
  exports: [
    // CommonModule,
    MatInputModule,
    MatTableModule,
    MatIconModule
  ]
})
export class NgMaterialModule { }
