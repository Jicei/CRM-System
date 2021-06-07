import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Activity } from 'src/app/model/activity';
import { environment } from 'src/app/environment';
import { ApiPaths } from 'src/app/api-paths';
import { Guid } from "guid-typescript";
import { Observable } from 'rxjs';
import { ActivityAbcXyz } from '../model/activity-abc-xyz';
 
@Injectable()
export class DataActivityService {
 
    private url = `${environment.baseUrl}/${ApiPaths.Activity}`;
 
    constructor(private http: HttpClient) {
    }
 
    getActivities(): Observable<Activity[]> {
        return this.http.get<Activity[]>(this.url);
    }
    getActivity(id: Guid) {
        return this.http.get(this.url + '/' + id);
    }
    createActivity(activity: Activity) {
        return this.http.post(this.url, activity);
    }
    updateActivity(activity: Activity) {
        return this.http.put(this.url, activity);
    }
    deleteActivity(id: Guid) {
        return this.http.delete(this.url + '/' + id);
    }
    getAbcXyz():Observable<ActivityAbcXyz[]> {
        return this.http.get<ActivityAbcXyz[]>(this.url + '/AbcXyz');
    }
}