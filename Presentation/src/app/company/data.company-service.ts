import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Company } from 'src/app/model/company';
import { environment } from 'src/app/environment';
import { ApiPaths } from 'src/app/api-paths';
import { Guid } from "guid-typescript";
import { Observable } from 'rxjs';
 
@Injectable()
export class DataCompanyService {
 
    private url = `${environment.baseUrl}/${ApiPaths.Company}`;
 
    constructor(private http: HttpClient) {
    }
 
    getCompanies(): Observable<Company[]> {
        return this.http.get<Company[]>(this.url);;
    }
    getCompany(id: Guid) {
        return this.http.get(this.url + '/' + id);
    }
    createCompany(company: Company) {
        return this.http.post(this.url, company);
    }
    updateCompany(company: Company) {
        return this.http.put(this.url, company);
    }
    deleteCompany(id: Guid) {
        return this.http.delete(this.url + '/' + id);
    }
}