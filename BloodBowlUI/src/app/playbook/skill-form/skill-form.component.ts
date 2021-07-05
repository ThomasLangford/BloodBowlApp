import { Component, OnInit } from '@angular/core';
import { Skill } from 'src/app/models/skill';
import { SkillService } from 'src/app/services/skill.service';

@Component({
  templateUrl: './skill-form.component.html',
  styleUrls: ['./skill-form.component.scss']
})
export class SkillFormComponent implements OnInit {
  skillService: SkillService;
  skills: Skill[];

  displayedColumns: string[] = ['name', 'icon'];
  constructor(skillService: SkillService) {

    this.skillService = skillService;
    this.skills = [];
    // this.skills = [{id: 1, name: "test"}];
  }

  ngOnInit(): void {
    // this.skillService.getSkills().subscribe({
    //   next: x => this.skills = x,
    //   error: err => console.log(err),
    //   complete: () => console.log("done")
    // });
  }

}
