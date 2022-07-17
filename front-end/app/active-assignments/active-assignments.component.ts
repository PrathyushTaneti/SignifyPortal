import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivePrograms } from '../Models/activeProgram.model';
import { ActiveProgramsService } from '../Services/active-programs.service';

@Component({
  selector: 'app-active-assignments',
  templateUrl: './active-assignments.component.html',
  // styleUrls: ['./active-assignments.component.scss']
})
export class ActiveAssignmentsComponent implements OnInit {
  public activePrograms!: ActivePrograms[];
  public createAssignmentForm!: FormGroup;
  constructor(private activeProgramService: ActiveProgramsService) { }

  ngOnInit(): void {
    this.activeProgramService.getAllActivePrograms().subscribe(data => {
      this.activePrograms = data;
    })
    this.buildForm();
  }

  buildForm() {
    this.createAssignmentForm = new FormGroup({
      programLink: new FormControl('', [Validators.required]),
      programName : new FormControl('', [Validators.required])
    })
  }

  endAssignment(programId: number) {
    this.activeProgramService.deleteProgram(programId).subscribe();
    window.location.reload();
  }

  createNewAssignment() {
    window.console.log("YEs")
    if (this.createAssignmentForm.valid) {
      window.console.log(this.createAssignmentForm.get('programLink')?.value, this.createAssignmentForm.get('programName')?.value);
      this.activeProgramService.createProgram(this.createAssignmentForm.value).subscribe();
      window.location.reload();
    }
  }

}
