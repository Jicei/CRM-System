import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Chart, registerables  } from 'node_modules/chart.js';
Chart.register(...registerables);
import { DataOpportunityService } from './data.opportunity-service';
import { Opportunity } from 'src/app/model/opportunity';
import { ProductAbcFmr } from '../model/product-abc-fmr';
import * as _ from 'lodash';


@Component({
  selector: 'app-opportunity',
  templateUrl: './opportunity.component.html',
  styleUrls: ['./opportunity.component.scss'],
  providers: [DataOpportunityService]
})
export class OpportunityComponent implements OnInit {

  opportunity: Opportunity = new Opportunity();
  opportunities: Opportunity[];
  tableMode: boolean = true;
  productAbcFmr: ProductAbcFmr[];

  constructor(private dataService: DataOpportunityService, private cdr:ChangeDetectorRef) {
    this.opportunities = [];
    this.productAbcFmr = [];
   }

   ngOnInit(): void {
    this.loadOpportunities();
    this.getAbcFmrProduct();
  }
  loadOpportunities() {
    this.dataService.getOpportunities()
        .subscribe((data: Opportunity[]) => {
            this.opportunities = data
            this.cdr.detectChanges()
        })
  }
  save() {
      if (this.opportunity.Id == null) {
          this.dataService.createOpportunity(this.opportunity)
              .subscribe((data: Opportunity) => {
                  this.loadOpportunities();
                  });
      } else {
          this.dataService.updateOpportunity(this.opportunity)
              .subscribe(data => this.loadOpportunities());
      }
      this.cancel();
  }
  editOpportunity(c: Opportunity) {
      this.opportunity = c;
  }
  cancel() {
      this.opportunity = new Opportunity();
      this.tableMode = true;
  }
  delete(c: Opportunity) {
      this.dataService.deleteOpportunity(c.Id!)
          .subscribe(data => this.loadOpportunities());
  }
  add() {
      this.cancel();
      this.tableMode = false;
  }
  getAbcFmrProduct() {
    this.dataService.getOpportunityAbcFmr()
    .subscribe((data:ProductAbcFmr[]) => {
        this.productAbcFmr = data;
        console.log(this.productAbcFmr);
        this.cdr.detectChanges()
        this.showChartProduct();
    });
  }
  showChartProduct() {
    var grouped = _.groupBy(this.productAbcFmr, function(product:ProductAbcFmr) {
      return product.Category;
    });
    let lablesClass = [];
    let dataClass = [];

    for(let key in grouped) {
      dataClass.push(grouped[key].length);
      lablesClass.push(key);
    }
    var chart = new Chart("mychart", {
      type: 'bar',
      data: {
          labels:  lablesClass,//["AF", "AM", "AR", "BF", "BM", "BR",  "CF", "CM", "CR"],
          datasets: [{
              label: 'Класифікація згідно ABC-FMR аналізу',
              data: dataClass,//[12,6,8,3,7,5,7,2,9],
              backgroundColor: [
                  'rgba(255, 99, 132, 0.2)',
                  'rgba(54, 162, 235, 0.2)',
                  'rgba(255, 206, 86, 0.2)',
                  'rgba(75, 192, 192, 0.2)',
                  'rgba(153, 102, 255, 0.2)',
                  'rgba(255, 159, 64, 0.2)',
                  'rgba(187, 112, 89, 0.2)',
                  'rgba(114, 159, 100, 0.2)',
                  'rgba(231, 142, 68, 0.2)',
                  'rgba(16, 48, 68, 0.2)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(187, 112, 89, 0.2)',
                'rgba(114, 159, 100, 0.2)',
                'rgba(231, 142, 68, 0.2)',
                'rgba(16, 48, 68, 0.2)'
              ],
              borderWidth: 1
          }]
      },
      options: {
          scales: {
              y: {
                  beginAtZero: true
              }
          }
      }
    });
  }
}
