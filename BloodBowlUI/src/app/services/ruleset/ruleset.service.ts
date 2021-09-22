import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Ruleset } from 'src/app/models/ruleset';
import { environment } from 'src/environments/environment'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RulesetService {
  private rulesetUrl = environment.apiUrl + '/rulesets';

  constructor(private http: HttpClient) { }

  getRulesets(): Observable<Ruleset[]> {
    return this.http.get<Ruleset[]>(this.rulesetUrl)
  }
}
