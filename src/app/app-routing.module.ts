import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {
    path: "admin-event", loadChildren: () => import("./components/admin-event/admin-event.module").then
      (module => module.AdminEventModule), canActivate: [AuthGuard]
  },
  {
    path: "admin-category", loadChildren: () => import("./components/admin-category/admin-category.module").then
      (module => module.AdminCategoryModule), canActivate: [AuthGuard]
  },
  {
    path: "register", loadChildren: () => import("./components/register-login/register-login.module").then
      (module => module.RegisterLoginModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
