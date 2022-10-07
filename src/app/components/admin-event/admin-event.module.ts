import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminEventComponent } from './admin-event.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    AdminEventComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: AdminEventComponent }
    ]),
    MatTableModule,
    MatIconModule,
    MatButtonModule
  ],
  exports: [

  ]
})
export class AdminEventModule { }
