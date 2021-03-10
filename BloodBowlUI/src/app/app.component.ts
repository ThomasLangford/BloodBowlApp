import { Component } from '@angular/core';
// import { SkillService } from './services/skill.service';
// import { catchError, map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'BloodBowl UI';

  

  constructor() { 
    console.log("Hello");
  }
}
