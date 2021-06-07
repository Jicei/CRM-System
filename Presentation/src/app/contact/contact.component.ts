    import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
    import { DataContactService } from './data.contact-service';
    import { Contact } from 'src/app/model/contact';
    
    @Component({
        selector: 'app-contact',
        templateUrl: './contact.component.html',
        providers: [DataContactService]
    })
    export class ContactComponent implements OnInit {
        contact: Contact = new Contact();
        contacts: Contact[];
        tableMode: boolean = true;
    
        constructor(private dataService: DataContactService, private cdr:ChangeDetectorRef) {
            this.contacts = [];
         }
    
        ngOnInit() {
            this.loadContacts();    // загрузка данных при старте компонента  
        }
        // получаем данные через сервис
        loadContacts() {
            this.dataService.getContacts()
                .subscribe((data: Contact[]) => {
                    this.contacts = data
                    this.cdr.detectChanges()
                });
        }
        // сохранение данных
        save() {
            if (this.contact.Id == null) {
                this.dataService.createContact(this.contact)
                    .subscribe((data: Contact) => {
                        this.loadContacts();
                        });
            } else {
                this.dataService.updateContact(this.contact)
                    .subscribe(data => this.loadContacts());
            }
            this.cancel();
        }
        editContact(c: Contact) {
            this.contact = c;
        }
        cancel() {
            this.contact = new Contact();
            this.tableMode = true;
        }
        delete(c: Contact) {
            this.dataService.deleteContact(c.Id!)
                .subscribe(data => this.loadContacts());
        }
        add() {
            this.cancel();
            this.tableMode = false;
        }
    }