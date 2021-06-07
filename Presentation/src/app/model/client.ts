import { Guid } from "guid-typescript";

export class Client {
    constructor(
        public ClientId?: Guid,
        public ClientName?: string,
        public Recency?: Date,
        public Frequency?: number,
        public MonetaryValue?: number,
        public ClassRfm?: string,
        public ClassKohonena?: number
    ){}
}