import { Guid } from "guid-typescript";

export class Lead {
    constructor(
        public Id?: Guid,
        public Name?: string,
        public TypeId?: Guid,
        public TelephoneNumber?: string,
        public Email?: string,
        public Description?: string,
        public ActivityId?: Guid,
    ){}
}