import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {
    path: "profile", loadChildren: () => import("./components/profile/profile.module").then
      (module => module.ProfileModule), canActivate: [AuthGuard]
  },
  {
    path: "admin-event", loadChildren: () => import("./components/admin-event/admin-event.module").then
      (module => module.AdminEventModule), canActivate: [AuthGuard]
  },
  {
    path: "admin-category", loadChildren: () => import("./components/admin-category/admin-category.module").then
      (module => module.AdminCategoryModule), canActivate: [AuthGuard]
  },
  {
    path: "user-event", loadChildren: () => import("./components/user-event/user-event.module").then
      (module => module.UserEventModule), canActivate: [AuthGuard]
  },
  {
    path: "admin-city", loadChildren: () => import("./components/admin-city/admin-city.module").then
      (module => module.AdminCityModule), canActivate: [AuthGuard]
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
