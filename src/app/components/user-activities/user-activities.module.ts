import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { UserActivitiesComponent } from './user-activities.component';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    UserActivitiesComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: UserActivitiesComponent }
    ]),
    MatTableModule,
    MatIconModule,
    MatSelectModule,
    MatButtonModule,
  ]
})
export class UserActivitiesModule { }
