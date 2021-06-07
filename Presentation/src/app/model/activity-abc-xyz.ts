import { Guid } from "guid-typescript";

export class ActivityAbcXyz {
    constructor(
        public Id?: Guid,
        public Name?: string,
        public Count?: number,
        public PartCount?: number,
        public Category?: string
    ){}
}