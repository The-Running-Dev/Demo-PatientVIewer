export class Patient {
    public readonly UniqueIdentifier: string;

    public readonly Name: string;

    public readonly DateOfBirth: string;

    public readonly PostalCode: string;

    constructor(init: any = {}) {
        this.UniqueIdentifier = init.UniqueIdentifier;
        this.Name = init.Name;
        this.DateOfBirth = init.DateOfBirth;
        this.PostalCode = init.PostalCode;
    }
}
