import { Component } from '@angular/core';
import { slideInAnimation } from './app.animation';
import * as AOS from 'aos';;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  animations: [slideInAnimation]
})
export class AppComponent {
  public title = 'Signify';
  public logo = "../assets/images/SIGNIFY-2.png";

  ngOnInit() {
    AOS.init({
      offset: 120,
      mirror: true,
      once: false,
    });
  }
}
