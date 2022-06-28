import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';

import { FeatureModulesRoutingModule } from './feature-modules-routing.module';
import { FeatureModulesComponent } from './feature-modules.component';
import { DemoMaterialModule } from '../demo-material-module';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [FeatureModulesComponent,HomeComponent],
  imports: [
    SharedModule,
    DemoMaterialModule,
    FeatureModulesRoutingModule
  ],
})
export class FeatureModulesModule { }
