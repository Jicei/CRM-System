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
              data:  dataClass,
              backgroundColor: [
                'rgba(255, 99, 132, 0.4)',
                'rgba(54, 162, 235, 0.4)',
                'rgba(255, 206, 86, 0.4)',
                'rgba(75, 192, 192, 0.4)',
                'rgba(153, 102, 255, 0.4)',
                'rgba(255, 159, 64, 0.4)',
                'rgba(187, 112, 89, 0.4)',
                'rgba(114, 159, 100, 0.4)',
                'rgba(231, 142, 68, 0.4)',
                'rgba(45, 23, 234, 0.4)',
                'rgba(243, 23, 201, 0.4)',
                'rgba(1, 83, 235, 0.4)',
                'rgba(68, 478, 75, 0.4)',
                'rgba(42, 183, 123, 0.4)',
                'rgba(138, 12, 86, 0.4)',
                'rgba(128, 48, 12, 0.4)',
                'rgba(135, 135, 89, 0.4)',
                'rgba(123, 186, 12, 0.4)',
                'rgba(137, 21, 13, 0.4)',
                'rgba(142, 86, 15, 0.4)',
                'rgba(78, 23, 67, 0.4)',
                'rgba(1, 23, 235, 0.4)',
                'rgba(68, 123, 75, 0.4)',
                'rgba(42, 45, 56, 0.4)',
                'rgba(38, 78, 45, 0.4)',
                'rgba(128, 13, 12, 0.4)',
                'rgba(45, 21, 78, 0.4)',
                'rgba(23, 12, 54, 0.4)',
                'rgba(12, 34, 56, 0.4)',
                'rgba(98, 8, 98, 0.4)',
                'rgba(45, 23, 27, 0.4)',
                'rgba(82, 62, 45, 0.4)',
                'rgba(64, 48, 13, 0.4)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 0.4)',
                'rgba(54, 162, 235, 0.4)',
                'rgba(255, 206, 86, 0.4)',
                'rgba(75, 192, 192, 0.4)',
                'rgba(153, 102, 255, 0.4)',
                'rgba(255, 159, 64, 0.4)',
                'rgba(187, 112, 89, 0.4)',
                'rgba(114, 159, 100, 0.4)',
                'rgba(231, 142, 68, 0.4)',
                'rgba(45, 23, 234, 0.4)',
                'rgba(243, 23, 201, 0.4)',
                'rgba(1, 83, 235, 0.4)',
                'rgba(68, 478, 75, 0.4)',
                'rgba(42, 183, 123, 0.4)',
                'rgba(138, 12, 86, 0.4)',
                'rgba(128, 48, 12, 0.4)',
                'rgba(135, 135, 89, 0.4)',
                'rgba(123, 186, 12, 0.4)',
                'rgba(137, 21, 13, 0.4)',
                'rgba(142, 86, 15, 0.4)',
                'rgba(78, 23, 67, 0.4)',
                'rgba(1, 23, 235, 0.4)',
                'rgba(68, 123, 75, 0.4)',
                'rgba(42, 45, 56, 0.4)',
                'rgba(38, 78, 45, 0.4)',
                'rgba(128, 13, 12, 0.4)',
                'rgba(45, 21, 78, 0.4)',
                'rgba(23, 12, 54, 0.4)',
                'rgba(12, 34, 56, 0.4)',
                'rgba(98, 8, 98, 0.4)',
                'rgba(45, 23, 27, 0.4)',
                'rgba(82, 62, 45, 0.4)',
                'rgba(64, 48, 13, 0.4)'
              ],
              borderWidth: 1
          }]
      },
      options: {
        scales: {
            y: {
                beginAtZero: true,
                title: {
                  text:'Кількість клієнтів',
                  display: true,
                }
            },
            x: {
              title: {
                text:'Група',
                display: true,
              }
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
              data:  dataClass,
              backgroundColor: [
                'rgba(255, 99, 132, 0.4)',
                'rgba(54, 162, 235, 0.4)',
                'rgba(255, 206, 86, 0.4)',
                'rgba(75, 192, 192, 0.4)',
                'rgba(153, 102, 255, 0.4)',
                'rgba(255, 159, 64, 0.4)',
                'rgba(187, 112, 89, 0.4)',
                'rgba(114, 159, 100, 0.4)',
                'rgba(231, 142, 68, 0.4)',
                'rgba(45, 23, 234, 0.4)',
                'rgba(243, 23, 201, 0.4)',
                'rgba(1, 83, 235, 0.4)',
                'rgba(68, 478, 75, 0.4)',
                'rgba(42, 183, 123, 0.4)',
                'rgba(138, 12, 86, 0.4)',
                'rgba(128, 48, 12, 0.4)',
                'rgba(135, 135, 89, 0.4)',
                'rgba(123, 186, 12, 0.4)',
                'rgba(137, 21, 13, 0.4)',
                'rgba(142, 86, 15, 0.4)',
                'rgba(78, 23, 67, 0.4)',
                'rgba(1, 23, 235, 0.4)',
                'rgba(68, 123, 75, 0.4)',
                'rgba(42, 45, 56, 0.4)',
                'rgba(38, 78, 45, 0.4)',
                'rgba(128, 13, 12, 0.4)',
                'rgba(45, 21, 78, 0.4)',
                'rgba(23, 12, 54, 0.4)',
                'rgba(12, 34, 56, 0.4)',
                'rgba(98, 8, 98, 0.4)',
                'rgba(45, 23, 27, 0.4)',
                'rgba(82, 62, 45, 0.4)',
                'rgba(64, 48, 13, 0.4)'
              ],
              borderColor: [
                'rgba(255, 99, 132, 0.4)',
                'rgba(54, 162, 235, 0.4)',
                'rgba(255, 206, 86, 0.4)',
                'rgba(75, 192, 192, 0.4)',
                'rgba(153, 102, 255, 0.4)',
                'rgba(255, 159, 64, 0.4)',
                'rgba(187, 112, 89, 0.4)',
                'rgba(114, 159, 100, 0.4)',
                'rgba(231, 142, 68, 0.4)',
                'rgba(45, 23, 234, 0.4)',
                'rgba(243, 23, 201, 0.4)',
                'rgba(1, 83, 235, 0.4)',
                'rgba(68, 478, 75, 0.4)',
                'rgba(42, 183, 123, 0.4)',
                'rgba(138, 12, 86, 0.4)',
                'rgba(128, 48, 12, 0.4)',
                'rgba(135, 135, 89, 0.4)',
                'rgba(123, 186, 12, 0.4)',
                'rgba(137, 21, 13, 0.4)',
                'rgba(142, 86, 15, 0.4)',
                'rgba(78, 23, 67, 0.4)',
                'rgba(1, 23, 235, 0.4)',
                'rgba(68, 123, 75, 0.4)',
                'rgba(42, 45, 56, 0.4)',
                'rgba(38, 78, 45, 0.4)',
                'rgba(128, 13, 12, 0.4)',
                'rgba(45, 21, 78, 0.4)',
                'rgba(23, 12, 54, 0.4)',
                'rgba(12, 34, 56, 0.4)',
                'rgba(98, 8, 98, 0.4)',
                'rgba(45, 23, 27, 0.4)',
                'rgba(82, 62, 45, 0.4)',
                'rgba(64, 48, 13, 0.4)'
              ],
              borderWidth: 1
          }]
      },
      options: {
        scales: {
            y: {
                beginAtZero: true,
                title: {
                  text:'Кількість клієнтів',
                  display: true,
                }
            },
            x: {
              title: {
                text:'Група',
                display: true,
              }
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
