import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormBuilder, FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterModule, MatButtonModule, MatFormFieldModule, MatInputModule,
    FormsModule, ReactiveFormsModule
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  fB = inject(FormBuilder);

  registerFg = this.fB.group({ //  formgroup
    emailCtrl: '', // formcontrol
    passwordCtrl: ''
  })

  get EmailCtrl(): FormControl {
    return this.registerFg.get('emailCtrl') as FormControl;
  }

  get PasswordCtrl(): FormControl {
    return this.registerFg.get('passwordCtrl') as FormControl;
  }

  showFormValue(): void {
    console.log(this.EmailCtrl.value);
    console.log(this.PasswordCtrl.value);
  }

  // emailCtrl = this.fB.control('');
  // passwordCtrl = this.fB.control('')

  // showFormValue(): void {
  //   console.log(this.emailCtrl.value);
  //   console.log(this.passwordCtrl.value);
  // }
}

/// contstructor, console, list / index 
// age: number = 20;
// numbers: number[] = [12, 10, 20];
// names: string[] = ["parsa", "baran", "amir", "melika"];

// constructor() {
//   console.log(30)
//   console.log(this.numbers);
//   console.log(this.numbers[1]);
// }

// showNumberInConole(): void {
//   console.log(this.age);
// }

/// method with retutn types
// age: number = 0;
// number: number = 0;

// showNumber(sen: number): void {
//   this.number = sen;
// }

// calcAge(): number {
//   let age1: number = 10;
//   let age2: number = 20;

//   this.age = age1 + age2;

//   return this.age;
// }

/// method with parameter
// age: number = 0;
// name: string = '';
// num: number = 0;

// mohasebeSen(sen: number, sen1: number) { // parameter
//   this.age = sen + sen1;
// }

// jomleBesaz(esm: string, sen: number) {
//   this.num = sen;
//   this.name = esm;
// }

/// method & variable basic
// adad: number = 2; // global
// name: string = 'parsa';
// isAlive: boolean = true;

// jamSen() { // parametrless
//   let sen: number = 3; // local
//   let sen2: number = 8;

//   this.adad = sen + sen2;
// }

// showName() {
//   let esm: string = "Moein";

//   this.name = esm;
// }
