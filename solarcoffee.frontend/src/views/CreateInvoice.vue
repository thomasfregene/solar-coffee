<template>
    <div>
        <h1 id="invoiceTitle">
            Create Invoice
        </h1>
        <hr/>
        <div class="invoice-step" v-if="invoiceStep === 1">
            <h2>Step 1: Select Customers</h2>
            <div v-if="customers.length" class="invoice-step-detail">
                <label for="customer">Customer:</label>
                <select v-model="selectedCustomerId" class="invoiceCustomer" id="customer">
                    <option disabled value="">Please select a customer</option>
                    <option v-for="c in customers" :value="c.id" :key="c.id">{{c.firstName + " " + c.lastName}}</option>
                </select>
            </div>
        </div>
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
    async created(){
        await this.fetchData();
    }
 }

</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";
.invoice-steps-actions {
  display: flex;
  width: 100%;
}
.invoice-step {
}
.invoice-step-detail {
  margin: 1.2rem;
}
.invoice-order-list {
  margin-top: 1.2rem;
  padding: 0.8rem;
  .line-item {
    display: flex;
    border-bottom: 1px dashed #ccc;
    padding: 0.8rem;
  }
  .item-col {
    flex-grow: 1;
  }
}
.invoice-item-actions {
  display: flex;
}
.price-pre-tax {
  font-weight: bold;
}
.price-final {
  font-weight: bold;
  color: $solar-green;
}
.due {
  font-weight: bold;
}
.invoice-header {
  width: 100%;
  margin-bottom: 1.2rem;
}
.invoice-logo {
  padding-top: 1.4rem;
  text-align: center;
  img {
    width: 280px;
  }
}
</style>