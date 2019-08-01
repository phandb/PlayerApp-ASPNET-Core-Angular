import { Component, OnInit, Input, EventEmitter, Output} from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { Router } from '@angular/router';
import { User } from '../_models/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

 // @Input() playersFromHome: any;
  @Output() cancelRegister = new EventEmitter();
  user: User;
  registerForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;  // Partial : make all properties optional

  constructor(private authService: AuthService, private router: Router,
      private alertify: AlertifyService, private fb: FormBuilder) { }
/*
  ngOnInit() {
    this.registerForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('',
        [Validators.minLength(4), Validators.maxLength(8)]),
      confirmPassword: new FormControl('', Validators.required)
    }, this.passwordMatchValidator);
  }
*/
ngOnInit() {
  this.bsConfig = {
    containerClass: 'theme-blue'
  },
  this.createRegisterForm();
}

  createRegisterForm() {
    this.registerForm = this.fb.group({
      gender: ['male'], // radio button
      username: ['', Validators.required],
      knownAs: ['', Validators.required],
      dateOfBirth: [null, Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ['', Validators.required]
    }, {
      validator: this.passwordMatchValidator
    });
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value ? null : {'mismatch': true};
  }

  // add register and cancel methods
  register() {
      if (this.registerForm.valid) {
        this.user = Object.assign({}, this.registerForm.value);
        this.authService.register(this.user).subscribe(() => {
          this.alertify.success('Registration successful');
        }, error => {
          this.alertify.error(error);
        }, () => {
          this.authService.login(this.user).subscribe(() => {
            this.router.navigate(['/members']);
          });
        });
      }
    // this.authService.register(this.model).subscribe(() => {
    //   this.alertify.success('registration successful');
    // }, error => {
    //   this.alertify.error(error);
    // });
    // console.log(this.registerForm.value);
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
