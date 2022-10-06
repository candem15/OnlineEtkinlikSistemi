import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterLoginComponent } from './register-login/register-login.component';
import { AdminEventComponent } from './admin-event/admin-event.component';
import { AdminEventModule } from './admin-event/admin-event.module';
import { RegisterLoginModule } from './register-login/register-login.module';
import { BaseComponent } from './base/base.component';



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule
  ]
})
export class ComponentsModule { }
