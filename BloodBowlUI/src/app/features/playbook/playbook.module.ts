import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule} from '@angular/forms' 

import { MatTableModule } from '@angular/material/table';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card'; 
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon'; 
import { MatChipsModule } from '@angular/material/chips';
import {MatSelectModule} from '@angular/material/select';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';

import { PlaybookRoutingModule } from './playbook-routing.module';
import { PlaybookComponent } from './playbook.component';
import { RulesetComponent } from './pages/ruleset/ruleset.component';
import { RulesetpickerComponent } from './pages/ruleset-picker/ruleset-picker.component';
import { CoreModule } from 'src/app/core/core.module';
import { RulesetlandingComponent } from './pages/ruleset-landing/ruleset-landing.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SkillsComponent } from './pages/skills/skills.component';
import { TeamsComponent } from './pages/teams/teams.component';
import { TeamComponent } from './pages/team/team.component';
import { PlayerTypeFormComponent } from './components/player-type-form/player-type-form.component';
import { SkillPickerComponent } from './components/skill-picker/skill-picker.component';
import { AvailableSkillCategoryPickerComponent } from './components/available-skill-category-picker/available-skill-category-picker.component';

@NgModule({
  declarations: [PlaybookComponent, RulesetComponent, RulesetpickerComponent, RulesetlandingComponent, SkillsComponent, TeamsComponent, TeamComponent, PlayerTypeFormComponent, SkillPickerComponent, AvailableSkillCategoryPickerComponent],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    MatTableModule,
    MatExpansionModule,
    MatSidenavModule,
    MatListModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    MatIconModule,
    MatChipsModule,
    MatSelectModule,
    NgxMatSelectSearchModule,
    PlaybookRoutingModule,
    CoreModule,    
  ]
})
export class PlaybookModule { }
