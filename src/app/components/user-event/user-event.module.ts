import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserEventComponent } from './user-event.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import {MatDatepickerModule} from '@angular/material/datepicker';

@NgModule({
  declarations: [
    UserEventComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: UserEventComponent }
    ]),
    ReactiveFormsModule,
    MatDatepickerModule
  ]
})
export class UserEventModule { }
