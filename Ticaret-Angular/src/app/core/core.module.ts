import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NaviComponent } from './navi/navi.component';



@NgModule({
  declarations: [NaviComponent],
  imports: [
    CommonModule
  ],
  exports:[NaviComponent]
})
export class CoreModule { }
