import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TeamType } from 'src/app/core/models/teamType';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TeamTypeService {

  constructor(private http: HttpClient) { }

  getTeamTypes(rulesetId: number): Observable<TeamType[]> {
    const url = this.getTeamTypeBaseUrl(rulesetId);

    return this.http.get<TeamType[]>(url);
  }

  getTeamType(rulesetId: number, teamTypeId: number): Observable<TeamType> {
    const url = `${this.getTeamTypeBaseUrl(rulesetId)}/${teamTypeId}`;

    return this.http.get<TeamType>(url);
  }

  putTeamType(teamType: TeamType): Observable<TeamType> {
    const url = this.getTeamTypeUrl(teamType.rulesetId, teamType.id);

    return this.http.put<TeamType>(url, teamType);
  }

  postTeamType(teamType: TeamType): Observable<TeamType> {
    const url = this.getTeamTypeBaseUrl(teamType.rulesetId);

    return this.http.post<TeamType>(url, teamType);
  }

  deleteTeamType(rulesetId: number, teamTypeId: number): Observable<TeamType> {
    const url = `${this.getTeamTypeBaseUrl(rulesetId)}/${teamTypeId}`;

    return this.http.delete<TeamType>(url);
  }

  private getTeamTypeBaseUrl(rulesetId: number): string {
    return `${environment.apiUrl}/rulesets/${rulesetId}/teamtypes`;
  }

  private getTeamTypeUrl(rulesetId: number, teamTypeId: number): string {
    return `${this.getTeamTypeBaseUrl(rulesetId)}/${teamTypeId}`;
  }
}
