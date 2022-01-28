import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-available-skill-category-picker',
  templateUrl: './available-skill-category-picker.component.html',
  styleUrls: ['./available-skill-category-picker.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AvailableSkillCategoryPickerComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
