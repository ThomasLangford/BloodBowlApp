import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Ruleset } from 'src/app/core/models/ruleset';
import { RulesetService } from '../../services/ruleset/ruleset.service';

@Component({
  templateUrl: './rulesetpicker.component.html',
  styleUrls: ['./rulesetpicker.component.scss']
})
export class RulesetpickerComponent implements OnInit {
  private rulesets: Ruleset[] = [];
  
  constructor(
    private _rulesetService: RulesetService,
    private _activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this._rulesetService.getRulesets().subscribe({
        next: res => this.rulesets = res,
        error: err => console.log(err),
        complete: () => console.log("done")
      });

    this._activatedRoute.params.subscribe({
      next: res => console.log(res)
    });
  }

}
