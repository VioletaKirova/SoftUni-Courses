import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  form: FormGroup;

  constructor(private  fb: FormBuilder) {
    this.form = this.fb.group({
      cause: ['', [Validators.required]],
      neededAmount: ['', [Validators.required, Validators.min(100)]],
      description: ['', [Validators.required, Validators.min(50)]],
      imageUrl: ['', [Validators.required]],
    });
   }

  ngOnInit() {
  }

  createCauseHandler() {
    console.log(this.form.value);
  }
}
