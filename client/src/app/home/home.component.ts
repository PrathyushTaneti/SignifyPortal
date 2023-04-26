import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})

export class HomeComponent {
  public readingIcon = "../../assets/images/hero-image.svg";
  public loginForm: FormGroup | undefined;

  constructor(private router: Router) { }

  print = () => {
    window.console.log(document.getElementById("nameText") == null);
  }

  NgOnInit() {
    this.buildForm();
  }


  buildForm() {
    this.loginForm = new FormGroup({
      name: new FormControl('', Validators.required),
    });
  }

}
