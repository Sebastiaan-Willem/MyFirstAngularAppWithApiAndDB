import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserHomepageComponent} from './user-homepage/user-homepage.component';
import { UserOverviewComponent} from './user-overview/user-overview.component';
import { UserDetailComponent} from './user-detail/user-detail.component';
import { MembersComponent} from './members/members.component';
import { RegisterComponent} from './register/register.component';

const routes: Routes = [
  {path: '', redirectTo: 'home', pathMatch:'full'},
  {path: 'home', component: UserHomepageComponent},
  {path: 'users', component: UserOverviewComponent},
  {path: 'userdetail/:id', component: UserDetailComponent},
  {path: 'members', component: MembersComponent},
  {path: 'register', component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
