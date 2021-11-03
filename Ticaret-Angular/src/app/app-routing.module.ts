import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { BasketComponent } from './basket/basket.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { AuthGuard } from './core/guards/auth.guard';

import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home.component';
import { ProductDetailsComponent } from './shop/product-details/product-details.component';
import { ShopComponent } from './shop/shop.component';

const routes: Routes = [
  {path:'' ,component:ShopComponent,data:{breadcrumb:'Ana Sayfa'}},
  {path:'server-error' ,component:ServerErrorComponent,data:{breadcrumb:'Server Error'}},
  {path:'test-error' ,component:TestErrorComponent,data:{breadcrumb:'Test Errors'}},
  {path:'not-found' ,component:NotFoundComponent,data:{breadcrumb:'Not Found'}},
  {path:'shop' ,component:ShopComponent,data:{breadcrumb:'Shop'}},
  {path:'basket' ,component:BasketComponent,data:{breadcrumb:'Basket'}},
  {path:'shop/:id' ,component:ProductDetailsComponent,data:{breadcrumb:{alias:'shopDetail'}}},
  {path:'checkout' ,canActivate:[AuthGuard], component:CheckoutComponent,data:{breadcrumb:'Basket'}},
  {path:'login' ,component:LoginComponent,data:{breadcrumb:'Login'}},
  {path:'register' ,component:RegisterComponent,data:{breadcrumb:'Register'}},
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
