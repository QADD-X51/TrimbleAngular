import { Component, OnInit } from '@angular/core';
import { Category } from '../category';
import { FilterService } from '../services/filter.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  categories: Array<Category>;

  constructor(private service:FilterService) { }

  ngOnInit(): void {
    this.categories = this.service.getCategories();
  }

}
