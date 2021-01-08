export interface ICustomer{
    id: number,
    createdOn: Date,
    updatedOn?: Date,
    firstName: string,
    lastName: string,
    primaryAddress: ICustomersAddress
}

export interface ICustomersAddress{
    id: number,
    createdOn: Date,
    updatedOn?: Date,
    addressLine1: string,
    addressLine2: string,
    city: string,
    state: string,
    stpostalCode: string,
    primaryAddress: ICustomersAddress
}