import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminCityComponent } from './admin-city.component';
import { RouterModule } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AdminCityComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: AdminCityComponent }
    ]),
    MatFormFieldModule, MatInputModule, MatButtonModule, MatTableModule, MatIconModule,
    ReactiveFormsModule
  ]
})
export class AdminCityModule { }
