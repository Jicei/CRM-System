import { Guid } from "guid-typescript";

export class Contact {
    constructor(
        public Id?: Guid,
        public Name?: string,
        public Surname?:string, 
        public Patronymic?:string, 
        public Telephone?: string, 
        public Email?: string, 
        public Description?: string, 
        public CompanyId?: Guid,
        public CountryId?: Guid,
        public ResponsibleId?: Guid,
        public CityId?: Guid) { }
}