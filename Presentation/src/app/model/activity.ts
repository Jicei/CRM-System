import { Guid } from "guid-typescript";

export class Activity {
    constructor(
        public Id?: Guid,
        public CreatedOn?: Date,
        public Name?: string,
        public DateStart?: Date,
        public DateEnd?: Date,
        public TypeActivityId?: Guid,
        public ResponsibleId?: Guid
    ){}
}