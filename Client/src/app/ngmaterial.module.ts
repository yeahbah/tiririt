import { NgModule } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatBadgeModule } from '@angular/material/badge';
import { MatMenuModule } from '@angular/material/menu';


@NgModule({
  imports: [
    MatInputModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatTabsModule,
    MatCardModule,
    MatDividerModule,
    MatBadgeModule,
    MatMenuModule
  ],  
  exports: [
    // CommonModule,
    MatInputModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatTabsModule,
    MatCardModule,
    MatDividerModule,
    MatBadgeModule,
    MatMenuModule
  ]
})
export class NgMaterialModule { }
