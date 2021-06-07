import { Component, OnInit } from '@angular/core';
import { DataClientService } from './data.client-analysis-service';
import { Chart, registerables  } from 'node_modules/chart.js';
Chart.register(...registerables);
import * as _ from 'lodash';
import { Kohonena } from 'src/app/model/kohonena';
import { Rfm } from 'src/app/model/rfm';
import { DataContactService } from 'src/app/contact/data.contact-service';
import { Client } from 'src/app/model/client';
import { Contact } from 'src/app/model/contact';

@Component({
  selector: 'app-client-analysis',
  templateUrl: './client-analysis.component.html',
  styleUrls: ['./client-analysis.component.scss'],
  providers: [DataClientService, DataContactService]
})
export class ClientAnalysisComponent implements OnInit  {

  kohonenaResult: Kohonena[];
  rfmResult: object[];
  canvas: any;
  ctx: any;
  chart: any;
  clients: Client[];

  constructor(private dataService: DataClientService, private contactService:DataContactService) {
    this.kohonenaResult = [];
    this.rfmResult = [];
    this.clients = [];
   }

  ngOnInit() {
    this.KohonenaNetwork();
    //this.RfmAnalysis();
    //this.getClientClass();
    //console.log(this.clients);
  }
  KohonenaNetwork() {
    this.dataService.getKohonena()
    .subscribe((data: any) => {
        this.kohonenaResult = data;
        console.log(this.kohonenaResult);
        this.showChartKohonena();
        this.RfmAnalysis();
    });
  }
  showChartKohonena() {
    var grouped = _.groupBy(this.kohonenaResult, function(client:Kohonena) {
      return client.Class;
    });
    console.log(grouped);
    let lablesClass = [];
    let dataClass = [];

    for(let key in grouped) {
      dataClass.push(grouped[key].length);
      lablesClass.push(key);
    }
    var myChart = new Chart("mychart", {
      type: 'bar',
      data: {
          labels: lablesClass,
          datasets: [{
              label: 'Класифікація згідно нейронної мережі Кохонена',
              data: dataClass,
              backgroundColor: [
                  'rgba(255, 99, 132, 0.2)',
                  'rgba(54, 162, 235, 0.2)',
                  'rgba(255, 206, 86, 0.2)',
                  'rgba(75, 192, 192, 0.2)',
                  'rgba(153, 102, 255, 0.2)',
                  'rgba(255, 159, 64, 0.2)'
              ],
              borderColor: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(255, 206, 86, 1)',
                  'rgba(75, 192, 192, 1)',
                  'rgba(153, 102, 255, 1)',
                  'rgba(255, 159, 64, 1)'
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

  RfmAnalysis(){
    this.dataService.getRFM()
    .subscribe((data: any) => {
        this.rfmResult = data;
        console.log(this.rfmResult);
        this.showChartRfm();
        this.getClientClass();
    });
  }
  showChartRfm() {
    var grouped = _.groupBy(this.rfmResult, function(client:Rfm) {
      return client.Class;
    });
    console.log(grouped);
    let lablesClass = [];
    let dataClass = [];

    for(let key in grouped) {
      dataClass.push(grouped[key].length);
      lablesClass.push(key);
    }
    var myChart = new Chart("rfmchart", {
      type: 'bar',
      data: {
          labels: lablesClass,
          datasets: [{
              label: 'Класифікація згідно RFM аналізу',
              data: dataClass,
              backgroundColor: [
                  'rgba(255, 99, 132, 0.2)',
                  'rgba(54, 162, 235, 0.2)',
                  'rgba(255, 206, 86, 0.2)',
                  'rgba(75, 192, 192, 0.2)',
                  'rgba(153, 102, 255, 0.2)',
                  'rgba(255, 159, 64, 0.2)'
              ],
              borderColor: [
                  'rgba(255, 99, 132, 1)',
                  'rgba(54, 162, 235, 1)',
                  'rgba(255, 206, 86, 1)',
                  'rgba(75, 192, 192, 1)',
                  'rgba(153, 102, 255, 1)',
                  'rgba(255, 159, 64, 1)'
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
  getClientClass() {
    this.kohonenaResult.forEach((clientKohonena:Kohonena) => {
      this.rfmResult.forEach((clientRfm:Rfm)=> {
        if(clientKohonena.Client?.ClientId == clientRfm.ClientId) {
          this.contactService.getContact(clientRfm.ClientId!)
          .subscribe((data: Contact) => {
            this.clients.push(
              new Client 
              (
                clientRfm.ClientId,
                data.Name + ' ' + data.Surname + ' ' + data.Patronymic,
                clientRfm.Recency,
                clientRfm.Frequency,
                clientRfm.MonetaryValue,
                clientRfm.Class,
                clientKohonena.Class
              ));
              console.log(this.clients);
          });
          return;
        }
      });
    });
  }
}
