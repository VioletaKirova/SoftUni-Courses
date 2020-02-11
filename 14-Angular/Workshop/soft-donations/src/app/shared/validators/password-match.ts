import { AbstractControl, ValidationErrors } from '@angular/forms';

export function passwordMatch(control: AbstractControl): ValidationErrors {
  return control.value.password === control.value.rePassword
    ? null
    : { passwordMatch: true };
}
