import { Guid } from "guid-typescript";

export class Rfm {
    constructor(
        public ClientId?: Guid,
        public IsFisicalClient?: boolean,
        public Recency?: Date,
        public Frequency?: number,
        public MonetaryValue?: number,
        public Class?: string
    ){}
}