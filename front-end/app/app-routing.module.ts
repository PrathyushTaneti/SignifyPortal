import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActiveAssignmentsComponent } from './active-assignments/active-assignments.component';
import { AddnewstudentComponent } from './add-new-student/addnewstudent.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminComponent } from './admin/admin.component';
import { AttendancetrackingComponent } from './attendance-tracking/attendancetracking.component';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { FeaturesComponent } from './features/features.component';
import { FooterComponent } from './footer/footer.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginModuleComponent } from './login-module/login-module.component';
import { PerformanceComponent } from './performance/performance.component';
import { QuizComponent } from './quiz/quiz.component';
import { QuotationsComponent } from './quotations/quotations.component';
import { ScheduleMeetingComponent } from './schedule-meeting/schedule-meeting.component';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { StudentComponent } from './student/student.component';
import { TeacherComponent } from './teacher/teacher.component';
import { ViewStudentDetailComponent } from './view-student-detail/view-student-detail.component';

const routes: Routes = [
  { path:'', redirectTo:'home', pathMatch:'full'},
  { path: 'home', component: HomePageComponent },
  { path: 'features', component: FeaturesComponent },
  { path: 'quotations', component: QuotationsComponent },
  { path: 'footer', component: FooterComponent },
  { path: 'login', component: LoginModuleComponent },
  { path: 'quiz/:id', component: QuizComponent},
  {
    path: 'admin', component: AdminComponent,
    children: [
      { path: '', component: AdminHomeComponent},
      { path: 'addnewstudent', component: AddnewstudentComponent },
      { path: 'activePrograms',component : ActiveAssignmentsComponent},
      { path: 'employeedetails', component: EmployeeDetailsComponent },
      { path: 'studentdetails', component: StudentDetailsComponent },
      { path: 'tracker', component : AttendancetrackingComponent},
      { path: 'schedulemeeting', component: ScheduleMeetingComponent },
      { path: 'viewstudentdetail/:id', component: ViewStudentDetailComponent },
      { path: 'performance', component: PerformanceComponent },
    ]
  }, 
  {
    path: 'student/:id', component: StudentComponent,
    children: [
      { path: 'quiz/:id', component: QuizComponent},      
    ]
  
  },
  {
    path: 'teacher', component: TeacherComponent,
    children: [
      { path: 'performance', component: PerformanceComponent}      
    ]
  },
  { path: '**', redirectTo:'home',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
  
export class AppRoutingModule { }
