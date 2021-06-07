import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Chart, registerables  } from 'node_modules/chart.js';
Chart.register(...registerables);
import { DataActivityService } from './data.activity-service';
import { Activity } from 'src/app/model/activity';
import { ActivityAbcXyz } from 'src/app/model/activity-abc-xyz';
import * as _ from 'lodash';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.scss'],
  providers: [DataActivityService]
})
export class ActivityComponent implements OnInit {

  activity: Activity = new Activity();
  activities: Activity[];
  activitiesAbcXyz: ActivityAbcXyz[];
  tableMode: boolean = true;
  activity2: ActivityAbcXyz;

  constructor(private dataService: DataActivityService, private cdr:ChangeDetectorRef) {
    this.activities = [];
    this.activitiesAbcXyz = [ new ActivityAbcXyz(undefined, 'lolol')];
    this.activity2 = new ActivityAbcXyz(undefined, 'lolol');
   }


  ngOnInit() {
    this.loadActivities();    // загрузка данных при старте компонента 
    this.getAbcXyzActivities();
  }
  // получаем данные через сервис
  loadActivities() {
      this.dataService.getActivities()
          .subscribe((data: Activity[]) => {
              this.activities = data
              this.cdr.detectChanges()
          });
  }
  // сохранение данных
  save() {
      if (this.activity.Id == null) {
          this.dataService.createActivity(this.activity)
              .subscribe((data: Activity) => {
                  this.loadActivities();
                  });
      } else {
          this.dataService.updateActivity(this.activity)
              .subscribe(data => this.loadActivities());
      }
      this.cancel();
  }
  editActivity(a: Activity) {
      this.activity = a;
  }
  cancel() {
      this.activity = new Activity();
      this.tableMode = true;
  }
  delete(c: Activity) {
      this.dataService.deleteActivity(c.Id!)
          .subscribe(data => this.loadActivities());
  }
  add() {
      this.cancel();
      this.tableMode = false;
  }
  getAbcXyzActivities() {
    this.dataService.getAbcXyz()
    .subscribe((data:ActivityAbcXyz[]) => {
        this.activitiesAbcXyz = data;
        console.log(this.activitiesAbcXyz);
        this.showChartActivity();
    });
  }
  showChartActivity() {
    var grouped = _.groupBy(this.activitiesAbcXyz, function(client:ActivityAbcXyz) {
      return client.Category;
    });
    console.log(this.activitiesAbcXyz);
    console.log(grouped);
    let lablesClass = [];
    let dataClass = [];

    for(let key in grouped) {
      dataClass.push(grouped[key].length);
      lablesClass.push(key);
    }
    var chart = new Chart("mychart", {
      type: 'bar',
      data: {
          labels:  lablesClass,//["AX", "AY", "AZ", "BX", "BY", "BZ",  "CX", "CY", "CZ"],
          datasets: [{
              label: 'Класифікація згідно ABC-XYZ аналізу',
              data: dataClass,//[10,3,5,8,9,6,3,8,7],
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
