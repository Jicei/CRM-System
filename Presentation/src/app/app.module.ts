import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactComponent } from './contact/contact.component';
import { ClientAnalysisComponent } from './client-analysis/client-analysis.component';
import {Routes, RouterModule} from '@angular/router';
import { CompanyComponent } from './company/company.component';
import { LeadComponent } from './lead/lead.component';
import { OpportunityComponent } from './opportunity/opportunity.component';
import { ActivityComponent } from './activity/activity.component';
import { QueueComponent } from './queue/queue.component';
import { ActivityClientComponent } from './activity-client/activity-client.component';
import { ReportComponent } from './report/report.component';
import { ProductComponent } from './product/product.component';

const appRoutes: Routes =[
  { path: 'contact', component: ContactComponent},
  { path: 'client', component: ClientAnalysisComponent},
  { path: 'company', component: CompanyComponent},
  { path: 'lead', component: LeadComponent},
  { path: 'opportunity', component: OpportunityComponent},
  { path: 'activity', component: ActivityComponent},
  { path: 'report', component: ReportComponent},
  { path: 'activity-client', component: ActivityClientComponent}
];


@NgModule({
  declarations: [
    AppComponent,
    ContactComponent,
    ClientAnalysisComponent,
    CompanyComponent,
    LeadComponent,
    OpportunityComponent,
    ActivityComponent,
    QueueComponent,
    ActivityClientComponent,
    ReportComponent,
    ProductComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent, ContactComponent]
})
export class AppModule { }
