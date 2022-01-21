import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TeamType } from 'src/app/core/models/teamType';

@Component({
  selector: 'app-playertypeform',
  templateUrl: './playertypeform.component.html',
  styleUrls: ['./playertypeform.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class PlayerTypeFormComponent implements OnInit {
  
  @Input() formGroup!: FormGroup;

  constructor(private _formBuilder: FormBuilder) {

   }

  ngOnInit(): void {

    console.log(this.formGroup);
  }

}
