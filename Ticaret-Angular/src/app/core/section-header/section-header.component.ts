import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BreadcrumbService } from 'xng-breadcrumb';
import { Breadcrumb } from 'xng-breadcrumb/lib/types/breadcrumb';

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrls: ['./section-header.component.css']
})
export class SectionHeaderComponent implements OnInit {

  breadcrumbs$:Observable<any[]>
  constructor(private breadcrumb:BreadcrumbService) { }

  ngOnInit(): void {
    this.breadcrumbs$=this.breadcrumb.breadcrumbs$;
  }

}
