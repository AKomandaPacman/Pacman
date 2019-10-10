import { Component, OnInit } from '@angular/core';


import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NzNotificationService } from 'ng-zorro-antd';

@Component({
  selector: 'xn-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.less']
})
export class MenuComponent implements OnInit {

    submit() { }

  inputv: FormGroup = this.builder.group({
    email: [null, [Validators.required, Validators.email]],
    password: [null, [Validators.required]],
    remember: [true]
  });

  constructor(
    private builder: FormBuilder,
    private router: Router,
    private notifications: NzNotificationService) { }

  ngOnInit() {
  }

  // this.inputv = this.builder.group({
  //     email: [null, [Validators.required, Validators.email]],
  //     password: [null, [Validators.required]],
  //     remember: [true]
  // });
}
