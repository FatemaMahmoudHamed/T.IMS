import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';


const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        component: HomeComponent,
        data: {
          title: 'الرئيسية',
        },
      },
      {
        path: 'home',
        component: HomeComponent,
        data: {
          title: 'الرئيسية',
        },
      },
      // {
      //   path: 'reserve-order',
      //   component: ReserveOrderComponent,
      //   // data: {
      //   //   title: 'الرئيسية',
      //   // },
      // },
      // {
      //   path: 'checkout',
      //   component: CheckOutReviewComponent,
      //   // data: {
      //   //   title: 'الرئيسية',
      //   // },
      // },
      // {
      //   path: 'menu/:id',
      //   component: RestaurantMenuComponent,
      //   // data: {
      //   //   title: 'الرئيسية',
      //   // },
      // },
      


    ],
  },
];
  

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FeatureModulesRoutingModule { }
