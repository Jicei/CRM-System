import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { environment } from 'src/app/environment';
import { ApiPaths } from 'src/app/api-paths';
import { Observable } from 'rxjs';
import { Report } from '../model/report';
 
@Injectable()
export class DataReportService {
 
    private url = `${environment.baseUrl}/${ApiPaths.Report}`;
 
    constructor(private http: HttpClient) {
    }
 
    getLinePrediction(): Observable<Report[]> {
        return this.http.get<Report[]>(this.url + '/LinePrediction');;
    }
}