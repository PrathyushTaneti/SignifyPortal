import { Component, OnInit } from '@angular/core';
import * as AOS from 'aos';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
})
export class FooterComponent implements OnInit {

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
