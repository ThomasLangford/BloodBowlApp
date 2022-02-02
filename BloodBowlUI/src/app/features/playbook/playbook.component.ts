import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-playbook',
  templateUrl: './playbook.component.html',
  styleUrls: ['./playbook.component.scss']
})
export class PlaybookComponent implements OnInit {
  public rulesetId = 1;

  constructor( private _activatedRoute: ActivatedRoute ) {}

  ngOnInit(): void {
    this._activatedRoute.firstChild?.params.subscribe({
      next: res => this.rulesetId = parseInt(res['rulesetId'])
    });
  }
}
