import { Guid } from "guid-typescript";

export class ProductAbcFmr {
    constructor(
        public ProductId?: Guid,
        public ProductName?: string,
        public Amount?: number,
        public PartAmount?: number,
        public Quantity?: number,
        public PartQuantity?: number,
        public Category?: string
    ){}
}