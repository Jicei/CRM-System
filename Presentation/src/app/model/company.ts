import { Guid } from "guid-typescript";

export class Company {
    constructor(
        public Id?: Guid,
        public Name?: string,
        public Telephone?: string,
        public Email?: string,
        public ResponsibleId?: Guid,
        public CountryId?: Guid,
        public CityId?: Guid,
        public LeadId?: Guid,
    ){}
}