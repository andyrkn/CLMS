import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CoursesComponent } from './courses/courses.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AboutComponent } from './about/about.component';
import { QuestionsComponent } from './questions/questions.component';
import { AdministrationComponent } from './administration/administration.component';
import { AddCourseComponent } from './courses/add-course/add-course.component';
import { AddQuestionComponent } from './questions/add-question/add-question.component';
const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent
  }, 
  {
    path: 'login',
    component: LoginComponent
  }, 
  {
    path: 'register',
    component: RegisterComponent
  }, 
  {
    path: 'courses',
    component: CoursesComponent
  },
  {
    path: 'courses/add',
    component: AddCourseComponent
  },  
  {
    path: 'about',
    component: AboutComponent
  },
  {
    path: 'questions',
    component: QuestionsComponent
  },
  {
    path: 'questions/add',
    component: AddQuestionComponent
  }, 
  {
    path: 'administration',
    component: AdministrationComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
