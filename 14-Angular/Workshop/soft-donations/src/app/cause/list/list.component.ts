import { Component, OnInit } from '@angular/core';

import { CausesService } from 'src/app/cause/causes.service';
import { ICause } from 'src/app/shared/interfaces/cause';

@Component({
  selector: 'app-cause-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
   // @Output() selectCause: EventEmitter<ICause> = new EventEmitter();

   get causes() {
    return this.causesService.causes;
  }

  constructor(private causesService: CausesService) { }

  ngOnInit() {
    this.causesService.load().subscribe();
  }

  selectCauseHandler(cause: ICause) {
    // this.selectCause.emit(cause);
    this.causesService.selectCause(cause);
  }

}
