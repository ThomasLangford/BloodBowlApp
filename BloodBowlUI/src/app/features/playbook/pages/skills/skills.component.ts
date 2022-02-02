import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SkillCategoryService } from '../../services/skillcategory/skillcategory.service';
import {map} from 'rxjs/operators';
import { Observable } from 'rxjs';
import { RulesetIdService } from '../../services/rulesetidservice/rulesetid.service';
import { SkillCategory } from 'src/app/core/models/skillCategory';
@Component({
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.scss']
})
export class SkillsComponent implements OnInit {
  public SkillCategories: SkillCategory[] = [];

  public panelOpenState = false;

  constructor(
    private _rulesetIdService: RulesetIdService,
    private _skillCategoryService: SkillCategoryService,
    private _activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.getSkillCategories();
  }

  private getSkillCategories() {
    this._rulesetIdService.getRulesetIdFromPath(this._activatedRoute).subscribe({
      next: res => {
        this._skillCategoryService.getSkillCategories(res).subscribe({
          next: res => {this.SkillCategories = res; console.log(res);}
        })
      }
    });
  }
}
