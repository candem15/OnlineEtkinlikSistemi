import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminCategoryComponent } from './admin-category.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AdminCategoryComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: AdminCategoryComponent }
    ]),
    MatFormFieldModule, MatInputModule, MatButtonModule, MatTableModule,MatIconModule,
    ReactiveFormsModule
  ]
})
export class AdminCategoryModule { }
