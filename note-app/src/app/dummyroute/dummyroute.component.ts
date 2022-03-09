import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-dummyroute',
  templateUrl: './dummyroute.component.html',
  styleUrls: ['./dummyroute.component.scss']
})
export class DummyrouteComponent implements OnInit {

  text: string;

  constructor(private _router: Router, private _activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this._activatedRoute.params.subscribe(parameter => (
      this.text  = parameter['id']
    ))
  }

}
