import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Chart, registerables  } from 'node_modules/chart.js';
Chart.register(...registerables);
import * as _ from 'lodash';
import { DataReportService } from './data.report-service';
import { Report } from '../model/report';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss'],
  providers: [DataReportService]
})
export class ReportComponent implements OnInit {

  prediction: Report[];

  constructor(private dataService: DataReportService) { 
    this.prediction = [];
  }

  ngOnInit(): void {
    this.getLinePrediction();
  }

  getLinePrediction() {
    this.dataService.getLinePrediction()
    .subscribe((data: Report[]) => {
      this.prediction = data;
      this.showChartLinePrediction();
    })
  }

  showChartLinePrediction() {
    let labelsPred = this.prediction.map((pred:Report) => {
      let monthNames = [ 'Січень', 'Лютий', 'Березень', 'Квітень', 'Травень', 'Червень',
      'Липень', 'Серпень', 'Вересень', 'Жовтень', 'Листопад', 'Грудень' ];
      return pred.Year! + ' ' + monthNames[pred.Month! - 1]
    });
    let dataPred = this.prediction.map((pred:Report) => {
      return pred.Amount!
    });
    
    var chart = new Chart("mychart", {
      type: 'line',
      data: {
        labels: labelsPred,
        datasets: [{
          label: 'Прогнозування',
          data: dataPred,
          fill: false,
          borderColor: 'rgb(75, 192, 192)',
          tension: 0.1
        }]
      },
      options : {
        scales: {
          y: {
              title: {
                text:'Продажі',
                display: true,
              }
          },
          x: {
            title: {
              text:'Час',
              display: true,
            }
          },
        }
      }
    });
  }
}
