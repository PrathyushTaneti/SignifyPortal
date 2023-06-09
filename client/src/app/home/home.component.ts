import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
//import AOS from 'aos';
//import 'aos/dist/aos.css'; 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls : ['./home.component.scss']
})

export class HomeComponent {
  public readingIcon = "../../assets/images/hero-image.svg";
  public loginForm!: FormGroup;



  constructor(private router: Router) { }

  print = () => {
    window.console.log(document.getElementById("nameText") == null);
  }

  NgOnInit() {
    //AOS.init();
    this.buildForm();
  }


  buildForm() {
    this.loginForm = new FormGroup({
      name: new FormControl('', Validators.required),
    });
  }

  getUserName() {
    return "Hello";
  }

}
