import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { ActivityClient } from 'src/app/model/activity-client';
import { environment } from 'src/app/environment';
import { ApiPaths } from 'src/app/api-paths';
import { Guid } from "guid-typescript";
import { Observable } from 'rxjs';
 
@Injectable()
export class DataActivityClientService {
 
    private url = `${environment.baseUrl}/${ApiPaths.ActivityManager}`;
 
    constructor(private http: HttpClient) {
    }
 
    getClientActivities(): Observable<ActivityClient[]> {
        return this.http.get<ActivityClient[]>(this.url);
    }
    getClientActivity(id: Guid) {
        return this.http.get(this.url + '/' + id);
    }
    createClientActivity(clientActivity: ActivityClient) {
        return this.http.post(this.url, clientActivity);
    }
    updateClientActivity(clientActivity: ActivityClient) {
        return this.http.put(this.url, clientActivity);
    }
    deleteClientActivity(id: Guid) {
        return this.http.delete(this.url + '/' + id);
    }
}