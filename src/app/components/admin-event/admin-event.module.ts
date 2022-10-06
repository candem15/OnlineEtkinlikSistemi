import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminEventComponent } from './admin-event.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';


@NgModule({
  declarations: [
    AdminEventComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: AdminEventComponent }
    ]),
    MatTableModule
  ],
  exports: [

  ]
})
export class AdminEventModule { }
