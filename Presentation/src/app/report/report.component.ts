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
    this.getPrediction();
  }

  getPrediction() {
    this.dataService.getLinePrediction()
    .subscribe((data: Report[]) => {
      this.prediction = data;
      this.showChartLinePrediction();
    })
  }

  showChartLinePrediction() {
    let time;
    let labelsPred = this.prediction.map((pred:Report) => {
      let monthNames = [ 'January', 'February', 'March', 'April', 'May', 'June',
      'July', 'August', 'September', 'October', 'November', 'December' ];
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
      }
    });
  }
}
