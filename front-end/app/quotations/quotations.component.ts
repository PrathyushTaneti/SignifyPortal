import { Component, OnInit } from '@angular/core';
import * as AOS from 'aos';

@Component({
  selector: 'app-quotations',
  templateUrl: './quotations.component.html',
})
export class QuotationsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    AOS.init({
      offset: 80,
      duration: 2500,
      mirror: true,
      once: false,
      // anchorPlacement: 'buttom-top'      
    });
  }

}
