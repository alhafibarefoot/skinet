import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { TestErrorComponent } from './test-error/test-error.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { BreadcrumbModule } from 'xng-breadcrumb';



@NgModule({
  declarations: [NavBarComponent, TestErrorComponent, ServerErrorComponent, NotFoundComponent, SectionHeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    }),
    BreadcrumbModule
  ],
  exports:[
    NavBarComponent,
    SectionHeaderComponent

  ]
})
export class CoreModule { }
