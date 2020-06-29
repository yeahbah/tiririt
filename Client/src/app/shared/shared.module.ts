// include directives/components commonly used in features modules in this shared modules
// and import me into the feature module
// importing them individually results in: Type xxx is part of the declarations of 2 modules: ... Please consider moving to a higher module...
// https://github.com/angular/angular/issues/10646  

import { NgModule }           from '@angular/core';
import { CommonModule }       from '@angular/common';
 
import { NgxSpinnerModule } from 'ngx-spinner';
import { AutofocusDirective } from './directives/auto-focus.directive';
import { NgMaterialModule } from '../ngmaterial/ngmaterial.module';
import { MyFeedComponent } from '../my-feed/my-feed.component';
import { MyFeedService } from '../my-feed/my-feed.service';
import { LinkifyPipe } from '../pipes/linkify-pipe';
import { PostItemComponent } from './post-item/post-item.component';
import { TrendingFeedComponent } from './trending-feed/trending-feed.component';
import { StockChartComponent } from './stock-chart/stock-chart.component';
import { ReplyFormComponent } from './reply-form/reply-form.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ResponseCommentsComponent } from './response-comments/response-comments.component';
import { PostActionsComponent } from './post-actions/post-actions.component';

//https://stackoverflow.com/questions/41433766/directive-doesnt-work-in-a-sub-module
//https://stackoverflow.com/questions/45032043/uncaught-error-unexpected-module-formsmodule-declared-by-the-module-appmodul/45032201

@NgModule({
  imports:      [
    CommonModule, 
    NgxSpinnerModule,
    NgMaterialModule,
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [
    AutofocusDirective,
    LinkifyPipe,
    MyFeedComponent,
    PostItemComponent,
    TrendingFeedComponent,
    StockChartComponent,
    ReplyFormComponent,
    ResponseCommentsComponent,
    PostActionsComponent
  ],
  exports:      [
    NgxSpinnerModule, 
    AutofocusDirective, 
    MyFeedComponent, 
    PostItemComponent,
    TrendingFeedComponent,
    LinkifyPipe,
    StockChartComponent,
    ReplyFormComponent,
    ResponseCommentsComponent,
    PostActionsComponent
  ],
  providers:  [MyFeedService]
})
export class SharedModule { }