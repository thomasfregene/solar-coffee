export interface IInventoryTimeline{
    productInventorySnapshots: ISnapShot[],
    timeline:Date[]
}

export interface ISnapShot{
    productId: number,
    quantityOnHand: number[]
}