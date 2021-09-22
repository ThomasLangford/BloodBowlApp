import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-playbook',
  templateUrl: './playbook.component.html',
  styleUrls: ['./playbook.component.scss']
})
export class PlaybookComponent implements OnInit {
  public rulesetId: number;

  constructor( private _activatedRoute: ActivatedRoute ) {
    this.rulesetId = 0;
   }

  ngOnInit(): void {
    this._activatedRoute.firstChild?.params.subscribe({
      next: res => this.rulesetId = parseInt(res['rulesetId'])
    });
  }
}
