import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JoinEventsComponent } from './join-events.component';
import { RouterModule } from '@angular/router';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [
    JoinEventsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: JoinEventsComponent }
    ]),
    MatSelectModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule
  ]
})
export class JoinEventsModule { }
