import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Lead } from 'src/app/model/lead';
import { environment } from 'src/app/environment';
import { ApiPaths } from 'src/app/api-paths';
import { Guid } from "guid-typescript";
import { Observable } from 'rxjs';
 
@Injectable()
export class DataLeadService {
 
    private url = `${environment.baseUrl}/${ApiPaths.Lead}`;
 
    constructor(private http: HttpClient) {
    }
 
    getLeads(): Observable<Lead[]> {
        return this.http.get<Lead[]>(this.url);;
    }
    getLead(id: Guid) {
        return this.http.get(this.url + '/' + id);
    }
    createLead(lead: Lead) {
        return this.http.post(this.url, lead);
    }
    updateLead(lead: Lead) {
        return this.http.put(this.url, lead);
    }
    deleteLead(id: Guid) {
        return this.http.delete(this.url + '/' + id);
    }
}