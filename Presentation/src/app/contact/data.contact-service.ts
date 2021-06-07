import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Contact } from 'src/app/model/contact';
import { environment } from 'src/app/environment';
import { ApiPaths } from 'src/app/api-paths';
import { Guid } from "guid-typescript";
import { Observable } from 'rxjs';
 
@Injectable()
export class DataContactService {
 
    private url = `${environment.baseUrl}/${ApiPaths.Contact}`;
 
    constructor(private http: HttpClient) {
    }
 
    getContacts(): Observable<Contact[]> {
        return this.http.get<Contact[]>(this.url);;
    }
    getContact(id: Guid) {
        return this.http.get(this.url + '/' + id);
    }
    createContact(contact: Contact) {
        return this.http.post(this.url, contact);
    }
    updateContact(contact: Contact) {
        return this.http.put(this.url, contact);
    }
    deleteContact(id: Guid) {
        return this.http.delete(this.url + '/' + id);
    }
}