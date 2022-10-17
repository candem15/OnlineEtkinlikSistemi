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
    path: "create-event", loadChildren: () => import("./components/create-event/create-event.module").then
      (module => module.CreateEventModule), canActivate: [AuthGuard]
  },
  {
    path: "admin-city", loadChildren: () => import("./components/admin-city/admin-city.module").then
      (module => module.AdminCityModule), canActivate: [AuthGuard]
  },
  {
    path: "register", loadChildren: () => import("./components/register-login/register-login.module").then
      (module => module.RegisterLoginModule)
  },
  {
    path: "join-events", loadChildren: () => import("./components/join-events/join-events.module").then
      (module => module.JoinEventsModule), canActivate: [AuthGuard]
  },
  {
    path: "update-event", loadChildren: () => import("./components/update-event/update-event.module").then
      (module => module.UpdateEventModule), canActivate: [AuthGuard]
  },
  {
    path: "user-activities", loadChildren: () => import("./components/user-activities/user-activities.module").then
      (module => module.UserActivitiesModule), canActivate: [AuthGuard]
  },
  {
    path: "", loadChildren: () => import("./components/home/home.module").then
      (module => module.HomeModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
