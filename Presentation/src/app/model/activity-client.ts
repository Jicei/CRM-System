import { Guid } from "guid-typescript";

export class ActivityClient {
    constructor(
        public Id?: Guid,
        public Name?: string,
        public ActivityManagerTypeId?: Guid,
        public Description?: string,
        public ContactId?: Guid,
        public ResponsibleId?: Guid
    ){}
}