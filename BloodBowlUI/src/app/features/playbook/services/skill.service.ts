import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Skill } from 'src/app/core/models/skill';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SkillService {
  constructor(private http: HttpClient) { }

  getSkills(rulesetId: number): Observable<Skill[]> {
    const url = `${environment.apiUrl}/rulesets/${rulesetId}/skills`;

    return this.http.get<Skill[]>(url);
  }
}

