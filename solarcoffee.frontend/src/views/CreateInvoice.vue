<template>
    <div>
        <h1 id="invoiceTitle">
            Create Invoice
        </h1>
        <hr/>
        <div class="invoice-step" v-if="invoiceStep === 1"></div>
        <div class="invoice-step" v-if="invoiceStep === 2"></div>
        <div class="invoice-step" v-if="invoiceStep === 3"></div>
    </div>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator';
import {IInvoice, ILineItem} from '@/types/Invoice';
import { ICustomer } from '@/types/Customer';
import { IProductInventory } from '@/types/Product';
import CustomerService from '@/services/customer-service';
import InventoryService from '@/services/inventory-service';


const customerService = new CustomerService();
const inventoryService = new InventoryService();
const invoiceService = new InventoryService();

@Component({
    name: 'Create Invoice'
})
 export default class CreateInvoice extends Vue{

     
    invoiceStep: number = 1;

    invoice: IInvoice={
        customerId: 0,
        createdOn: new Date(),
        updatedOn: new Date(),
        lineItems: [],
    };
    customers: ICustomer[] = [];
    selectedCustomerId: number = 0;
    inventory: IProductInventory[] = [];
    lineItems: ILineItem[] = [];
    newItem: ILineItem = {
        product: undefined,
        quantity: 0 
    }

    async fetchData(): Promise<void>{
        this.customers = await customerService.getCustomers();
        this.inventory = await inventoryService.getInventory();
    }

    //life cycle hook
    async create(){
        await this.fetchData();
    }
 }

</script>

<style lang="scss" scoped>

</style>