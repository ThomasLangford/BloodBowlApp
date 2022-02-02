import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RulesetIdService {

  constructor() { }

  public getRulesetIdFromPath(activatedRoute: ActivatedRoute) : Observable<number> {
    return new Observable<number>((observer) => {
      activatedRoute.pathFromRoot.forEach(p => 
          p.paramMap.subscribe({
            next: res => {
              const rulesetIdParam = res.get('rulesetId');

              if(rulesetIdParam) {
                observer.next(rulesetIdParam === null ? 0 : parseInt(rulesetIdParam))
              }          
            },
            error: err => observer.error(err)
        })
      );
    })
  }

}
