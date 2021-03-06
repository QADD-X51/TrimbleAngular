import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Category } from '../category';
import { FilterService } from '../services/filter.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss']
})
export class FilterComponent implements OnInit {

  @Output() emitSelectedFilter = new EventEmitter<string>();
  @Output() emitSearchFilter = new EventEmitter<string>();

  categories: Array<Category>;
  search: string = "";

  constructor(private service:FilterService) { }

  ngOnInit(): void {
    this.categories = this.service.getCategories();
  }

  selectFilter(categoryId: string) {
    this.emitSelectedFilter.emit(categoryId);
  }

  selectSearchFilter() {
    this.emitSearchFilter.emit(this.search);
  }

}
