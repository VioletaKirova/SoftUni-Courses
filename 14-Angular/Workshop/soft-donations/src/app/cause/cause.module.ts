import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { CreateComponent } from './create/create.component';
import { DetailsComponent } from './details/details.component';
import { CauseRoutingModule } from './cause-routing.module';
import { ListComponent } from './list/list.component';

@NgModule({
  declarations: [
    CreateComponent,
    DetailsComponent,
    ListComponent
  ],
  imports: [
    CommonModule,
    CauseRoutingModule,
    ReactiveFormsModule
  ],
  exports: [
    DetailsComponent,
    ListComponent
  ]
})
export class CauseModule { }
