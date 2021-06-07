import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Contact } from 'src/app/model/contact';
import { environment } from 'src/app/environment';
import { ApiPaths } from 'src/app/api-paths';
import { Guid } from "guid-typescript";
import { Observable } from 'rxjs';
 
@Injectable()
export class DataClientService {
 
    private url = `${environment.baseUrl}/${ApiPaths.Client}`;
 
    constructor(private http: HttpClient) {
    }
 
    getKohonena() {
        return this.http.get(this.url + '/' + 'ClasterClient');
    }
    getRFM() {
        return this.http.get(this.url + '/' + 'RFMClient');
    }
}