import { Component, OnInit } from '@angular/core';
import { NgbProgressbarConfig } from '@ng-bootstrap/ng-bootstrap';
import * as AOS from 'aos';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  providers: [NgbProgressbarConfig] 
})
export class AdminHomeComponent implements OnInit {

  constructor(config: NgbProgressbarConfig) {
    config.max = 1000;
    config.striped = true;
    config.animated = true;
    config.type = 'primary';
    config.height = '10px';
   }

  ngOnInit(): void {
    AOS.init({
      offset: 120,
      duration: 2500,
      mirror: true,
      once: false,
      //anchorPlacement: 'buttom-top'
    });
  }

}
