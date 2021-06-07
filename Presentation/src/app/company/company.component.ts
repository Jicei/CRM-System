import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { DataCompanyService } from './data.company-service';
import { Company } from 'src/app/model/company';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss'],
  providers: [DataCompanyService]
})
export class CompanyComponent implements OnInit {

  company: Company = new Company();
  companies: Company[];
  tableMode: boolean = true;

  constructor(private dataService: DataCompanyService, private cdr:ChangeDetectorRef) {
    this.companies = [];
   }

        ngOnInit() {
            this.loadCompanies();    // загрузка данных при старте компонента  
        }
        // получаем данные через сервис
        loadCompanies() {
            this.dataService.getCompanies()
                .subscribe((data: Company[]) => {
                    this.companies = data
                    this.cdr.detectChanges()
                });
        }
        // сохранение данных
        save() {
            if (this.company.Id == null) {
                this.dataService.createCompany(this.company)
                    .subscribe((data: Company) => {
                        this.loadCompanies();
                        });
            } else {
                this.dataService.updateCompany(this.company)
                    .subscribe(data => this.loadCompanies());
            }
            this.cancel();
        }
        editCompany(c: Company) {
            this.company = c;
        }
        cancel() {
            this.company = new Company();
            this.tableMode = true;
        }
        delete(c: Company) {
            this.dataService.deleteCompany(c.Id!)
                .subscribe(data => this.loadCompanies());
        }
        add() {
            this.cancel();
            this.tableMode = false;
        }

}
