import { Component, OnInit } from '@angular/core';
import { Performance } from '../Models/performance.model';
import { PerformanceService } from '../Services/performance.service';

@Component({
  selector: 'app-performance',
  templateUrl: './performance.component.html',
})
export class PerformanceComponent implements OnInit {
  public performanceList!: Performance[];
  constructor(private performanceService:PerformanceService) { }

  ngOnInit(): void {
    this.performanceService.getPerformance().subscribe(data => {
      this.performanceList = data;
      window.console.log(this.performanceList);
    })
  }

  select(id: number) {
    if (id == 0) {
      this.performanceService.getPerformance().subscribe(data => {
        this.performanceList = data;
        window.console.log(this.performanceList);
      })
    }
    if (id == 1) {
      this.performanceService.getPerformance().subscribe(data => {
        this.performanceList = data.filter(performance => performance.quizName == "C Programming");
        window.console.log(this.performanceList);
      })
    }
    else if (id == 2) {
      this.performanceService.getPerformance().subscribe(data => {
        this.performanceList = data.filter(performance => performance.quizName == "C++ Programming");
        window.console.log(this.performanceList);
      })
    }
  }
}
