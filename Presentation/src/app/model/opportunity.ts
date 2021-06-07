import { Guid } from "guid-typescript";

export class Opportunity {
    constructor(
        public Id?: Guid,
        public DateStart?: Date,
        public DateEnd?: Date,
        public TypeId?: Guid,
        public TimeSpan?: string,
        public Description?: string,
        public Price?: number,
        public Discount?: number,
        public ContactId?: Guid,
        public CompanyId?: Guid,
        public ResponsibleId?: Guid,
    ){}
}