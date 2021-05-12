import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//forms module (for 2way binding)
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserOverviewComponent } from './user-overview/user-overview.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserHomepageComponent } from './user-homepage/user-homepage.component';

//Provides communication between Angular and API
import {HttpClientModule} from '@angular/common/http';
import { NavigationComponent } from './navigation/navigation.component';
import { MembersComponent } from './members/members.component';

@NgModule({
  declarations: [
    AppComponent,
    UserOverviewComponent,
    UserDetailComponent,
    UserHomepageComponent,
    NavigationComponent,
    MembersComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
