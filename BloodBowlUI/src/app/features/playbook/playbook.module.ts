import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card'; 

import { PlaybookRoutingModule } from './playbook-routing.module';
import { PlaybookComponent } from './playbook.component';
import { RulesetComponent } from './pages/ruleset/ruleset.component';
import { RulesetpickerComponent } from './pages/rulesetpicker/rulesetpicker.component';
import { CoreModule } from 'src/app/core/core.module';
import { RulesetlandingComponent } from './pages/rulesetlanding/rulesetlanding.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SkillsComponent } from './pages/skills/skills.component';
import { TeamsComponent } from './pages/teams/teams.component';
import { TeamComponent } from './pages/team/team.component';


@NgModule({
  declarations: [PlaybookComponent, RulesetComponent, RulesetpickerComponent, RulesetlandingComponent, SkillsComponent, TeamsComponent, TeamComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatExpansionModule,
    MatListModule,
    MatCardModule,
    PlaybookRoutingModule,
    CoreModule,
    MatSidenavModule
  ]
})
export class PlaybookModule { }
