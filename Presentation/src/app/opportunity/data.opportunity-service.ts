import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Opportunity } from 'src/app/model/opportunity';
import { environment } from 'src/app/environment';
import { ApiPaths } from 'src/app/api-paths';
import { Guid } from "guid-typescript";
import { Observable } from 'rxjs';
import { ProductAbcFmr } from '../model/product-abc-fmr';
 
@Injectable()
export class DataOpportunityService {
 
    private url = `${environment.baseUrl}/${ApiPaths.Opportunity}`;
 
    constructor(private http: HttpClient) {
    }
 
    getOpportunities(): Observable<Opportunity[]> {
        return this.http.get<Opportunity[]>(this.url);;
    }
    getOpportunity(id: Guid) {
        return this.http.get(this.url + '/' + id);
    }
    createOpportunity(opportunity: Opportunity) {
        return this.http.post(this.url, opportunity);
    }
    updateOpportunity(opportunity: Opportunity) {
        return this.http.put(this.url, opportunity);
    }
    deleteOpportunity(id: Guid) {
        return this.http.delete(this.url + '/' + id);
    }
    getOpportunityAbcFmr(): Observable<ProductAbcFmr[]> {
        return this.http.get<ProductAbcFmr[]>(this.url + '/AbcFmr');
    }
}