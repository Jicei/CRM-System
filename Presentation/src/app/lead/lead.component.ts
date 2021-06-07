import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { DataLeadService } from './data.lead-service';
import { Lead } from 'src/app/model/lead';

@Component({
  selector: 'app-lead',
  templateUrl: './lead.component.html',
  styleUrls: ['./lead.component.scss'],
  providers: [DataLeadService]
})
export class LeadComponent implements OnInit {

  lead: Lead = new Lead();
  leads: Lead[];
  tableMode: boolean = true;

  constructor(private dataService: DataLeadService, private cdr:ChangeDetectorRef) {
    this.leads = [];
   }

  ngOnInit(): void {
    this.loadLeads();
  }
  loadLeads() {
    this.dataService.getLeads()
        .subscribe((data: Lead[]) => {
            this.leads = data
            this.cdr.detectChanges()
        })
  }
  save() {
      if (this.lead.Id == null) {
          this.dataService.createLead(this.lead)
              .subscribe((data: Lead) => {
                  this.loadLeads();
                  });
      } else {
          this.dataService.updateLead(this.lead)
              .subscribe(data => this.loadLeads());
      }
      this.cancel();
  }
  editLead(c: Lead) {
      this.lead = c;
  }
  cancel() {
      this.lead = new Lead();
      this.tableMode = true;
  }
  delete(c: Lead) {
      this.dataService.deleteLead(c.Id!)
          .subscribe(data => this.loadLeads());
  }
  add() {
      this.cancel();
      this.tableMode = false;
  }
}
