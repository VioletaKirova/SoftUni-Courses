import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { CausesService } from 'src/app/cause/causes.service';
import { ICause } from 'src/app/shared/interfaces/cause';

@Component({
  selector: 'app-cause-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {
  // @Input() selectedCauseFromInput: ICause;
  @ViewChild('amountInput', { static: false }) amountInput: ElementRef<HTMLInputElement>;

  isRouteComponent = false;

  get selectedCause() {
    return this.causesService.selectedCause;
  }

  get classByAmount() {
    return this.selectedCause.collectedAmount >= this.selectedCause.neededAmount
    ? 'highAmount'
    // tslint:disable-next-line: max-line-length
    : this.selectedCause.collectedAmount > this.selectedCause.neededAmount * 1 / 3 && this.selectedCause.collectedAmount < this.selectedCause.neededAmount * 2 / 3
    ? 'middleAmount'
    : 'lowAmount';
  }

  constructor(
    private causesService: CausesService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
      this.isRouteComponent = this.activatedRoute.snapshot.data.shouldFetchCause;
     }

  ngOnInit() {
    if (this.isRouteComponent) {
      this.causesService.load(this.activatedRoute.snapshot.params.id).subscribe((cause: ICause) => {
        this.causesService.selectCause(cause);
      });
    }
  }

  makeDonationHandler() {
    this.causesService
      .donate(+this.amountInput.nativeElement.value)
      .subscribe(() => this.causesService.load());
  }
}
