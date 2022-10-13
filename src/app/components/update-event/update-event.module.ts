import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { UpdateEventComponent } from './update-event.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    UpdateEventComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: UpdateEventComponent }
    ]),
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    ReactiveFormsModule
  ]
})
export class UpdateEventModule { }
