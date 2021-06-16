import { Component, OnInit } from '@angular/core';
import {DataActivityClientService} from './data-activity-client'
import {ActivityClient} from '../model/activity-client'

@Component({
  selector: 'app-activity-client',
  templateUrl: './activity-client.component.html',
  styleUrls: ['./activity-client.component.scss'],
  providers: [DataActivityClientService]
})
export class ActivityClientComponent implements OnInit {

  clientActivity: ActivityClient = new ActivityClient();
  clientActivities: ActivityClient[];
  tableMode: boolean = true;

  constructor(private DataService: DataActivityClientService) {
    this.clientActivities = [];
   }

  ngOnInit(): void {
    this.loadActivityManager();
  }

  loadActivityManager(): void {
    this.DataService.getClientActivities()
    .subscribe((data:ActivityClient[]) => {
      this.clientActivities = data;
    });
  }
  save(): void {
    if(this.clientActivity.Id == null) {
      this.DataService.createClientActivity(this.clientActivity)
      .subscribe(data => this.loadActivityManager());
    } else {
      this.DataService.updateClientActivity(this.clientActivity)
      .subscribe(data => this.loadActivityManager());
    }
    this.cancel();
  }
  delete(clientActivity: ActivityClient): void {
    this.DataService.deleteClientActivity(clientActivity.Id!).subscribe(data => this.loadActivityManager());;
  }
  add(): void {
    this.cancel();
    this.tableMode = false;
  }
  cancel(): void {
    this.clientActivity = new ActivityClient();
    this.tableMode = true;
  }
  editClientActivity(a:ActivityClient): void {
    this.clientActivity = a;
  }
}
