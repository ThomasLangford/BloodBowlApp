import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SkillCategory } from 'src/app/core/models/skillCategory';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SkillCategoryService {

  constructor(private http: HttpClient) { }

  getSkillCategories(rulesetId: number): Observable<SkillCategory[]> {
    const url = `${environment.apiUrl}/rulesets/${rulesetId}/skillcategories`;

    return this.http.get<SkillCategory[]>(url);
  }
}
