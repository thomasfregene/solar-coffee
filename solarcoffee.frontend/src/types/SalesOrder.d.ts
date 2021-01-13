import {ICustomer} from '@/types/Customer';
import {ILineItem} from '@/types/Invoice';

export interface ISalesOrder{
    id: number,
    createdOn: Date,
    updatedOn?: date,
    customer: ICustomer,
    isPaid: boolean,
    salesOrderItem: ILineItem[];
}