import { Guid } from "guid-typescript";

export class KohonenaOpportunitySet {
    constructor(
        public ClientId?: Guid,
        public IsFisicalClient?: boolean,
        public Recency?: number,
        public Frequency?: number,
        public MonetaryValue?: number){}
}