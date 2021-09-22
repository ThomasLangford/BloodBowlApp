import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Ruleset } from 'src/app/core/models/ruleset';
import { RulesetService } from '../../services/ruleset/ruleset.service';

@Component({
  templateUrl: './ruleset.component.html',
  styleUrls: ['./ruleset.component.scss']
})
export class RulesetComponent implements OnInit {
  private rulesets: Ruleset[] = [];
  
  constructor(

  ) { }

  ngOnInit(): void {
    throw new Error('ToDo');
  }

}
