import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BasketComponent } from './basket/basket.component';
import { CheckoutComponent } from './checkout/checkout.component';

import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ShopComponent } from './shop/shop.component';

const routes: Routes = [
  {path:'' ,component:HomeComponent,data:{breadcrumb:'Ana Sayfa'}},
  {path:'server-error' ,component:ServerErrorComponent,data:{breadcrumb:'Server Error'}},
  {path:'test-error' ,component:TestErrorComponent,data:{breadcrumb:'Test Errors'}},
  {path:'not-found' ,component:NotFoundComponent,data:{breadcrumb:'Not Found'}},
  {path:'shop' ,component:ShopComponent,data:{breadcrumb:'Shop'}},
  {path:'basket' ,component:BasketComponent,data:{breadcrumb:'Basket'}},
  {path:'shop/:id' ,component:ProductDetailsComponent,data:{breadcrumb:{alias:'shopDetail'}}},
  {path:'checkout' ,component:CheckoutComponent,data:{breadcrumb:'Basket'}},
  {path:'**',redirectTo:'',pathMatch:'full'},

  // {
  //   path: 'basket',
  //   loadChildren: () =>
  //     import('./basket/basket.module').then(mod => mod.BasketModule),
  //   data: { breadcrumb: 'Basket' },
  // },
 


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
