import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomePageComponent } from './home-page/home-page.component';
import { FeaturesComponent } from './features/features.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { QuotationsComponent } from './quotations/quotations.component';
import { FooterComponent } from './footer/footer.component';
import { LoginModuleComponent } from './login-module/login-module.component';
import { AdminComponent } from './admin/admin.component';
import { TeacherComponent } from './teacher/teacher.component';
import { StudentComponent } from './student/student.component';
import { HttpClientModule } from '@angular/common/http';
import { AppServiceService } from './Services/app.service';
import { AddnewstudentComponent } from './add-new-student/addnewstudent.component';
import { AttendancetrackingComponent } from './attendance-tracking/attendancetracking.component';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { ScheduleMeetingComponent } from './schedule-meeting/schedule-meeting.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ViewStudentDetailComponent } from './view-student-detail/view-student-detail.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { QuizComponent } from './quiz/quiz.component';
import { ActiveAssignmentsComponent } from './active-assignments/active-assignments.component';
import { PerformanceComponent } from './performance/performance.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    FeaturesComponent,
    QuotationsComponent,
    FooterComponent,
    LoginModuleComponent,
    AdminComponent,
    TeacherComponent,
    StudentComponent,
    AddnewstudentComponent,
    AttendancetrackingComponent,
    StudentDetailsComponent,
    EmployeeDetailsComponent,
    ScheduleMeetingComponent,
    ViewStudentDetailComponent,
    AdminHomeComponent,
    QuizComponent,
    ActiveAssignmentsComponent,
    PerformanceComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    NgbModule
  ],
  providers: [AppServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
