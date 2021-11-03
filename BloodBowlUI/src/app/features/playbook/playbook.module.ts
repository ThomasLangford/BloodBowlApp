import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';

import { PlaybookRoutingModule } from './playbook-routing.module';
import { PlaybookComponent } from './playbook.component';
import { RulesetComponent } from './pages/ruleset/ruleset.component';
import { RulesetpickerComponent } from './pages/rulesetpicker/rulesetpicker.component';
import { CoreModule } from 'src/app/core/core.module';
import { RulesetlandingComponent } from './pages/rulesetlanding/rulesetlanding.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SkillsComponent } from './pages/skills/skills.component';

@NgModule({
  declarations: [PlaybookComponent, RulesetComponent, RulesetpickerComponent, RulesetlandingComponent, SkillsComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    PlaybookRoutingModule,
    CoreModule,
    MatSidenavModule
  ]
})
export class PlaybookModule { }
