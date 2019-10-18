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

  inputv: FormGroup = this.builder.group({
    email: [null],
    password: [null],
    remember: [true]
  });

  constructor(
    private builder: FormBuilder,
    private router: Router,
    private notifications: NzNotificationService) { }

  ngOnInit() {
  }

    submit() {}
}
