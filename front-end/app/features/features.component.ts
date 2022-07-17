import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as AOS from 'aos';

@Component({
  selector: 'app-features',
  templateUrl: './features.component.html',
  animations: [
    trigger('fade', [
      transition('void => *', [
        style({backgroundColor:'yellow',opacity:0}),
        animate(2000, style({
          backgroundColor:'white',opacity:1
        }))
      ])
    ])
  ]
})
export class FeaturesComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit() {
    AOS.init(
      {
        offset: 80,
        duration: 2500,
        mirror: true,
        once: false,
        // anchorPlacement: 'buttom-top'
      }
    );
  }

  goToQuotations() {
    this.router.navigate(['/quotations']);
  }

}
