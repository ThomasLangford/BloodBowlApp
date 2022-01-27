import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LevelUpType } from 'src/app/core/models/levelUpType';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LevelUpTypeService {
  constructor(private http: HttpClient) { }

  getSkillCategories(rulesetId: number): Observable<LevelUpType[]> {
    const url = `${environment.apiUrl}/rulesets/${rulesetId}/leveluptypes`;

    return this.http.get<LevelUpType[]>(url);
  }
}
