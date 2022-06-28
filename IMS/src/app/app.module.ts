
import { NgModule, ErrorHandler, APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppRoutes } from './app-routing.module';
import { FullComponent } from './layouts/full/full.component';
import { AppBlankComponent } from './layouts/blank/blank.component';
import { AppHeaderComponent } from './layouts/full/header/header.component';
import { AppSidebarComponent } from './layouts/full/sidebar/sidebar.component';
import { AppBreadcrumbComponent } from './layouts/full/breadcrumb/breadcrumb.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DemoMaterialModule } from './demo-material-module';
import { SpinnerComponent } from '../shared/spinner.component';
import { ErrorService } from './core/services/error.service';
import { FeatureModulesRoutingModule } from './feature/feature-modules-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from 'src/shared/shared.module';
import { PerfectScrollbarConfigInterface, PerfectScrollbarModule, PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { AppErrorHandler } from 'src/shared/errors/app-error-handler';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { CdkColumnDef, CdkTableModule } from '@angular/cdk/table';


const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true,
  wheelSpeed: 2,
  wheelPropagation: true,
};
@NgModule({
  declarations: [
    AppComponent,
    FullComponent,
    AppHeaderComponent,
    SpinnerComponent,
    AppBlankComponent,
    AppSidebarComponent,
    AppBreadcrumbComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    SharedModule,
    DemoMaterialModule,
    PerfectScrollbarModule,
    RouterModule.forRoot(AppRoutes, { relativeLinkResolution: 'legacy' }),
    FeatureModulesRoutingModule,
    MatSnackBarModule,
    CdkTableModule
    // SweetAlert2Module.forRoot(),
  ],
  providers: [
    {
      provide: PERFECT_SCROLLBAR_CONFIG,
      useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG,
    },
    {  // it will not show the errors in the html and the page just will be hung
      provide: ErrorHandler,
      useClass: AppErrorHandler,
    },

    ErrorService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
