import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { CoursesComponent } from './courses/courses.component';
import { AboutComponent } from './about/about.component';
import {
  MatNativeDateModule, MatListModule, MatDividerModule, MatCardModule,
  MatExpansionModule, MatInputModule, MatButtonModule, MatOptionModule, MatSelectModule
} from '@angular/material';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { DataService } from './services/data.service';
import { QuestionsComponent } from './questions/questions.component';
import { AdministrationComponent } from './administration/administration.component';
import { QuestionsService } from './services/questions.service';
import { HttpClientModule } from '@angular/common/http';
import { UserService } from './services/user.service';
import { HeaderComponent } from './header/header.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    CoursesComponent,
    AboutComponent,
    QuestionsComponent,
    AdministrationComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatNativeDateModule,
    MatListModule,
    MatDividerModule,
    MatCardModule,
    MatExpansionModule,
    MatInputModule,
    MatButtonModule,
    HttpClientModule,
    MatOptionModule,
    MatSelectModule
  ],
  providers: [DataService, QuestionsService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
